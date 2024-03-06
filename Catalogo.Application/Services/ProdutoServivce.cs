using AutoMapper;
using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;

namespace Catalogo.Application.Services;

public class ProdutoServivce : IProdutoService
{
    private IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;

    public ProdutoServivce(IMapper mapper, IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository ?? throw new ArgumentException(nameof(produtoRepository));
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProdutoDTO>> GetProdutoDTOsAsync()
    {
        var produtosEntities = await _produtoRepository.GetProdutosAsync();
        return _mapper.Map<IEnumerable<ProdutoDTO>>(produtosEntities);
    }

    public async Task<ProdutoDTO> GetByIdAsync(int? id)
    {
        var produtoEntity = await _produtoRepository.GetByIdAsync(id);
        return _mapper.Map<ProdutoDTO>(produtoEntity);
    }

    public async Task AddAsync(ProdutoDTO produtoDTO)
    {
        var produtoEntity = _mapper.Map<Produto>(produtoDTO);
        await _produtoRepository.CreateAsync(produtoEntity);
    }

    public async Task UpdateAsync(ProdutoDTO produtoDTO)
    {
        var produtoEntity = _mapper.Map<Produto>(produtoDTO);
        await _produtoRepository.UpdateAsync(produtoEntity);
    }

    public async Task RemoveAsync(int? id)
    {
        var produtoEntity = await _produtoRepository.GetByIdAsync(id);
        await _produtoRepository.RemoveAsync(produtoEntity);
    }

}
