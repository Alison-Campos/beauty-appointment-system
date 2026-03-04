using BeautyAppointments.API.DTOs;
using BeautyAppointments.API.Models;
using BeautyAppointments.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyAppointments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly CitaRepository _repo;

        public CitaController(CitaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("CitaObtenerTodas")]
        public async Task<IActionResult> CitaObtenerTodas()
        {
            var citas = await _repo.CitaObtenerTodas(); 
            return Ok(citas);   
        }

        [HttpGet("CitaObtenerPorId/{id}")]
        public async Task<IActionResult> CitaObtenerPorId (int id)
        {
            var cita = await _repo.CitaObtenerPorId(id);
            return cita == null ? NotFound($"No existe una cita con el id {id}") : Ok(cita);
        }

        [HttpPost("CitaCrear")]
        public async Task<IActionResult> CitaCrear([FromBody] CitaCrearDto cita)
        {
            var errores = new Dictionary<string, string>();

            if (!await _repo.ClienteExiste(cita.ClienteId))
                errores.Add("clienteId", "El cliente no existe");

            if (!await _repo.UsuarioExiste(cita.UsuarioId))
                errores.Add("usuarioId", "El usuario no existe");

            if (!await _repo.ServicioExiste(cita.ServicioId))
                errores.Add("servicioId", "El servicio no existe");

            if (errores.Any())
            {
                return BadRequest(new
                {
                    success = false,
                    errors = errores
                });
            }

            var disponible = await _repo.ValidarDisponibilidad(
                cita.UsuarioId,
                cita.FechaInicio,
                cita.FechaFin
            );

            if (!disponible)
            {
                errores.Add("disponibilidad", "La estilista ya tiene una cita en ese horario");

                return BadRequest(new
                {
                    success = false,
                    errors = errores
                    
                });
            }


            var id = await _repo.CitaCrear(cita);

            return Ok(new
            {
                success = true,
                data = new { IdCita = id }
            });
        }

        [HttpPut("CitaActualizar/{id}")]
        public async Task<IActionResult> CitaActualizar(int id, [FromBody] CitasActualizarDto cita)
        {
            var disponible = await _repo.ValidarDisponibilidad(
                   cita.UsuarioId,
                   cita.FechaInicio,
                   cita.FechaFin,
                   id
               );

            if(!disponible)
                return BadRequest("La estilista ya tiene una cita en ese horario");

            var actualizado = await _repo.CitaActualizar(id, cita);
            return actualizado ? NoContent() : NotFound($"No existe una cita con el id {id}");
        }

        [HttpDelete("CitaEliminar/{id}")]
        public async Task<IActionResult> CitaEliminar(int id)
        {
            var eliminado = await _repo.CitaEliminar(id);
            return eliminado ? NoContent() : NotFound($"No existe una cita con el id {id}");
        }
    }
}
