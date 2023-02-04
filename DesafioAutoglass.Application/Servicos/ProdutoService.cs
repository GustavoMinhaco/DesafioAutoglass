using AutoMapper;
using DesafioAutoglass.Application.DTOs;
using DesafioAutoglass.Application.Interfaces;
using DesafioAutoglass.Domain.Entidades;
using DesafioAutoglass.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutoglass.Application.Servicos
{
    public class ProdutoService : IProdutoService
    {

        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var produtosEntity = await _produtoRepository.GetProdutosAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtosEntity);
        }

        public async Task<ProdutoDTO> GetById(int? id)
        {
            var produtoEntity = await _produtoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutoDTO>(produtoEntity);
        }

        public async Task Add(ProdutoDTO clienteDto)
        {
            var clienteEntity = _mapper.Map<Produto>(clienteDto);
            await _produtoRepository.CreateAsync(clienteEntity);
        }

        public async Task Update(ProdutoDTO clienteDto)
        {
            var clienteEntity = _mapper.Map<Produto>(clienteDto);
            await _produtoRepository.UpdateAsync(clienteEntity);
        }
        public async Task Remove(int? id)
        {
            var produtoEntity = await _produtoRepository.GetByIdAsync(id);
            await _produtoRepository.RemoveAsync(produtoEntity);
        }
    }
}
