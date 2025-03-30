using Livraria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivrosController : ControllerBase
    {
        [HttpGet("MostrarTodosOsLivros")]
        public IActionResult MostrarTodosOsLivros(Livros livoros)
        {
            return Ok(livoros);
        }

        [HttpGet("BuscaLivro/{id:int}")]
        public IActionResult BuscaLivro(int id)
        {
            return Ok();
        }

        [HttpPost("AdicionarLivro")]
        public IActionResult AdicionarLivro(Livros livro)
        {
            return CreatedAtAction("Get", new { id = livro.Id}, livro);
        }

        [HttpPut("AtualizarLivro/{id:int}")]
        public IActionResult AtualizarLivro(int id, Livros livro)
        {
            if (id != livro.Id)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("DeletarLivro/{id:int}")]
        public IActionResult DeletarLivro(int id)
        {
            return NoContent();
        }
    }
}
