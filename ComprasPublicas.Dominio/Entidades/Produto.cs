
using ComprasPublicas.Dominio.Util;

namespace ComprasPublicas.Dominio.Entidades
{
    public class Produto
    {
        public long Id { get; }
        public string Descricao { get; } = string.Empty;
        public DateTime DataPregao { get; } = DateTime.MinValue;
        public decimal ValorLicitacao { get; } = 0M;

        private List<string> _mensagem = new List<string>();

        public Produto(long id, string descricao, DateTime dataPregao, decimal valorLicitacao)
        {
            Id = id;
            Descricao = descricao;
            DataPregao = dataPregao.Iso8601();
            ValorLicitacao = valorLicitacao;
            if (!Validacao(this))
            {
                throw new Exception(string.Join(';', _mensagem));
            }
        }

        private bool Validacao(Produto produto)
        {
           
            if (string.IsNullOrEmpty(produto.Descricao))
                _mensagem.Add("Descrição é obrigatória");

            if (produto!.DataPregao <= DateTime.MinValue)
                _mensagem.Add("Data pregão inválida");

            if(produto.ValorLicitacao <= 0M)
                _mensagem.Add("Valor licitação inválido");

            return !(_mensagem.Count > 0);
        }
    }
}
