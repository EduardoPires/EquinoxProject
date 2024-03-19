using Equinox.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Equinox.UI.Web.Data
{
    public static class MigrationsExtension
    {
        /// <summary>
        /// This contains the migration code for the application
        /// </summary>
        /// <param name="app"></param>
        /// <returns>A reference to app after the operation has completed</returns>
        public static async Task<WebApplication> Migrate(this WebApplication app)
        {
            using (var program = app.Services.CreateScope())
            {
                var service = program.ServiceProvider;

                var logger = service.GetService<ILogger<Program>>();
                try
                {
                    var equinoxContext = service.GetRequiredService<EquinoxContext>();
                    var eventStoreSqlContext = service.GetRequiredService<EventStoreSqlContext>();

                    await equinoxContext.Database.MigrateAsync();
                    await eventStoreSqlContext.Database.MigrateAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message, ex);

                }
            }
            return app;
        }
    }

}
