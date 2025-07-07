
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.EnviosVM
{
    public class EnvioUrgenteViewModel
    {

        [Required(ErrorMessage = "El número de Tracking es obligatorio.")]
        public string NumeroTracking { get; set; }

        [Required(ErrorMessage = "El peso del paquete es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El peso debe ser mayor a cero.")]
        public double PesoPaquete { get; set; }
        public bool EstadoFinalizado { get; set; }
        public DateTime? FechaFinalizacion { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Empleado.")]
        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Cliente.")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "La dirección postal es obligatoria.")]
        [StringLength(200, ErrorMessage = "La dirección no puede superar los 200 caracteres.")]
        public string DireccionPostalEspecifica { get; set; }

        [Required(ErrorMessage = "El tiempo de salida es obligatorio.")]
        public DateTime TiempoSalida { get; set; }

        [Required(ErrorMessage = "El tiempo de llegada es obligatorio.")]
        public DateTime TiempoLLegada { get; set; }

        
    }
}
