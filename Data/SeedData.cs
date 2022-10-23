using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new SchoolContext(serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                context.SaveChanges();
            }
        }
    }
}
