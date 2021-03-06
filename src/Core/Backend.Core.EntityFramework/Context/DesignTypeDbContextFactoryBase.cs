using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GoldenEye.Backend.Core.EntityFramework.Context
{
    public abstract class DesignTypeDbContextFactoryBase<TDBContext>: IDesignTimeDbContextFactory<TDBContext>
        where TDBContext : DbContext
    {
        public virtual TDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TDBContext>();
            var configuration = GetConfiguration();

            return Get(configuration, builder);
        }

        protected IConfigurationRoot GetConfiguration()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            return configuration;
        }

        protected abstract TDBContext Get(IConfigurationRoot configuration, DbContextOptionsBuilder<TDBContext> builder);
    }
}
