using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using src.VecRepositories.Extensions;

namespace src.VecApi.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencyInjection(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // Configure repositories
            serviceCollection.ConfigureRepositoriesAsync(configuration).Wait();
        }
    }
}