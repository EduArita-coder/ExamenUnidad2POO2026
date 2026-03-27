namespace ExamenUnidad2.Dtos
{
    public class DeletedResponseDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime DeletedAt { get; set; }
        public string Message { get; set; }
    }
}
