using Compartido.DTOs.Envio;
using Compartido.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.Envios
{
    public interface IFinalizarEnvio
    {
        void Ejecutar(EnvioFinalizarDTO envioFinalizaDto);

    }
}
