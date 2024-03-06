using ComprasPublicas.Infra.Data.Contexts.Produto;
using ComprasPublicas.Infra.Data.Repositorios.Produto.Interface;

namespace ComprasPublicas.Infra.Data.Repositorios.Produto
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ProdutoContext _context;

        public ProdutoRepositorio(ProdutoContext context)
        {
            _context = context;
        }

        public Dominio.Entidades.Produto Alterar(Dominio.Entidades.Produto obj)
        {
            _context.Produto.Update(obj);
            _context.SaveChanges();
            return obj;
        }

        public void Excluir(Dominio.Entidades.Produto obj)
        {
            _context.Produto.Remove(obj);
            _context.SaveChanges();
        }

        public Dominio.Entidades.Produto GetPorId(long id)
        {
            return _context.Produto.Where(x => x.Id == id).FirstOrDefault()!;
        }

        public Dominio.Entidades.Produto Inserir(Dominio.Entidades.Produto obj)
        {
            _context.Produto.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public IEnumerable<Dominio.Entidades.Produto> LitarTodos(int pageNumber, int pageSize)
        {
            return _context.Produto.Skip(pageNumber).Take(pageSize).ToList()!;
        }
    }
}
