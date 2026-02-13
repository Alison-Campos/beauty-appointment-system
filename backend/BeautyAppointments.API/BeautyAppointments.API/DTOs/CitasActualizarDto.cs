namespace BeautyAppointments.API.DTOs
{
    public class CitasActualizarDto
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string? Observaciones { get; set; }
        public bool Activo { get; set; }
    }
}
