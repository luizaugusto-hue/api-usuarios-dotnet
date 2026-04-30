using System.ComponentModel.DataAnnotations;

namespace ApiUsuarios.Models
{
    public class Personagem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Tipo { get; set; }
    }
}