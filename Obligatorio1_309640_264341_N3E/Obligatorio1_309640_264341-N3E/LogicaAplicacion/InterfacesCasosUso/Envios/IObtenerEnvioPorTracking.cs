using Compartido.DTOs.Envio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.Envios
{
    public interface IObtenerEnvioPorTracking
    {
        DetalleEnvioDTO Ejecutar(string tracking);
    }
}
