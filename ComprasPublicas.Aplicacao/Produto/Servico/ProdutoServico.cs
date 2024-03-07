
using ComprasPublicas.Aplicacao.Produto.DTO;
using ComprasPublicas.Infra.Data.Repositorios.Produto.Interface;

namespace ComprasPublicas.Aplicacao.Produto.Servico
{
    public class ProdutoServico : Interface.IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoServico)
        {
            _produtoRepositorio = produtoServico;
        }

        public ProdutoDTO Alterar(ProdutoDTO dto)
        {
            var produtoEntity = ProdutoMapper.DtoParaEntidade(dto);
            return ProdutoMapper.EntidadeParaDto(_produtoRepositorio.Alterar(produtoEntity));
        }

        public void Excluir(long id)
        {
            var produtoEntity = _produtoRepositorio.GetPorId(id);

            if(produtoEntity != null) 
            {
                _produtoRepositorio.Excluir(produtoEntity);
            }          
        }

        public ProdutoDTO GetPorId(long id)
        {
            return ProdutoMapper.EntidadeParaDto(_produtoRepositorio.GetPorId(id));
        }

        public ProdutoDTO Inserir(ProdutoDTO dto)
        {
            var produtoEntity = ProdutoMapper.DtoParaEntidade(dto);
            return ProdutoMapper.EntidadeParaDto(_produtoRepositorio.Inserir(produtoEntity));
        }

        public IEnumerable<ProdutoDTO> LitarTodos(int pageNumber, int pageSize = 50)
        {
            var listaRetorno = new List<ProdutoDTO>();
            if(pageSize > 50 || pageSize < 0)
                pageSize = 50;

            var lista = _produtoRepositorio.LitarTodos(pageNumber, pageSize).ToList();
            if(lista.Count > 0)
            {
                lista.ForEach(x => listaRetorno.Add(new ProdutoDTO
                {
                    Id = x.Id,
                    DataPregao = x.DataPregao,
                    Descricao = x.Descricao,
                    ValorLicitacao = x.ValorLicitacao
                }));
            }

            return listaRetorno;
        }
    }
}
