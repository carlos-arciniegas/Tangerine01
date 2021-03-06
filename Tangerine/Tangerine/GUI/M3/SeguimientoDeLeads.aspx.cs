﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tangerine_Contratos.M3;
using Tangerine_Presentador.M3;
using System.Web.Security.AntiXss;

namespace Tangerine.GUI.M3
{
    public partial class SeguimientoDeLeads : System.Web.UI.Page, IContratoHistoriaClientePotencial
    {
        PresentadorHistorialDeSeguimiento presentador;
        int idClientePotencial;

        /// <summary>
        /// Constructor de la vista
        /// </summary>
        public SeguimientoDeLeads()
        {
            presentador = new PresentadorHistorialDeSeguimiento(this);
        }

        #region Contrato
        public Literal NombreEtiqueta 
        {
            get 
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public Literal RIFEtiqueta 
        {
            get
            {
                return this.rif;
            }
            set
            {
                this.rif = value;
            }
        }

        public Literal EstatusEtiqueta
        {
            get
            {
                return this.estatus;
            }
            set
            {
                this.estatus = value;
            }
        }

        public Literal CorreoEtiqueta
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public Literal PresupuestoInicialEtiqueta
        {
            get 
            {
                return this.presupuesto;
            }
            set
            {
                this.presupuesto = value;
            }
        }
        public Literal SegumientoLLamadas
        {
            get
            {
                return this.ListaLlamadas;
            }
            set
            {
                this.ListaLlamadas = value;
            }
        }

        public Literal SeguimientoVisitas
        {
            get
            {
                return this.ListaVisitas;
            }
            set
            {
                this.ListaVisitas = value;
            }
        }

        public Literal NumLlamadasEtiqueta
        {
            get
            {
                return this.llamadas;
            }
            set 
            {
                this.llamadas = value;
            }
        }

        public Literal NumVisitasEtiqueta
        {
            get
            {
                return this.visitas;
            }
            set
            {
                this.visitas = value;
            }
        }
        #endregion

        /// <summary>
        /// Método que carga la vista y muestra los datos del cliente e historico
        /// de llama y visitas
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                idClientePotencial = int.Parse(AntiXssEncoder.HtmlEncode(Request.QueryString["idclp"], false));
                if (!IsPostBack)
                {
                    presentador.Llenar(idClientePotencial);
                    presentador.ObtenerHistoricoLlamadas(idClientePotencial);
                    presentador.ObtenerHistoricoVisitas(idClientePotencial);
                }
            }
            catch
            {
                Response.Redirect(ResourceInterfaz.Dashboard);
            }
            
        }
    }
}