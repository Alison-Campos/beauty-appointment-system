using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using BeautyAppointments.API.Models;
using BeautyAppointments.API.DTOs;

namespace BeautyAppointments.API.Repositories
{
    public class UsuarioRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public UsuarioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection CrearConexion()
        {
            return new SqlConnection(_connectionString);

        }

        //CREAR
        public async Task<int> UsuarioCrear(Usuario usuario)
        {
            using var connection = CrearConexion();

            return await connection.ExecuteScalarAsync<int>(
                "sp_Usuarios_Crear",
                new
                {
                    usuario.Servicio,
                    usuario.Email,
                    usuario.PasswordHash,
                    usuario.Rol
                },
                commandType: CommandType.StoredProcedure

             );
        }

        // LEER TODO
        public async Task<IEnumerable<Usuario>> UsuarioObtenerTodos()
        {
            using var connection = CrearConexion();

            return await connection.QueryAsync<Usuario>(
                "sp_Usuarios_Obtener_Todos",
                commandType: CommandType.StoredProcedure
             );
        }

        //LEER POR ID
        public async Task<Usuario?> UsuarioObtenerPorId(int id)
        {
            using var connection = CrearConexion();

            return await connection.QueryFirstOrDefaultAsync<Usuario>(
                "sp_Usuarios_Obtener_Por_Id",
                new { IdUsuario = id },
                commandType: CommandType.StoredProcedure
             );
        }

        //ACTUALIZAR
        public async Task<bool> UsuarioActualizar(int id, UsuarioActualizarDto usuario)
        {
            using var connection = new SqlConnection(_connectionString);

            var rows = await connection.ExecuteScalarAsync<int>(
                "sp_Usuario_Actualizar",
                new
                {
                    IdUsuario = id,
                    usuario.Servicio,
                    usuario.Email,
                    usuario.Rol,
                    usuario.Activo
                },
                commandType: CommandType.StoredProcedure
            );
            return rows > 0;
        }

        //ELIMINAR
        public async Task<bool> UsuarioEliminar(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var rows = await connection.ExecuteScalarAsync<int>(
                "sp_Usuarios_Eliminar",
                new { IdUsuario = id },
                commandType: CommandType.StoredProcedure
            );

            return rows > 0;
        }
    }
}
