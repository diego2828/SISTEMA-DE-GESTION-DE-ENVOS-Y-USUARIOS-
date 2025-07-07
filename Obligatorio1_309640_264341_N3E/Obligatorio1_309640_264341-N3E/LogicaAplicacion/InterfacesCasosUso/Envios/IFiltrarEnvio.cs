using Compartido.DTOs.Envio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.Envios
{
    public interface IFiltrarEnvio
    {

        List<DatoEnvioDTO> Ejecutar(string email, DateTime fecha1, DateTime fecha2, bool estado);



    }
}
