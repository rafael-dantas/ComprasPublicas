using ComprasPublicas.Dominio.Entidades;
using ComprasPublicas.Dominio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprasPublicas.Test.Produto
{
    public class ProdutoTest
    {
        [Fact]
        public void TestarEntidateProduto()
        {
            var produto = new Dominio.Entidades.Produto(1, "Meu testes", DateTime.Now, 7500M);

            var data = DateTime.Now;
            var dataIso8601 = data.Iso8601();

            Assert.True(dataIso8601 == produto.DataPregao);
        }

        [Fact]
        public void TestarValidacaoProdutoDescricao()
        {  

            Assert.True(Assert.Throws<Exception>(
                () => new Dominio.Entidades.Produto(0, null, DateTime.Now, 45M)).Message == "Descrição é obrigatória");

        }

        [Fact]
        public void TestarValidacaoProdutoDataPregao()
        {
            Assert.True(Assert.Throws<Exception>(
                () => new Dominio.Entidades.Produto(0, "Descricao teste", DateTime.MinValue, 45M)).Message == "Data pregão inválida");
            
        }

        [Fact]
        public void TestarValidacaoProdutoValor()
        {
            Assert.True(Assert.Throws<Exception>(
                 () => new Dominio.Entidades.Produto(0, "Descricao teste", DateTime.Now, 0)).Message == "Valor licitação inválido");
            
        }
    }
}