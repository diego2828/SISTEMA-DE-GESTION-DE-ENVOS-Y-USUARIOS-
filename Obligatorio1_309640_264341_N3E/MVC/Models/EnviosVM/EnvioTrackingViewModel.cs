namespace MVC.Models.EnviosVM
{
    public class EnvioTrackingViewModel
    {
        public string NumeroTracking { get; set; }
        public double PesoPaquete { get; set; }
        public bool EstadoFinalizado { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public string Empleado { get; set; }
        public string Cliente { get; set; }
        public List<ComentarioTrackingDTO> Comentarios { get; set; }
    }

    public class ComentarioTrackingDTO
    {
        public string Mensaje { get; set; }
        public string EmpleadoEmail { get; set; }
    }
}
