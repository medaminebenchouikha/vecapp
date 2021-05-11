using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using src.VecRepositories.Abstractions;

namespace src.VecRepositories.Extensions
{
    public static class DependencyInjection
    {
        public static async Task ConfigureRepositoriesAsync(this IServiceCollection serviceCollection, IConfiguration configuration, CancellationToken cancellationToken = default)
        {
            serviceCollection.AddDbContext<VecDbContext>(options =>
              options
                  .UseSqlServer(configuration.GetConnectionString(DbConstants.DbConnectionStringName)));

            await serviceCollection.BuildServiceProvider().MigrateDatabaseAsync(cancellationToken);

            serviceCollection.AddScoped<IOrganizationRepository, OrganizationRepository>();

        }

        private static async Task MigrateDatabaseAsync(this IServiceProvider serviceProvider, CancellationToken cancellationToken = default)
        {
            using var scope = serviceProvider.CreateScope();
            var vecDbContext = scope.ServiceProvider.GetService<VecDbContext>();
            if (vecDbContext != null)
            {
                await vecDbContext.Database.MigrateAsync(cancellationToken);
            }
        }

    }
}