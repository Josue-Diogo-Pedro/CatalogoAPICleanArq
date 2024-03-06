using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;
    public CategoriasController(ICategoriaService categoriaService) => _categoriaService = categoriaService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
    {
        var categorias = await _categoriaService.GetCategoriaDTOsAsync();
        return Ok(categorias);
    }

    [HttpGet("{id}", Name = "GetCategoria")]
    public async Task<ActionResult<Categoria>> Get(int id)
    {
        var categoria = await _categoriaService.GetByIdAsync(id);
        if(categoria is null) return NotFound();

        return Ok(categoria);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);

        await _categoriaService.AddAsync(categoriaDTO);

        return new CreatedAtRouteResult("GetCategoria", new { id = categoriaDTO.Id }, categoriaDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody]CategoriaDTO categoriaDTO)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);

        if(id != categoriaDTO.Id) return BadRequest();

        await _categoriaService.UpdateAsync(categoriaDTO);
        return Ok(categoriaDTO);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Categoria>> Delete(int id)
    {
        var categoriaDTO = await _categoriaService.GetByIdAsync(id);
        if(categoriaDTO is null) return NotFound();

        await _categoriaService.RemoveAsync(id);
        return Ok(categoriaDTO);
    }
}
