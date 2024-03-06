using ComprasPublicas.Aplicacao.Produto.DTO;

namespace ComprasPublicas.Aplicacao.Produto.Servico.Interface
{
    public interface IProdutoServico
    {
        IEnumerable<ProdutoDTO> LitarTodos(int pageNumber, int pageSize);
        ProdutoDTO GetPorId(long id);
        ProdutoDTO Inserir(ProdutoDTO dto);
        ProdutoDTO Alterar(ProdutoDTO dto);
        void Excluir(long id);
    }
}
