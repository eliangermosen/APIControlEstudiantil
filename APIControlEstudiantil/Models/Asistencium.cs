using System;
using System.Collections.Generic;

namespace APIControlEstudiantil.Models
{
    public partial class Asistencium
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = null!;

        public virtual Estudiante Estudiante { get; set; } = null!;
    }
}
