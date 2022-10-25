

namespace EnforcerAPI.Data.Seeder
{
    public static class EnforcersSeeder
    {
        public static void SeedDatabse(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<EnforcerContext>());
        }

        private static void SeedData(EnforcerContext context)
        {
            if(context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            if (!context.Enforcers.Any())
            {
                context.Enforcers.AddRange(
                    new Enforcer { EnforcerId = "QWE69", Rank = EnforcerRanks.Sergant },
                    new Enforcer { EnforcerId = "ASD23", Rank = EnforcerRanks.Warrant },
                    new Enforcer { EnforcerId = "ZXC88", Rank = EnforcerRanks.General },
                    new Enforcer { EnforcerId = "MLP90", Rank = EnforcerRanks.General });

                context.SaveChanges();
            }
        }
    }
}
