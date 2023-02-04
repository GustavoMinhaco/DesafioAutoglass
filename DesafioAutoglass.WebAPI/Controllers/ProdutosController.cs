using DesafioAutoglass.Application.DTOs;
using DesafioAutoglass.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace DesafioAutoglass.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            var produtos = await _produtoService.GetProdutos();
            if (produtos == null)
                return NotFound("Produtos não encontrados!");

            return Ok(produtos);
        }

        [HttpGet("{id:int}", Name = "GetProduto")]
        public async Task<ActionResult<ProdutoDTO>> GetById(int id)
        {
            var produto = await _produtoService.GetById(id);
            if (produto == null)
                return NotFound("Produto não encontrado!");

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDto)
        {
            if (produtoDto == null)
                return BadRequest("Dados inválidos");

            await _produtoService.Add(produtoDto);
            return new CreatedAtRouteResult("GetProduto", new { id = produtoDto.Id },
                produtoDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProdutoDTO produtoDto)
        {
            if (id != produtoDto.Id)
                return BadRequest();

            if (produtoDto == null)
                return BadRequest();

            await _produtoService.Update(produtoDto);

            return Ok(produtoDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete (int id)
        {
            var produto = _produtoService.GetById(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado!");
            }

            await _produtoService.Remove(id);

            return Ok();
        }
    }
}
