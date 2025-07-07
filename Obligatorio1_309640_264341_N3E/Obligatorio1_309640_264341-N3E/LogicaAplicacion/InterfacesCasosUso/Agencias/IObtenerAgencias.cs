using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.Agencias
{
    public interface IObtenerAgencias
    {
        List<Agencia> Ejecutar();
    }
}
