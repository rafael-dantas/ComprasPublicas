using ComprasPublicas.Aplicacao.Produto.DTO;

namespace ComprasPublicas.Aplicacao.Produto
{
    public static class ProdutoMapper
    {
        public static ProdutoDTO EntidadeParaDto(Dominio.Entidades.Produto entity)
        {
            return new ProdutoDTO
            {
                Id = entity.Id,
                Descricao = entity.Descricao,
                DataPregao = entity.DataPregao,
                ValorLicitacao = entity.ValorLicitacao
            };
        }

        public static Dominio.Entidades.Produto DtoParaEntidade(ProdutoDTO dto)
        {
            return new Dominio.Entidades.Produto
                (dto.Id, dto.Descricao, dto.DataPregao, dto.ValorLicitacao);
        }
    }
}
