using Loans.Application;

public class Program
{
    public static Task Main(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddEnvironmentVariables();
            })
            .ConfigureWebHostDefaults(app =>
            {
                app.UseStartup<Startup>();
            })
            .Build()
            .RunAsync();
    }
}