using ComprasPublicas.Infra.Data.Contexts;
using ComprasPublicas.Infra.Data.Contexts.Produto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ComprasPublicas.Aplicacao.Config.IoC
{
    public static class InjectionDepencencySetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            Bootstrapper.RegisterServices(services);
        }

        public static void RegisterDatabase(this IServiceCollection services, string connction)
        {
            services.AddDbContext<ProdutoContext>(x => x.UseSqlServer(connction));            
        }
    }
}
