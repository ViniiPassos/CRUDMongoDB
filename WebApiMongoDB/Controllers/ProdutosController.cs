using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiMongoDB.Models;
using WebApiMongoDB.Services;

namespace WebApiMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoServices _produtoServices;

        public ProdutosController(ProdutoServices produtoServices)
        {
            _produtoServices = produtoServices;
        }

        [HttpGet]
        public async Task<List<Produto>> GetProdutos() =>
            await _produtoServices.GetAsync();

        [HttpGet("getprodutobyid/{id}")]
        public async Task<Produto> GetProdutoById(string id) =>
            await _produtoServices.GetAsync(id);

        [HttpPost]
        public async Task<Produto> PostProduto(Produto produto)
        {
            await _produtoServices.CreateAsync(produto);

            return produto;
        }

        [HttpPut]
        public async Task UpdateProduto(string id, Produto produto)
        {
            await _produtoServices.UpdateAsync(id, produto);
        }

        [HttpDelete]
        public async Task DeleteProduto(string id)
        {
            await _produtoServices.RemoveAsync(id);
        }
    }
}
