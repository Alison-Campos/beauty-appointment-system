using BeautyAppointments.API.DTOs;
using BeautyAppointments.API.Models;
using BeautyAppointments.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyAppointments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuariosController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("UsuariosObtenerTodos")]
        public async Task<IActionResult> UsuarioObtenerTodos()
        {
            return Ok(await _usuarioRepository.UsuarioObtenerTodos());
        }

        [HttpGet("UsuariosObtenerPorId/{id}")]
        public async Task<IActionResult> UsuarioObetenerPorId(int id)
        {
            var usuario = await _usuarioRepository.UsuarioObtenerPorId(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost("UsuariosCrear")]
        public async Task<IActionResult> UsuariosCrear([FromBody] Usuario usuario)
        {
            var id = await _usuarioRepository.UsuarioCrear(usuario);
            return Ok(new { IdUsuario = id });
        }

        //Arreglar
        [HttpPut("UsuariosActualizar/{id}")]
        public async Task<IActionResult> UsuarioActualizar( int id, [FromBody] UsuarioActualizarDto usuario)
        {
            var actualizado = await _usuarioRepository.UsuarioActualizar(id, usuario);

            if (!actualizado)
                return NotFound($"No existe un usuario con el id {id}");

            return NoContent();
        }

        [HttpDelete("UsuariosEliminar/{id}")]
        public async Task<IActionResult> UsuariosEliminar(int id)
        {
            var eliminado = await _usuarioRepository.UsuarioEliminar(id);

            if (!eliminado)
                return NotFound($"No existe un usuario con el id {id}");

            return NoContent();
        }
    }
}
