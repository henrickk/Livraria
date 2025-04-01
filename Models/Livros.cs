using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string? Titulo { get; set; }

        public string? Autor { get; set; }

        public DateOnly AnoPublicacao { get; set; }

        public List<string>? Genero { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que 0,00 (zero).")]
        public decimal Preco { get; set; }
    }
}
