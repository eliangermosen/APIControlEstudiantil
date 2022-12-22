using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIControlEstudiantil.Models;
using APIControlEstudiantil.Models.DTO;

namespace APIControlEstudiantil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly ControlEstudiantilContext _context;

        public EstudiantesController(ControlEstudiantilContext context)
        {
            _context = context;
        }

        // GET: api/Estudiantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        // GET: api/Estudiantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
            var estudiante = await _context.Estudiantes.Include(c=>c.Calificacions).FirstOrDefaultAsync(e=>e.Id==id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return estudiante;
        }

        // GET: api/Estudiantes/asistencias
        [HttpGet("asistencias")]
        public async Task<ActionResult<List<RelacionEstudianteAsistencia>>> GetEstudianteAsistencias()
        {
            try
            {
                List<RelacionEstudianteAsistencia> relacion = new List<RelacionEstudianteAsistencia>();
                List<Estudiante> estudiante = new List<Estudiante>();
                List<Asistencium> asistencium = new List<Asistencium>();

                estudiante = await _context.Estudiantes.ToListAsync();
                asistencium = await _context.Asistencia.ToListAsync();

                for (int i = 0; i < estudiante.Count; i++)
                {
                    var relacionFiltro = new RelacionEstudianteAsistencia
                    {
                        Id = estudiante[i].Id,
                        Cedula = estudiante[i].Cedula,
                        Nombre = estudiante[i].Nombre,
                        Apellido = estudiante[i].Apellido,
                        Matricula = estudiante[i].Matricula,
                        Correo = estudiante[i].Correo,
                        Telefono = estudiante[i].Telefono,
                    };
                    List<AsistenciaDTO> asistenciaDTOs = new List<AsistenciaDTO>();
                    for (int j = 0; j < asistencium.Count; j++)
                    {
                        if (asistencium[j].EstudianteId == relacionFiltro.Id)
                        {
                            var relacionAsistencia = new AsistenciaDTO
                            {
                                Id = asistencium[j].Id,
                                Fecha = asistencium[j].Fecha,
                                Estado = asistencium[j].Estado,
                            };
                            asistenciaDTOs.Add(relacionAsistencia);
                        };
                    }
                    relacionFiltro.asistenciaDTO = asistenciaDTOs;
                    relacion.Add(relacionFiltro);
                }

                return Ok(relacion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/Estudiantes/calificaciones
        [HttpGet("calificaciones")]
        public async Task<ActionResult<List<RelacionEstudianteCalificacion>>> GetEstudianteCalificaciones()
        {
            try
            {
                List<RelacionEstudianteCalificacion> relacion = new List<RelacionEstudianteCalificacion>();
                List<Estudiante> estudiante = new List<Estudiante>();
                List<Calificacion> calificacion = new List<Calificacion>();

                estudiante = await _context.Estudiantes.ToListAsync();
                calificacion = await _context.Calificacions.ToListAsync();

                for (int i = 0; i < estudiante.Count; i++)
                {
                    var relacionFiltro = new RelacionEstudianteCalificacion
                    {
                        Id = estudiante[i].Id,
                        Cedula = estudiante[i].Cedula,
                        Nombre = estudiante[i].Nombre,
                        Apellido = estudiante[i].Apellido,
                        Matricula = estudiante[i].Matricula,
                        Correo = estudiante[i].Correo,
                        Telefono = estudiante[i].Telefono,
                    };
                    List<CalificacionDTO> calificacionDTOs = new List<CalificacionDTO>();
                    for (int j = 0; j < calificacion.Count; j++)
                    {
                        if (calificacion[j].EstudianteId == relacionFiltro.Id)
                        {
                            var relacionCalificacion = new CalificacionDTO
                            {
                                Id = calificacion[j].Id,
                                LenguaEspanola = calificacion[j].LenguaEspanola,
                                Matematicas = calificacion[j].Matematicas,
                                CienciasNaturales = calificacion[j].CienciasNaturales,
                                CienciasSociales = calificacion[j].CienciasSociales,
                            };
                            calificacionDTOs.Add(relacionCalificacion);
                        };
                    }
                    relacionFiltro.calificacionDTO = calificacionDTOs;
                    relacion.Add(relacionFiltro);
                }

                return Ok(relacion);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // PUT: api/Estudiantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, Estudiante estudiante)
        {
            if (id != estudiante.Id)
            {
                return BadRequest();
            }

            _context.Entry(estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Estudiantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudiante", new { id = estudiante.Id }, estudiante);
        }

        // DELETE: api/Estudiantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiantes.Any(e => e.Id == id);
        }
    }
}
