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

        public async Task<bool> Eliminar(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var rows = await connection.ExecuteScalarAsync<int>(
                "sp_Cita_Eliminar",
                new { IdCita = id },
                commandType: CommandType.StoredProcedure
            );

            return rows > 0;
        }

    }
}
