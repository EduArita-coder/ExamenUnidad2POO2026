using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ExamenUnidad2.Entities
{
    [Table("DetallePlanillas")]
    public class DetallePlanilla
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("PlanillaId")]
        [Required]
        public int PlanillaId { get; set; }

        [ForeignKey(nameof(PlanillaId))]
        public virtual Planilla Planilla { get; set; }
        [Column("EmpleadoId")]
        [Required]
        public int EmpleadoId { get; set; }
        [ForeignKey(nameof(EmpleadoId))]
        public virtual Empleado Empleado { get; set; }
        [Column("SalarioBase")]
        public decimal SalarioBase { get; set; }
        [Column("HorasExtra")]
        public decimal HorasExtra { get; set; }
        [Column("MontoHorasExtra")]
        public decimal MontoHorasExtra { get; set; }
        [Column("Bonificaciones")]
        public decimal Bonificaciones { get; set; }
        [Column("Deducciones")]
        public decimal Deducciones { get; set; }
        [Column("SalarioNeto")]
        public decimal SalarioNeto { get; set; }
        [Column("Comentarios")]
        public string Comentarios { get; set; }
    }
}