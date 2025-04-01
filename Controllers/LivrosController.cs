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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
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
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Livro>> BuscaLivro(int id)
        {
            if(_context.Livros == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.FindAsync(id);

            if(livro == null)
            {
                return NotFound();
            }

            return livro;
        }

        [HttpPost("AdicionarLivro")]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Livro>> AdicionarLivro(Livro livro)
        {
            if (_context.Livros == null)
            {
                return Problem("Erro ao adicionar um livro, contate o suporte!");
            }

            if (!ModelState.IsValid)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = "Um ou mais erros de validação ocorreram!"
                });
            }

            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(BuscaLivro), new { id = livro.Id }, livro);
        }

        [HttpPut("AtualizarLivro/{id:int}")]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task <IActionResult> AtualizarLivro(int id, Livro livro)
        {
            if (id != livro.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            _context.Entry(livro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!LivroExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("DeletarLivro/{id:int}")]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeletarLivro(int id)
        {
            if (_context.Livros == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.FindAsync();

            if (livro == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LivroExist(int id)
        {
            return (_context.Livros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
