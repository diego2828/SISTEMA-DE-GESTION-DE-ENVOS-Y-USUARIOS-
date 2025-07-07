using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesNegocio;


namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEnvio : IRepositorio<Envio>
    {
        IEnumerable<Envio> EnviosEnProceso();

        Envio FindByTracking(string tracking);

        IEnumerable<Envio> EnviosPorCliente(string emailCliente);

        List<Envio> FiltrarEnvios(string email,DateTime fecha1, DateTime fecha2, bool estado);

        IEnumerable<Envio> BuscarEnviosPorComentario(string emailCliente, string palabra);


    }
}
