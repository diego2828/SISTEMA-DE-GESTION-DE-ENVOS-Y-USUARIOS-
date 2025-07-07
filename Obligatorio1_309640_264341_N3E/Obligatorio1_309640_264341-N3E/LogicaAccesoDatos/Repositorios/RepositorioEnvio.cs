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
    public class RepositorioEnvio : IRepositorioEnvio
    {


        private LogisticaContexto Contexto;

        public RepositorioEnvio(LogisticaContexto contexto)
        {
            Contexto = contexto;
        }

        public void Add(Envio item)
        {
            Contexto.Envios.Add(item);
            Contexto.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Envio> FindAll()
        {
            throw new NotImplementedException();
        }

        public Envio FindById(int id)
        {
            return Contexto.Envios.Find(id);

        }

        public void Update(Envio item)
        {
            //Contexto.Envios.Update(item);
            //Contexto.SaveChanges();

            Envio envioBuscado = FindById(item.Id);


            if (envioBuscado == null || (envioBuscado!=null && item.Id == envioBuscado.Id) ){

                Contexto.ChangeTracker.Clear();
                Contexto.Envios.Update(item);
                Contexto.SaveChanges();

            }


        }

    

        public IEnumerable<Envio> EnviosEnProceso()
        {
            // devuelve envios con estadoFinalizado en false
            //return Contexto.Envios.Where(e => !e.EstadoFinalizado).ToList();


            return Contexto.Envios.Where(e => !e.EstadoFinalizado).
                Include(e => e.Comentarios);


        }

        public Envio FindByTracking(string tracking)
        {
            return Contexto.Envios
            .Include(e => e.Empleado)
            .Include(e => e.Cliente)
            .Include(e => e.Comentarios)
                .ThenInclude(c => c.Empleado)
            .FirstOrDefault(e => e.NumeroTracking == tracking);
        }

        public List<Envio> FiltrarEnvios(string email, DateTime fecha1, DateTime fecha2, bool estado)
        {
            return Contexto.Envios.Where(e => e.fechaInicio > fecha1 &&
            e.fechaInicio < fecha2 && e.Cliente.Email.Valor == email && e.EstadoFinalizado==estado)
            .OrderBy(e => e.NumeroTracking)
            .ToList();
        }

        public IEnumerable<Envio> EnviosPorCliente(string emailCliente)
        {
            return Contexto.Envios
                .Include(e => e.Comentarios).ThenInclude(c => c.Empleado)
                .Include(e => e.Cliente)
                .Where(e => e.Cliente.Email.Valor == emailCliente)
                .OrderByDescending(e => e.fechaFinalizacion)
                .ToList();
        }

        public IEnumerable<Envio> BuscarEnviosPorComentario(string emailCliente, string palabra)
        {
            palabra = palabra?.ToLower() ?? "";

            var envios = Contexto.Envios
                .Include(e => e.Comentarios)
                    .ThenInclude(c => c.Empleado)
                .Where(e => e.Cliente.Email.Valor == emailCliente && e.Comentarios.Any(c => c.Mensaje.ToLower().Contains(palabra)))
                .OrderByDescending(e => e.fechaFinalizacion)
                .ToList();

            return envios;
        }

    }
}
