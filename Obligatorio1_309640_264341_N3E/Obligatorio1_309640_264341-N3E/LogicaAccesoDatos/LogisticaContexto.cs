using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio.EntidadesNegocio;

namespace LogicaAccesoDatos
{
    public class LogisticaContexto: DbContext
    {
    
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Auditoria> Auditoria { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public LogisticaContexto(DbContextOptions<LogisticaContexto> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Empleado)
                .WithMany()
                .HasForeignKey("EmpleadoId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Cliente)
                .WithMany()
                .HasForeignKey("ClienteId")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Auditoria>()
                .HasOne(a => a.Usuario)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            // HERENCIA (TPH)
            modelBuilder.Entity<Envio>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Envio>("Envio")
                .HasValue<Comun>("Comun")
                .HasValue<Urgente>("Urgente");

            // Relación Comun - Agencia
            modelBuilder.Entity<Comun>()
                .HasOne(c => c.Agencia)
                .WithMany()
                .HasForeignKey(c => c.AgenciaId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}  

