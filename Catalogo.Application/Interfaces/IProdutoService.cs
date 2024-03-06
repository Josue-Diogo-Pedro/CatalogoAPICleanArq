using Catalogo.Application.DTOs;

namespace Catalogo.Application.Interfaces;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoDTO>> GetProdutoDTOsAsync();
    Task<ProdutoDTO> GetByIdAsync(int? id);
    Task AddAsync(ProdutoDTO produtoDTO);
    Task UpdateAsync(ProdutoDTO produtoDTO);
    Task RemoveAsync(int? id);
}
