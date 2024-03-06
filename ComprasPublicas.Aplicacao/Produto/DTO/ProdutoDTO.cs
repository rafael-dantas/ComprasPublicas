using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprasPublicas.Aplicacao.Produto.DTO
{
    public class ProdutoDTO
    {
        public long Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataPregao { get; set; } = DateTime.MinValue;
        public decimal ValorLicitacao { get; set; } = 0M;

    }
}
