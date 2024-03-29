using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Calendar.DAL.Events;

namespace Calendar.DAL.Extensions
{
    public static class IWebHostBuilderExtensions
    {
       public static IWebHostBuilder UseDatabase(this IWebHostBuilder builder, string connectionString)
       {
            builder.ConfigureServices(services =>
            {
                services.AddDbContext<CalendarContext>(options => options.UseNpgsql(connectionString));
                services.Configure<DbOptions>(options => options.ConnectionString = connectionString);
                services.AddOptions();
                services.AddTransient<IEventRepository, EventRepository>();
            });
            return builder;
       }
    }
}