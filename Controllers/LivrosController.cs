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
        [ProducesResponseType(typeof(Livros), StatusCodes.Status200OK)]
        public IActionResult MostrarTodosOsLivros()
        {
            var livros = new List<Livros>
            {
                new Livros
                {
                    Id = 1,
                    Titulo = "Harry Potter e a Pedra Filosofal",
                    Autor = "J. K. Rowling",
                    AnoPublicacao = new DateOnly(1997, 6, 26),
                    Genero = new List<string> { "Romance", "Literatura fantástica", "Literatura infantil", "Alta fantasia" },
                    Preco = 45.38M
                },
                new Livros
                {
                    Id = 2,
                    Titulo = "Harry Potter e a Câmara Secreta",
                    Autor = "J. K. Rowling",
                    AnoPublicacao = new DateOnly(1998, 7, 2),
                    Genero = new List<string> { "Romance", "Literatura fantástica", "Bildungsroman", "Alta fantasia", " Ficção de aventura" },
                    Preco = 55.17M
                },
                new Livros
                {
                    Id = 3,
                    Titulo = "Harry Potter e o Prisioneiro de Azkaban",
                    Autor = "J. K. Rowling",
                    AnoPublicacao = new DateOnly(1999, 7, 8),
                    Genero = new List<string> { "Romance", "Literatura fantástica" },
                    Preco = 38.94M
                },
            };
            return Ok(livros);
        }

        [HttpGet("BuscaLivro/{id:int}")]
        [ProducesResponseType(typeof(Livros), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscaLivro(int id)
        {
            return Ok(new Livros());
        }

        [HttpPost("AdicionarLivro")]
        [ProducesResponseType(typeof(Livros), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AdicionarLivro(Livros livro)
        {
            return CreatedAtAction("BuscaLivro", new { id = livro.Id }, livro);
        }

        [HttpPut("AtualizarLivro/{id:int}")]
        [ProducesResponseType(typeof(Livros), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AtualizarLivro(int id, Livros livro)
        {
            if (id != livro.Id)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("DeletarLivro/{id:int}")]
        [ProducesResponseType(typeof(Livros), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarLivro(int id)
        {
            return NoContent();
        }
    }
}
