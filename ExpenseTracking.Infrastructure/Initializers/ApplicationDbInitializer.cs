namespace ExpenseTracking.Infrastructure.Initializers
{
    public class ApplicationDbInitializer
    {
        public Task Initialize()
        {
            return Task.CompletedTask; // TODO: Seed database here with default user, maybe some default categories, etc.
        }
    }
}
