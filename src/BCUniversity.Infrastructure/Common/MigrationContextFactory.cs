using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace BCUniversity.Infrastructure.Common
{
    public class MigrationContextFactory : IDesignTimeDbContextFactory<UniversityContext>
    {
        public UniversityContext CreateDbContext(string[] args)
        {
            var envConnectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTIONSTRING");

            var dbSetting = Options.Create(new DbSettings()
            {
                ConnectionString = !string.IsNullOrWhiteSpace(envConnectionString)
                    ? envConnectionString
                    : "Server=localhost;Username=postgres;Password=postgres;Database=university"
            });

            return new UniversityContext(dbSetting);
        }
    }
}