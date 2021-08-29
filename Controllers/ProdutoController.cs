using BaseDsvApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaseDsvApi.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        public Produto Create(Produto produto)
        {
            produto.Nome += " alterado.";
            return produto;
        }
    }
}