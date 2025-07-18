﻿using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.Envios
{
    public interface IBuscarEnviosPorComentario
    {
        IEnumerable<Envio> Ejecutar(string emailCliente, string palabra);
    }
}
