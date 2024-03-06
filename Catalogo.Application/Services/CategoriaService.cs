using AutoMapper;
using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;

namespace Catalogo.Application.Services;

public class CategoriaService : ICategoriaService
{
    private ICategoriaRepository _categoriaRepository;
    private readonly IMapper _mapper;

    public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
    {
        _categoriaRepository = categoriaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoriaDTO>> GetCategoriaDTOsAsync()
    {
        var categoriesEntity = await _categoriaRepository.GetCategoriasAsync();
        return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriesEntity);
    }

    public async Task<CategoriaDTO> GetByIdAsync(int? id)
    {
        var categoryEntity = await _categoriaRepository.GetByIdAsync(id);
        return _mapper.Map<CategoriaDTO>(categoryEntity);
    }

    public async Task AddAsync(CategoriaDTO categoriaDTO)
    {
        var categoryEntity = _mapper.Map<Categoria>(categoriaDTO);
        await _categoriaRepository.CreateAsync(categoryEntity);
    }

    public async Task UpdateAsync(CategoriaDTO categoriaDTO)
    {
        var categoryEntity = _mapper.Map<Categoria>(categoriaDTO);
        await _categoriaRepository.UpdateAsync(categoryEntity);
    }

    public async Task RemoveAsync(int? id)
    {
        var categoryEntity = await _categoriaRepository.GetByIdAsync(id);
        await _categoriaRepository.RemoveAsync(categoryEntity);
    }
}
