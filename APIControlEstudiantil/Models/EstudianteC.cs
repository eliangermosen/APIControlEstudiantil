using System;
using System.Collections.Generic;

namespace APIControlEstudiantil.Models
{
    public partial class EstudianteC
    {
        public EstudianteC()
        {
            Asistencia = new HashSet<Asistencium>();
        }

        public int Id { get; set; }
        public string Matricula { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;

        public virtual Calificacion Calificacion { get; set; }
        public virtual ICollection<Asistencium> Asistencia { get; set; }
    }
}
