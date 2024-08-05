using GerenciadorDeTarefas.Data;
using GerenciadorDeTarefas.Services;

namespace GerenciadorDeTarefas
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var key = configuration.GetValue<string>("SecretKey");
            services.AddScoped(option => new TokenService(key!));

            services.AddDbContext<AppDbContext>();
        }
    }
}
