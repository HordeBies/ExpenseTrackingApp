using ExpenseTracking.Core.Mappings;
using ExpenseTracking.Core.ServiceContracts;
using ExpenseTracking.Core.Services;
using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Domain.RepositoryContracts;
using ExpenseTracking.Infrastructure.DatabaseContexts;
using ExpenseTracking.Infrastructure.Initializers;
using ExpenseTracking.Infrastructure.Repositories;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.\r\n\r\n" +
        "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
        "Example: \"Bearer 45as678qw12eas\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                },
                Scheme = "oauth2",
                Name="Bearer",
                In = ParameterLocation.Header,
            } ,
            new List<string>()
        }
    });
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<ApplicationUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddHangfire(options =>
{
    options.UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"));
});
builder.Services.AddHangfireServer();

string key = builder.Configuration.GetValue<string>("ApiSettings:Secret")!;
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key))
    };
});
builder.Services.Configure<ScheduleSettings>(builder.Configuration.GetSection("ScheduleSettings"));
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddScoped<ITransactionRepository,TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IEmailAttachmentSender, EmailSenderService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<HangfireInitializer>();
builder.Services.AddScoped<ApplicationDbInitializer>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHangfireDashboard();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await InitializeDatabaseAndHangFire();
app.Run();

async Task InitializeDatabaseAndHangFire()
{
    using (var scope = app.Services.CreateScope())
    {
        var hangfireInitializer = scope.ServiceProvider.GetRequiredService<HangfireInitializer>();
        await hangfireInitializer.Initialize();
        var dbInitializer = scope.ServiceProvider.GetRequiredService<ApplicationDbInitializer>();
        await dbInitializer.Initialize();
    }
}

public partial class Program { }