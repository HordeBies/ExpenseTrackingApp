using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserPreferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReceiveDailyReports",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReceiveMonthlyReports",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReceiveWeeklyReports",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiveDailyReports",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReceiveMonthlyReports",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReceiveWeeklyReports",
                table: "AspNetUsers");
        }
    }
}
