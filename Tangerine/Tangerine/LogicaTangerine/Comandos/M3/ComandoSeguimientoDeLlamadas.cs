﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine;
using DatosTangerine.InterfazDAO.M3;

namespace LogicaTangerine.Comandos.M3
{
    class ComandoSeguimientoDeLlamadas:Comando<List<Entidad>>
    {

        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="parametro">Cliente Potencial a consultar</param>
        public ComandoSeguimientoDeLlamadas(Entidad parametro)
        {
            LaEntidad = parametro;
        }

        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDAOClientePotencial daoClientePotencial = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();
                return daoClientePotencial.ConsultarLlamadasXId(this.LaEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
