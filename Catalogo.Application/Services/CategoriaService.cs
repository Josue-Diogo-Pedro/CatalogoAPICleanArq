using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;

namespace Catalogo.Application.Services;

public class CategoriaService : ICategoriaService
{
    public Task<IEnumerable<CategoriaDTO>> GetCategoriaDTOsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoriaDTO> GetByIdAsync(int? id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(CategoriaDTO categoriaDTO)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CategoriaDTO categoriaDTO)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(int? id)
    {
        throw new NotImplementedException();
    }
}
