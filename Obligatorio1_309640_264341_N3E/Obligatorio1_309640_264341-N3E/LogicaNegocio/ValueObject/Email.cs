using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;


namespace LogicaNegocio.ValueObject
{
    [ComplexType]

    public record Email
    {
        public string Valor { get; private set; }
        
        protected Email()
        {

        }

        public Email(string valor)
        {
            Valor = valor;
            Validar();
        }
        private void Validar()
        {
            if (!Valor.Contains("@"))
            {
                throw new UsuarioException("El email no es valido");
            }

        }




    }
}

