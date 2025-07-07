using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Compartido.DTOs.Envio;
using LogicaNegocio.EntidadesNegocio;


namespace LogicaAplicacion.InterfacesCasosUso.Envios
{
    public interface IAltaEnvio
    {
        void Ejecutar(Envio envio);
    }
}
