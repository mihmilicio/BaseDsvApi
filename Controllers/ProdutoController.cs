using System;
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
        public IActionResult Create([FromBody] Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Created("", produto);
        }

        [HttpGet]
        [Route("list")]
        public List<Produto> List() => _context.Produtos.ToList();
        
        [HttpGet]
        [Route("find/{produtoId}")]
        public IActionResult Find([FromRoute] int produtoId)
        {
            Produto produto = _context.Produtos.Find(produtoId);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Produto produto)
        {
            try
            {
                _context.Produtos.Update(produto);
                _context.SaveChanges();
                return Ok(produto);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        [HttpDelete]
        [Route("delete/{produtoId}")]
        public IActionResult Delete([FromRoute] int produtoId)
        {
            Produto produto = _context.Produtos.Find(produtoId);
            if (produto == null)
            {
                return NotFound();
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok(produto); // pode fazer sentido retornar a lista atualizada
        }
        
        [HttpDelete]
        [Route("deletebyname/{produtoNome}")]
        public IActionResult DeleteByName([FromRoute] string produtoNome)
        {
            Produto produto = _context.Produtos.FirstOrDefault(p => p.Nome == produtoNome);
            if (produto == null)
            {
                return NotFound();
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok(_context.Produtos.ToList());
        }
    }
}