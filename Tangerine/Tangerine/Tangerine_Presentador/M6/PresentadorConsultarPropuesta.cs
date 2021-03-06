﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M6;
using LogicaTangerine;
using DominioTangerine;
using System.Web;
using System.Windows.Forms;

namespace Tangerine_Presentador.M6
{
    public class PresentadorConsultarPropuesta
    {
        IContratoConsultarPropuesta vistaConsultar;

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        /// <param name="vista">Vista con los metodos implementados de IContratoConsultarPropuesta</param>

        public PresentadorConsultarPropuesta(IContratoConsultarPropuesta vista)
        {
            this.vistaConsultar = vista;
        }

        /// <summary>
        /// Get y set del string correspondiente a la tabla
        /// </summary>
        /// <param name="vista">Vista con los metodos implementados de IContratoConsultarPropuesta</param>
        public string propuesta
        {
            get
            {
                return this.vistaConsultar.Tabla.Text;
            }

            set
            {
                this.vistaConsultar.Tabla.Text = value;
            }
        }

        /// <summary>
        /// Metodo que consulta las propuestas 
        /// </summary>
        public void consultarPropuestas()
        {
            Comando <List<Entidad>> cmdConsultarPropuestas = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarTodosPropuesta();
            
            Comando<Entidad> cmdConsultarCompania;

            try
            {
                List<Entidad> listaPropuestas = cmdConsultarPropuestas.Ejecutar();
                foreach (Entidad _laPropuesta in listaPropuestas)
                {
                    //Creo un objeto de tipo Propuesta para poder obtener el fk de id de compania.
                    DominioTangerine.Entidades.M6.Propuesta laPropuesta = (DominioTangerine.Entidades.M6.Propuesta)_laPropuesta;
                    
                    //Creo objeto tipo Entidad(Compania) para luego pasarlo al comando de consulta y obtener los datos en BD.
                    //Inicializo el objeto solo con el Id (los demas campos en NULL).
                    Entidad _laCompania = DominioTangerine.Fabrica.FabricaEntidades.CrearCompaniaConId(
                        Int32.Parse(laPropuesta.IdCompañia), null, null, null, null, null, DateTime.Today, 0, 0, 0, 0);

                    cmdConsultarCompania = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarCompania(_laCompania);
                    
                    //Guardo en un objeto de tipo Entidad los datos de la compania, finalmente la casteo a tipo Compania.
                    _laCompania = cmdConsultarCompania.Ejecutar();

                    DominioTangerine.Entidades.M4.CompaniaM4 laCompania = (DominioTangerine.Entidades.M4.CompaniaM4)_laCompania; 

                    propuesta += RecursosPresentadorPropuesta.AbrirTR;
                    propuesta += RecursosPresentadorPropuesta.AbrirTD + laPropuesta.Nombre.ToString() 
                    + RecursosPresentadorPropuesta.CerrarTD;
                    propuesta += RecursosPresentadorPropuesta.AbrirTD + laCompania.NombreCompania.ToString() + 
                        RecursosPresentadorPropuesta.CerrarTD;
                    propuesta += RecursosPresentadorPropuesta.AbrirTD + laPropuesta.Feincio.ToShortDateString() +
                        RecursosPresentadorPropuesta.CerrarTD;

                    imprimirStatus(laPropuesta);

                    imprimirMoneda(laPropuesta);

                    imprimirBotones(laPropuesta);
                } 
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                MessageBox.Show(ex.Mensaje + ", por favor intente de nuevo.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            catch (ExcepcionesTangerine.ExceptionsTangerine ex)
            {
                MessageBox.Show(ex.Mensaje + ", por favor intente de nuevo.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ", por favor intente de nuevo.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metodo que imprime los botones de accion
        /// </summary>
        /// <param name="laPropuesta"></param>
        public void imprimirBotones(DominioTangerine.Entidades.M6.Propuesta laPropuesta)
        {
            propuesta += RecursosPresentadorPropuesta.AbrirTD2 
                + RecursosPresentadorPropuesta.botonConsultar + laPropuesta.Nombre.ToString() + 
                RecursosPresentadorPropuesta.botonCerra
                + RecursosPresentadorPropuesta.botonModificar + laPropuesta.Nombre.ToString() + 
                RecursosPresentadorPropuesta.intermedioBoton3 +
                RecursosPresentadorPropuesta.botonCerra;

            propuesta += RecursosPresentadorPropuesta.CerrarTD;

            propuesta += RecursosPresentadorPropuesta.CerrarTR;
        }

        /// <summary>
        /// Metodo que imprime el status de la propuesta
        /// </summary>
        /// <param name="laPropuesta"></param>
        public void imprimirStatus(DominioTangerine.Entidades.M6.Propuesta laPropuesta)
        {
            if (laPropuesta.Estatus.Equals("Aprobado"))
            {
                propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.aprobado +
                    RecursosPresentadorPropuesta.CerrarTD;
            }

            if (laPropuesta.Estatus.Equals("Pendiente"))
            {
                propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.pendiente +
                    RecursosPresentadorPropuesta.CerrarTD;
            }

            if (laPropuesta.Estatus.Equals("Cerrado"))
            {
                propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.cerrado +
                    RecursosPresentadorPropuesta.CerrarTD;
            }
        }

        /// <summary>
        /// Metodo que imprime la moneda de las propuestas
        /// </summary>
        /// <param name="laPropuesta"></param>
        public void imprimirMoneda(DominioTangerine.Entidades.M6.Propuesta laPropuesta)
        {
            if (laPropuesta.Moneda.Equals("Bolivar"))
            {
                propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.bolivar + 
                    RecursosPresentadorPropuesta.CerrarTD;
            }

            if (laPropuesta.Moneda.Equals("Dolar"))
            {
                propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.dolar +
                    RecursosPresentadorPropuesta.CerrarTD;
            }

            if (laPropuesta.Moneda.Equals("Euro"))
            {
                propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.euro + 
                    RecursosPresentadorPropuesta.CerrarTD;
            }

            if (laPropuesta.Moneda.Equals("Bitcoin"))
            {
                propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.bitcoin +
                    RecursosPresentadorPropuesta.CerrarTD;
            }
            propuesta += RecursosPresentadorPropuesta.AbrirTD + laPropuesta.Costo + RecursosPresentadorPropuesta.CerrarTD;
        }
    }
}
