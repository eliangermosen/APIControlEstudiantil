using System;
using System.Collections.Generic;

namespace APIControlEstudiantil.Models
{
    public partial class Calificacion
    {
        public int Id { get; set; }
        public int? EstudianteId { get; set; }
        public int? LenguaEspanola { get; set; }
        public int? Matematicas { get; set; }
        public int? CienciasSociales { get; set; }
        public int? CienciasNaturales { get; set; }

        public virtual Estudiante? Estudiante { get; set; }
    }
}
