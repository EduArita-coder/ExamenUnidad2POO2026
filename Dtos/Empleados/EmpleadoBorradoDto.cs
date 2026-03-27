namespace ExamenUnidad2.Dtos.Empleados
{
    public class EmpleadoBorradoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public DateTime FechaBorrado { get; set; }
        public string Motivo { get; set; }
    }
}
