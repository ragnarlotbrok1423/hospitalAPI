using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using campusCareAPI.Models;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Linq.Expressions;

namespace campusCareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasMedicasController : ControllerBase
    {
        private readonly CampusCareContext _context;

        public CitasMedicasController(CampusCareContext context)
        {
            _context = context;
        }

        // GET: api/CitasMedicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitasMedicasDTO>>> GetCitasMedicas()
        {
            var citasMedicas = await _context.CitasMedicas
                .Include(c => c.ServicioNavigation)
                .Include(c => c.TipoConsultaNavigation)
                .Include(c => c.PacienteNavigation)
                .Include(c => c.DoctorNavigation)
                .Select(C => new CitasMedicasDTO
                {
                    IdcitasMedicas = C.IdcitasMedicas,
                    Fecha = C.Fecha,
                    Servicios = new ServiciosDTO
                    {
                        CertificadoBuenaSalud = C.ServicioNavigation.CertificadoBuenaSalud,
                        Peso = C.ServicioNavigation.Peso,
                        Inhaloterapias = C.ServicioNavigation.Inhaloterapias,
                        Inyecciones = C.ServicioNavigation.Inyecciones,
                        GlisemiaCapilar = C.ServicioNavigation.GlisemiaCapilar,
                        ReferenciaMedica = C.ServicioNavigation.ReferenciaMedica
                    },
                    TipoConsulta = new TipoConsultaDTO
                    {
                        TipoConsulta = C.TipoConsultaNavigation.TipoConsulta
                    },
                    Usuarios = new PacientesDTO
                    {
                        Nombre = C.PacienteNavigation.Nombre,
                        Apellido = C.PacienteNavigation.Apellido,
                        Cedula = C.PacienteNavigation.Cedula,
                        NombreUsuario = C.PacienteNavigation.NombreUsuario
                    },
                    
                    Doctores = new DTO_s.DoctoresDTO
                    {
                        NombreCompleto = C.DoctorNavigation.NombreCompleto,
                        Cedula = C.DoctorNavigation.Cedula,
                        Especialidad = C.DoctorNavigation.Especialidad,
                        Diploma = C.DoctorNavigation.Diploma,
                        Perfil = C.DoctorNavigation.Perfil,
                    }


                })
                .ToListAsync();
            return Ok(citasMedicas);
        }

        // GET: api/CitasMedicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CitasMedica>> GetCitasMedica(int id)
        {
            var citasMedica = await _context.CitasMedicas.FindAsync(id);

            if (citasMedica == null)
            {
                return NotFound();
            }

            return citasMedica;
        }

        // PUT: api/CitasMedicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitasMedica(int id, CitasMedica citasMedica)
        {
            if (id != citasMedica.IdcitasMedicas)
            {
                return BadRequest();
            }

            _context.Entry(citasMedica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitasMedicaExists(id))
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

        // POST: api/CitasMedicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CitasMedica>> PostCitasMedica(CreateCitasMedicasDTO citasMedicasDTO)
        {
            var usuario = await _context.Pacientes.FirstOrDefaultAsync(c => c.IdUsuarios == citasMedicasDTO.IdUsuario);
            if (usuario == null)
            {
                return BadRequest("El usuario no existe");
            }
            var servicios = new Servicio
            {
                CertificadoBuenaSalud = citasMedicasDTO.CertificadoBuenaSalud,
                Peso = citasMedicasDTO.Peso,
                Inhaloterapias = citasMedicasDTO.Inhaloterapias,
                Inyecciones = citasMedicasDTO.Inyecciones,
                GlisemiaCapilar = citasMedicasDTO.GlisemiaCapilar,
                ReferenciaMedica = citasMedicasDTO.ReferenciaMedica

            };
            _context.Servicios.Add(servicios);
            await _context.SaveChangesAsync();
            var tipoConsulta = new TiposConsulta
            {
                TipoConsulta = citasMedicasDTO.TipoConsulta
            };
            _context.TiposConsultas.Add(tipoConsulta);
            await _context.SaveChangesAsync();

            var citasMedica = new CitasMedica
            {
                Fecha = citasMedicasDTO.Fecha,
                Servicio = servicios.Idservicios,
                TipoConsulta = tipoConsulta.IdtiposConsultas,
                Paciente = usuario.IdUsuarios
            };
            _context.CitasMedicas.Add(citasMedica);
            await _context.SaveChangesAsync();
            return Ok(citasMedica);


        }

        // DELETE: api/CitasMedicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCitasMedica(int id)
        {
            var citasMedica = await _context.CitasMedicas.FindAsync(id);
            if (citasMedica == null)
            {
                return NotFound();
            }

            _context.CitasMedicas.Remove(citasMedica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CitasMedicaExists(int id)
        {
            return _context.CitasMedicas.Any(e => e.IdcitasMedicas == id);
        }
    }
}
