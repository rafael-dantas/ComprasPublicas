using ComprasPublicas.Aplicacao.Produto.Servico;
using ComprasPublicas.Aplicacao.Produto.Servico.Interface;
using ComprasPublicas.Dominio.Entidades;
using ComprasPublicas.Dominio.Util;
using ComprasPublicas.Infra.Data.Contexts.Produto;
using ComprasPublicas.Infra.Data.Repositorios.Produto;
using ComprasPublicas.Infra.Data.Repositorios.Produto.Interface;
using Moq;
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

        [Fact]
        public void TesteServiceGetById()
        {
            var produto = new Dominio.Entidades.Produto(1, "Meu testes", DateTime.Now, 7500M);
            var repositoryMock = new Mock<IProdutoRepositorio>();
            repositoryMock.Setup(x => x.GetPorId(It.IsAny<long>())).Returns(produto);           
            
            IProdutoServico _produtoServico = new ProdutoServico(repositoryMock.Object);

            var retorno = _produtoServico.GetPorId(1);

            Assert.Equal("Meu testes", retorno.Descricao);

        }

        [Fact]
        public void TesteServiceGetList()
        {
            var listaProduto = new List<Dominio.Entidades.Produto>();
            listaProduto.Add(new Dominio.Entidades.Produto(1, "Meu testes", DateTime.Now, 7500M));
            listaProduto.Add(new Dominio.Entidades.Produto(2, "Meu testes", DateTime.Now, 7500M));
            var respositoryMock = new Mock<IProdutoRepositorio>();
            respositoryMock.Setup(x => x.LitarTodos(1, 2)).Returns(listaProduto);

            IProdutoServico _produtoServico = new ProdutoServico(respositoryMock.Object);

            var retorno = _produtoServico.LitarTodos(1, 2);

            Assert.True(retorno.Count() > 1);

        }

        [Fact]
        public void TesteServiceGetListPageSizeMaiorQue50()
        {
            var listaProduto = new List<Dominio.Entidades.Produto>();
            listaProduto.Add(new Dominio.Entidades.Produto(1, "Meu testes", DateTime.Now, 7500M));
            listaProduto.Add(new Dominio.Entidades.Produto(2, "Meu testes", DateTime.Now, 7500M));

            var respositoryMock = new Mock<IProdutoRepositorio>();
            respositoryMock.Setup(x => x.LitarTodos(1, 2)).Returns(listaProduto);

            IProdutoServico _produtoServico = new ProdutoServico(respositoryMock.Object);

            var retorno = _produtoServico.LitarTodos(1, 51).ToList();

            Assert.True(retorno.Count() == 0);

        }


        [Fact]
        public void TesteServiceGetListPageSizeMenorQueZero()
        {
            var listaProduto = new List<Dominio.Entidades.Produto>();

            var respositoryMock = new Mock<IProdutoRepositorio>();
            respositoryMock.Setup(x => x.LitarTodos(1, -2)).Returns(listaProduto);

            IProdutoServico _produtoServico = new ProdutoServico(respositoryMock.Object);

            var retorno = _produtoServico.LitarTodos(1, -2);

            Assert.True(retorno.Count() == 0);

        }
    }
}