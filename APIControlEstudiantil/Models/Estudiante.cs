using System;
using System.Collections.Generic;

namespace APIControlEstudiantil.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Asistencia = new HashSet<Asistencium>();
            Calificacions = new HashSet<Calificacion>();
        }

        public int Id { get; set; }
        public string? Matricula { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Cedula { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }

        public virtual ICollection<Asistencium> Asistencia { get; set; }
        public virtual ICollection<Calificacion> Calificacions { get; set; }
    }
}
