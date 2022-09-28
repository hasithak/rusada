using Data.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace Rusada.Web.Helpers
{
    public static class DBInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.Migrate();
            }
        }
    }
}