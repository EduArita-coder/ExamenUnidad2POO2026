using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ExamenUnidad2.Entities
{
    [Table("Planillas")]
    public class Planilla
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [Column("Periodo")]
        public string Periodo { get; set; }
        [Column("FechaCreacion")]

        public DateTime FechaCreacion { get; set; }
        [Column("FechaPago")]
        public DateTime FechaPago { get; set; }
        [Column("Estado")]
        public string Estado { get; set; }

    }
}