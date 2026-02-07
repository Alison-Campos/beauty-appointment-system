using BeautyAppointments.API.DTOs;
using BeautyAppointments.API.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BeautyAppointments.API.Repositories
{
    public class ServicioRepository
    {
        private readonly string _connectionString;
        
        public ServicioRepository (IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> ServicioCrear(ServicioCrearDto servicio)
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.ExecuteScalarAsync<int>(
                "sp_Servicio_Crear",
                servicio,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Servicio>> ServicioObtenerTodos()
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<Servicio>(
                "sp_Servicios_Obtener_Todos",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Servicio?> ServicioObtenerPorId(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryFirstOrDefaultAsync<Servicio>(
                "sp_Servicios_Obtener_PorId",
                new { IdServicio = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> ServicioActualizar(int id, ServicioActualizarDto servicio)
        {
            using var connection = new SqlConnection(_connectionString);

            var rows = await connection.ExecuteScalarAsync<int>(
                "sp_Servicios_Actualizar",
                new
                {
                    IdServicio = id,
                    servicio.Nombre,
                    servicio.DuracionMin,
                    servicio.Precio,
                    servicio.ColorCalendario,
                    servicio.Activo
                },
                commandType: CommandType.StoredProcedure);

            return rows > 0;
        }

        public async Task<bool> ServicioEliminar(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var rows = await connection.ExecuteScalarAsync<int>(
                "sp_Servicios_Eliminar",
                new { IdServicio = id },
                commandType: CommandType.StoredProcedure);

            return rows > 0;
        }


    }
}
