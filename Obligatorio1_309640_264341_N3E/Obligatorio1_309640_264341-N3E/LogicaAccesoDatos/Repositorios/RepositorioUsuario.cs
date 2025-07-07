using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;


namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private LogisticaContexto Contexto;

        public RepositorioUsuario(LogisticaContexto contexto) 
        {
            Contexto = contexto;
        }

        public void Add(Usuario usuario)
        {   Usuario usuarioBuscado = FindByEmail(usuario.Email.Valor);
            if(usuarioBuscado == null)
            {
                Contexto.Usuarios.Where(u => u.Email.Valor == usuario.Email.Valor).SingleOrDefault();
                Contexto.Usuarios.Add(usuario);
                Contexto.SaveChanges();

            }
            else
            {
                throw new Exception("El email ya existe en la base de datos.");
            }
        }

        public void Delete(int id)
        {
            Usuario usuarioBuscado = FindById(id);
            if (usuarioBuscado != null)
            {
                Contexto.Usuarios.Remove(usuarioBuscado);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioException("El usuario no existe en la base de datos.");
            }
        }

        public IEnumerable<Usuario> FindAll()
        {
            return Contexto.Usuarios.Include(u => u.Rol).ToList();
        }

        public Usuario FindById(int id)
        {
            return Contexto.Usuarios
            .Include(u => u.Rol)
            .FirstOrDefault(u => u.Id == id);
        }


        

        public void Update(Usuario item)
        {


            Usuario usuario = FindByEmail(item.Email.Valor);


            if (usuario == null || (usuario != null && item.Email.Valor == usuario.Email.Valor))
            {

                Contexto.ChangeTracker.Clear();
                Contexto.Usuarios.Update(item);
                Contexto.SaveChanges();

            }


        }


        public Usuario FindByEmail(string email)
        {
            return Contexto.Usuarios.Where(c => c.Email.Valor == email).SingleOrDefault();
        }

        public Usuario Login(string email, string password)
        {
            return Contexto.Usuarios.Where(u => u.Email.Valor == email && u.Contrasenia.Valor == password)
                .Include(u => u.Rol)
                .SingleOrDefault();
        }

    }
}
