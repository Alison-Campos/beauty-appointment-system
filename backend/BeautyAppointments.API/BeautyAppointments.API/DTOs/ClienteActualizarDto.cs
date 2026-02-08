namespace BeautyAppointments.API.DTOs
{
    public class ClienteActualizarDto
    {
        public string Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Notas { get; set; }
        public bool Activo { get; set; }
    }
}
