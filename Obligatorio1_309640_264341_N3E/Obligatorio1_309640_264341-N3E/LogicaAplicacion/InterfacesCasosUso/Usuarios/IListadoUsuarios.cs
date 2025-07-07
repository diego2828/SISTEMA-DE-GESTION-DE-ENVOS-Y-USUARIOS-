using Compartido.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.Usuarios
{
    public interface IListadoUsuarios
    {
        List<ListadoUsuarioDTO> Ejecutar();
    }
}
