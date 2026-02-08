namespace BeautyAppointments.API.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Notas { get; set; }
        public DateTime FechaCreacionCliente { get; set; }
        public bool Activo { get; set; }
    }
}
