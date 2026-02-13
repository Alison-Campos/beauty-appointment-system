namespace BeautyAppointments.API.DTOs
{
    public class CitaCrearDto
    {
        public int ClienteId { get; set; }
        public int ServicioId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
        public string? Observaciones { get; set; }

    }
}

