using ComprasPublicas.Aplicacao.Produto.Servico.Interface;
using ComprasPublicas.Aplicacao.Produto.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ComprasPublicas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoServico _produtoApp;

        public ProdutoController(IProdutoServico produtoApp)
        {
            _produtoApp = produtoApp;   
        }


        [HttpGet("{pageNumber}/{pageSize}")]
        [ProducesResponseType(typeof(IEnumerable<ProdutoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErroResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
        public IActionResult Get(int pageNumber, int pageSize)
        {
            return Ok(_produtoApp.LitarTodos(pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErroResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
        public IActionResult GetById(long id)
        {
            return Ok(_produtoApp.GetPorId(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProdutoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErroResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
        public IActionResult Post(ProdutoDTO produto)
        {
            return Ok(_produtoApp.Inserir(produto));
        }

        
        [HttpPatch]
        [ProducesResponseType(typeof(ProdutoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErroResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
        public IActionResult Patch(ProdutoDTO produto)
        {
            return Ok(_produtoApp.Alterar(produto));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProdutoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErroResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
        public IActionResult Put(ProdutoDTO produto)
        {
            return Ok(_produtoApp.Alterar(produto));
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErroResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
        public IActionResult Delete(long id)
        {
            _produtoApp.Excluir(id);
            return Ok();
        }
    }
}
