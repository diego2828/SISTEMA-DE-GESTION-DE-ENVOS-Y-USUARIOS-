using System.ComponentModel.DataAnnotations;


namespace MVC.Models.EnviosVM
{
    public class EnvioViewModel
    {
        [Required(ErrorMessage = "El número de Tracking es obligatorio.")]
        public string NumeroTracking { get; set; }

        [Required(ErrorMessage = "El Peso del paquete es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El peso debe ser mayor a cero.")]
        public double PesoPaquete { get; set; }
        public bool EstadoFinalizado { get; set; }
        public DateTime? FechaFinalizacion { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Empleado.")]
        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Cliente.")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una Agencia.")]
        public int IdAgencia { get; set; }

       
    }
}