using ComprasPublicas.Aplicacao.Produto.Servico;
using ComprasPublicas.Aplicacao.Produto.Servico.Interface;
using ComprasPublicas.Infra.Data.Repositorios.Produto;
using ComprasPublicas.Infra.Data.Repositorios.Produto.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace ComprasPublicas.Aplicacao.Config.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection serviceCollection)
        {
            //Infra
            serviceCollection.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            //Service
            serviceCollection.AddScoped<IProdutoServico, ProdutoServico>();
        }
    }
}
