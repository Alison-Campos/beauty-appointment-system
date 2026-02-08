using BeautyAppointments.API.DTOs;
using BeautyAppointments.API.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BeautyAppointments.API.Repositories
{
    public class ClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository (IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> ClienteCrear (ClienteCrearDto cliente)
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.ExecuteScalarAsync<int>(
                "sp_Clientes_Crear",
                cliente,
                commandType: CommandType.StoredProcedure
                );
        }

        public async Task<IEnumerable<Cliente>> ClienteObtenerTodos()
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<Cliente>(
                "sp_ClienteS_Obtener_Todos",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Cliente?> ObtenerPorId(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Cliente>(
                "sp_Clientes_Obtener_PorId",
                new { IdCliente = id },
                commandType: CommandType.StoredProcedure
                );
        }

        public async Task<bool> ClienteActualizar (int id, ClienteActualizarDto cliente)
        {
            using var connection = new SqlConnection(_connectionString);

            var rows = await connection.ExecuteScalarAsync<int>(
            "sp_Servicio_Actualizar",
                new
                {
                    IdCliente = id,
                    cliente.Nombre,
                    cliente.Telefono,
                    cliente.Email,
                    cliente.Notas,
                    cliente.Activo
                },
                commandType: CommandType.StoredProcedure
            );

            return rows > 0;
        }

        public async Task<bool> ClienteEliminar(int id)
        {
            using var conn = new SqlConnection(_connectionString);

            var rows = await conn.ExecuteScalarAsync<int>(
                "sp_Clientes_Eliminar",
                new { IdCliente = id },
                commandType: CommandType.StoredProcedure
            );

            return rows > 0;
        }

    }
}
