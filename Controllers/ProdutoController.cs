using System.Collections.Generic;
using System.Linq;
using BaseDsvApi.Data;
using BaseDsvApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaseDsvApi.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _context;
        public ProdutoController(DataContext context) => _context = context;

        [HttpPost]
        [Route("create")]
        public Produto Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        [HttpGet]
        [Route("list")]
        public List<Produto> List() => _context.Produtos.ToList();
    }
}