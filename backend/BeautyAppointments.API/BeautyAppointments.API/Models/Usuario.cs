namespace BeautyAppointments.API.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Servicio {  get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Rol {  get; set; }
        public string Activo { get; set; }
        public DateTime FechaCreacionUsuario { get; set; }
    }
}
