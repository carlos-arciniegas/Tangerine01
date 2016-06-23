﻿using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M5;
using DominioTangerine;
using ExcepcionesTangerine;
using ExcepcionesTangerine.M5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M5
{
    public class ComandoAgregarContactoAProyecto : Comando<bool>
    {
        private Entidad _proyecto;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="contacto"></param>
        /// <param name="proyecto"></param>
        public ComandoAgregarContactoAProyecto( Entidad contacto, Entidad proyecto ) 
        {
            _laEntidad = contacto;
            _proyecto = proyecto;
        }

        /// <summary>
        /// Método para ejecutar el comando
        /// </summary>
        /// <returns></returns>
        public override bool Ejecutar()
        {
            try
            {
                bool respuesta = false;

                IDAOContacto daoContacto = FabricaDAOSqlServer.crearDAOContacto();
                respuesta = daoContacto.AgregarContactoAProyecto( _laEntidad, _proyecto );

                return respuesta;
            }
            catch ( AgregarContactoException ex )
            {
                throw ex;
            }
            catch ( BaseDeDatosContactoException ex )
            {
                throw ex;
            }
        }
    }
}
