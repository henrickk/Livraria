using Livraria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivrosController : ControllerBase
    {
        [HttpGet]
        public IActionResult MostrarTodosOsLivros(Livros livoros)
        {
            return Ok(livoros);
        }

        [HttpGet("{id:int}")]
        public IActionResult BuscaLivro(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AdicionarLivro(Livros livro)
        {
            return CreatedAtAction("Get", new { id = livro.Id}, livro);
        }

        [HttpPut("{id:int}")]
        public IActionResult AtualizarLivro(int id, Livros livro)
        {
            if (id != livro.Id)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletarLivro(int id)
        {
            return NoContent();
        }
    }
}
