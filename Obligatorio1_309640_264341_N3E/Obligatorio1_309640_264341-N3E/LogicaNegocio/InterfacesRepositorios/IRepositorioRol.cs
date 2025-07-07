using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesNegocio;


namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioRol:IRepositorio<Rol>
    {
        Rol ObtenerPorId(int id);

        List<Rol> ObtenerTodos();
    }
}
