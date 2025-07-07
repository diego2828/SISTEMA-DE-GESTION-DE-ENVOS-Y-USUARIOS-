using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicaNegocio.ValueObject
{

    [ComplexType]
    public record Ubicacion
    {
        public string ValorLatitud { get; private set; }
        public string ValorLongitud { get; private set; }

        protected Ubicacion()
        {

        }
        public Ubicacion(string valorLat, string valorLon)
        {
            ValorLatitud = valorLat;
            ValorLongitud = valorLon;
            
        }
       


    }
}
