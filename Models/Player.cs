using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenParcial.Models
{
    [Table("t_player")]
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Range(15, 50)]
        public int Edad { get; set; }

        [Required]
        public string? Posicion { get; set; }

        [ForeignKey("Team")]
        public int EquipoId { get; set; }
        public Team? Team { get; set; }


        public ICollection<Assignment>? Assignments { get; set; }
    }
}

