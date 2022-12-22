namespace APIControlEstudiantil.Models.DTO
{
    public class RelacionEstudianteCalificacion
    {
        public int Id { get; set; }
        public string? Matricula { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Cedula { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }

        public List<CalificacionDTO> calificacionDTO { get; set; }
    }
}
