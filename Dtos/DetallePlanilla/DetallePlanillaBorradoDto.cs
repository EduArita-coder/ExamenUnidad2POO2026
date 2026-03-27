namespace ExamenUnidad2.Dtos.DetallePlanilla
{
    public class DetallePlanillaBorradoDto
    {
        public int Id { get; set; }
        public int PlanillaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime FechaBorrado { get; set; }
        public string Motivo { get; set; }
    }
}
