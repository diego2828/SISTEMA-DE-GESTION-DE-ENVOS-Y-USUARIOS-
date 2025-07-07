namespace MVC.Models.EnviosVM
{
    public class BuscarEnvioVM
    {
        public int Id { get; set; }
        public string NumeroTracking { get; set; }
        public bool EstadoFinalizado { get; set; }
        public DateTime? Fecha { get; set; }
        public List<BuscarComentarioVM> Comentarios { get; set; }
    }

    public class BuscarComentarioVM
    {
        public string Mensaje { get; set; }
        public string EmpleadoEmail { get; set; }
    }
}
