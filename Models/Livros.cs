using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Livros
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public DateOnly AnoPublicacao { get; set; }
        public List<string>? Genero { get; set; }
        public decimal Preco { get; set; }
    }
}
