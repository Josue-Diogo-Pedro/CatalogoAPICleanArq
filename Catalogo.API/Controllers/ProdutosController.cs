using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoSerice;

    public ProdutosController(IProdutoService produtoService) => _produtoSerice = produtoService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
    {
        var produtos = await _produtoSerice.GetProdutoDTOsAsync();
        return Ok(produtos);
    }

    [HttpGet("{id}", Name = "GetProduto")]
    public async Task<ActionResult<ProdutoDTO>> Get(int id)
    {
        var produto = await _produtoSerice.GetByIdAsync(id);
        if(produto is null) return NotFound();

        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody]ProdutoDTO produtoDTO)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);

        await _produtoSerice.AddAsync(produtoDTO);

        return new CreatedAtRouteResult("GetProduto", new {id = produtoDTO.Id }, produtoDTO.Id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody]ProdutoDTO produtoDTO)
    {
        if(id != produtoDTO.Id) return BadRequest();

        await _produtoSerice.UpdateAsync(produtoDTO);

        return Ok(produtoDTO);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ProdutoDTO>> Delete(int id)
    {
        var produtoDTO = await _produtoSerice.GetByIdAsync(id);
        if(produtoDTO is null) return NotFound();

        await _produtoSerice.RemoveAsync(id);
        return Ok(produtoDTO);
    } 

}
