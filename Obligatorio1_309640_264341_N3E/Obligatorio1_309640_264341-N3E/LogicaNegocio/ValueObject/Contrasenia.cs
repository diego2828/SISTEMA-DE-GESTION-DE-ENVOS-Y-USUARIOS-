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

    public record Contrasenia
    {
        public string Valor { get; private set; }

        protected Contrasenia()
        {

        }
        public Contrasenia(string valor)
        {
            Valor = valor;
            Validar();
        }
        private void Validar()
        {
            if (Valor.Length < 8)
            {
                throw new UsuarioException("La contrasenia debe tener por lo menos 8 caracteres");
            }

        }


    }
}
