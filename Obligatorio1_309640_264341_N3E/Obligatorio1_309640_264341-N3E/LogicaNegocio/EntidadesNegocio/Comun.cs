using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Comun : Envio
    {
        public int AgenciaId { get; set; }
        public Agencia Agencia { get; set; }

        public Comun() { }

        public Comun(
            string numeroTracking,
            Usuario empleado,
            Usuario cliente,
            double pesoPaquete,
            Agencia agencia,
            bool estadoFinalizado = false,
            DateTime? fechaFinalizacion = null
        )
            : base(
                numeroTracking,
                empleado,
                cliente,
                pesoPaquete,
                estadoFinalizado,
                fechaFinalizacion
            )
        {
            Agencia = agencia;
            ValidarComun();
        }

        private void ValidarComun()
        {
            if (Agencia == null)
                throw new Exception("La agencia no puede ser nula.");
            
        }
    }
}
