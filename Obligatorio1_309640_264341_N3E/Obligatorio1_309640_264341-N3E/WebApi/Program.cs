using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.ImplementacionCasosUso.Envios;
using LogicaAplicacion.ImplementacionCasosUso.Usuarios;
using LogicaAplicacion.InterfacesCasosUso.Envios;
using LogicaAplicacion.InterfacesCasosUso.Usuarios;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();
            builder.Services.AddScoped<IObtenerEnvioPorTracking, ObtenerEnvioPorTracking>();
            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IListarEnviosPorCliente, ListarEnviosPorCliente>();
            builder.Services.AddScoped<ILoginUsuario, LoginUsuario>();
            builder.Services.AddScoped<IModificarUsuario, ModificarUsuario>();
            builder.Services.AddScoped<IFiltrarEnvio, FiltrarEnvio>();
            builder.Services.AddScoped<IBuscarEnviosPorComentario, BuscarEnviosPorComentario>();




            // DbContext
            string cadenaConexion = builder.Configuration.GetConnectionString("CadenaConexion");
            builder.Services.AddDbContext<LogisticaContexto>(options =>
                options.UseSqlServer(cadenaConexion));


            ////Comienza JWT////
            var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";

            builder.Services.AddAuthentication(aut =>
            {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut =>
            {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(claveSecreta)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();  
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
