

namespace ComprasPublicas.Infra.Data.Repositorios.Produto.Interface
{
    public interface IProdutoRepositorio
    {
        IEnumerable<Dominio.Entidades.Produto> LitarTodos(int pageNumber, int pageSize);
        Dominio.Entidades.Produto GetPorId(long id);
        Dominio.Entidades.Produto Inserir(Dominio.Entidades.Produto obj);
        Dominio.Entidades.Produto Alterar(Dominio.Entidades.Produto obj);
        void Excluir(Dominio.Entidades.Produto obj);
    }
}
