using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.DTOs.Usuario;
using LogicaNegocio.EntidadesNegocio;

namespace LogicaAplicacion.InterfacesCasosUso.Usuarios
{
    public interface IEliminarUsuario
    {
        public void Ejecutar(int id, string correoAuditoria);
    }
}
