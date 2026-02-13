namespace BeautyAppointments.API.Models
{
    public class Cita
    {
        public int IdCita { get; set; }
        public int ClienteId { get; set; }
        public int ServicioId { get; set; }
        public int UsuarioId { get; set; }  
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
        public string Estado { get; set; } = string.Empty;
        public string? Observaciones { get; set; }
        public DateTime FechaCreacionCita { get; set; }
        public bool Activo { get; set; }
    }
}
