using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using Catalogo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private ApplicationDbContext _context;
    public ProdutoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Produto>> GetProdutosAsync()
        => await _context.Produtos.AsNoTracking().DefaultIfEmpty().ToListAsync();

    public async Task<Produto> GetByIdAsync(int? id)
        => await _context.Produtos
        .AsNoTracking()
        .DefaultIfEmpty()
        .Include(c => c.Categoria)
        .SingleOrDefaultAsync(p => p.Id == id); 

    public async Task<Produto> CreateAsync(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> UpdateAsync(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> RemoveAsync(Produto produto)
    {
        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

}
