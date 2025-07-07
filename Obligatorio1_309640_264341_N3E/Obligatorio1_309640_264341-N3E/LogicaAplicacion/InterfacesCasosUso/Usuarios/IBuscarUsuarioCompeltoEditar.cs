using Compartido.DTOs.Usuario;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.Usuarios
{
    public interface IBuscarUsuarioCompeltoEditar
    {
        UsuarioModificarDTO Ejecutar(int id);
    }
}
