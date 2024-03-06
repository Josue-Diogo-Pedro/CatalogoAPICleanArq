using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;

namespace Catalogo.Application.Services;

public class ProdutoServivce : IProdutoService
{

    public Task<IEnumerable<ProdutoDTO>> GetProdutoDTOsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProdutoDTO> GetByIdAsync(int? id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(ProdutoDTO produtoDTO)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ProdutoDTO produtoDTO)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(int? id)
    {
        throw new NotImplementedException();
    }

}
