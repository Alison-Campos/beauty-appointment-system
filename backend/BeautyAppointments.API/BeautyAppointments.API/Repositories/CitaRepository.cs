using BeautyAppointments.API.DTOs;
using BeautyAppointments.API.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BeautyAppointments.API.Repositories
{
    public class CitaRepository
    {
        private readonly string _connectionString;

        public CitaRepository (IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Cita>> CitaObtenerTodas()
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<Cita>(
                "sp_Citas_Obtener_Todas",
                commandType: CommandType.StoredProcedure
                );

        }

        public async Task<Cita?> CitaObtenerPorId (int id)
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryFirstOrDefaultAsync<Cita>(
                "sp_Citas_Obtener_PorId",
                new { IdCita = id },
                commandType: CommandType.StoredProcedure
                );
        }

        public async Task<int> CitaCrear (CitaCrearDto cita)
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.ExecuteScalarAsync<int>(
                "sp_Citas_Crear",
                new
                {
                    cita.ClienteId,
                    cita.ServicioId,
                    cita.UsuarioId,
                    cita.FechaInicio,
                    cita.FechaFin,
                    cita.Observaciones
                },
                commandType : CommandType.StoredProcedure
            );
        }

        public async Task<bool> CitaActualizar(int id, CitasActualizarDto cita)
        {
            using var connection = new SqlConnection(_connectionString);

            var rows = await connection.ExecuteScalarAsync<int>(
                "sp_Citas_Actualizar",
                new
                {
                    idCita = id,
                    cita.FechaInicio,
                    cita.FechaFin,
                    cita.Estado,
                    cita.Observaciones,
                    cita.Activo
                },
                commandType: CommandType.StoredProcedure
             );
            return rows > 0;
        }

        public async Task<bool> CitaEliminar(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var rows = await connection.ExecuteScalarAsync<int>(
                "sp_Citas_Eliminar",
                new { IdCita = id },
                commandType: CommandType.StoredProcedure
            );

            return rows > 0;
        }

        public async Task<bool> ValidarDisponibilidad( int idUsuario, DateTime inicio, DateTime fin, int? idCita = null)
        {
            using var connection = new SqlConnection( _connectionString);

            var disponible = await connection.ExecuteScalarAsync<int>(
                "sp_Cita_ValidarDisponibilidad",
                new
                {
                    UsuarioId = idUsuario,
                    FechaInicio = inicio,
                    FechaFin = fin,
                    IdCita = idCita,
                },
                commandType: CommandType.StoredProcedure
             );

            return disponible == 1;
        }

        public async Task<bool> ClienteExiste(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var result = await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(1) FROM dbo.Clientes WHERE IdCliente = @IdCliente",
                new { IdCliente = id}
            );
            return result > 0;
        }

        public async Task<bool> ServicioExiste(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var result = await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(1) FROM dbo.Servicios WHERE IdServicio = @IdServicio",
                new { IdServicio = id }
            );
            return result > 0;
        }

        public async Task<bool> UsuarioExiste(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var result = await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(1) FROM dbo.Usuarios WHERE IdUsuario = @IdUsuario",
                new { IdUsuario = id }
            );
            return result > 0;
        }
    }
}
