using Catalogo.Application.DTOs;

namespace Catalogo.Application.Interfaces;

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaDTO>> GetCategoriaDTOsAsync();
    Task<CategoriaDTO> GetByIdAsync(int? id);
    Task AddAsync(CategoriaDTO categoriaDTO);
    Task UpdateAsync(CategoriaDTO categoriaDTO);
    Task RemoveAsync(int? id);
}
