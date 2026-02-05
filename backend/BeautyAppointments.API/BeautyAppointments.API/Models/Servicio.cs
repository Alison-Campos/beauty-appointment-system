namespace BeautyAppointments.API.Models
{
    public class Servicio
    {
        public int IdServicio { get; set; }
        public int DuracionMin {  get; set; }
        public decimal Precio { get; set; }
        public string ColorCalendario { get; set; }
        public bool Activo {  get; set; }

    }
}
