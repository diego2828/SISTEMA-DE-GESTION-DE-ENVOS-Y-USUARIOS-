namespace MVC.Models.EnviosVM
{
    public class EnvioConComentariosVM
    {
        public int Id { get; set; }
        public string NumeroTracking { get; set; }
        public bool Finalizado { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public List<ComentarioVM> Comentarios { get; set; }
    }

    public class ComentarioVM
    {
        public string Mensaje { get; set; }
        public string EmpleadoEmail { get; set; }
    }
}
