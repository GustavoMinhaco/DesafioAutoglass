using DesafioAutoglass.Domain.Entidades;
using DesafioAutoglass.Domain.Interfaces;
using DesafioAutoglass.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutoglass.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        ApplicationDbContext _produtoContext;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _produtoContext = context;
        }


        public async Task<Produto> CreateAsync(Produto produto)
        {
            _produtoContext.Add(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> GetByIdAsync(int? id)
        {
            return await _produtoContext.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            return await _produtoContext.Produtos.Where(x => x.Situacao).ToListAsync();
        }

        public async Task<Produto> UpdateAsync(Produto produto)
        {
            _produtoContext.Update(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> RemoveAsync(Produto produto)
        {
            produto.Situacao = false;
            _produtoContext.Update(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }
    }
}
