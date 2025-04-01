using Livraria.Data;
using Livraria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivrosController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public LivrosController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet("MostrarTodosOsLivros")]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Livro>>> MostrarTodosOsLivros()
        {
            if (_context.Livros == null)
            {
                return NotFound();
            }
            return await _context.Livros.ToListAsync();

        }


        [HttpGet("BuscaLivro/{id:int}")]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Livro>> BuscaLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);

            return livro;
        }

        [HttpPost("AdicionarLivro")]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Livro>> AdicionarLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(BuscaLivro), new { id = livro.Id }, livro);
        }

        [HttpPut("AtualizarLivro/{id:int}")]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <IActionResult> AtualizarLivro(int id, Livro livro)
        {
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("DeletarLivro/{id:int}")]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletarLivro(int id)
        {
            var livro = await _context.Livros.FindAsync();

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
