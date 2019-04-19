using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace BCUniversity.Infrastructure.Common
{
    public class MigrationContextFactory : IDesignTimeDbContextFactory<UniversityContext>
    {
        public UniversityContext CreateDbContext(string[] args)
        {
            var dbSetting = Options.Create(new DbSettings()
            {
                ConnectionString = "Server=localhost;Username=postgres;Password=postgres;Database=university"
            });

            return new UniversityContext(dbSetting);
        }
    }
}