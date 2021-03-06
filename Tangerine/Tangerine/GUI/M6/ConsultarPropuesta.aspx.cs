﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using Tangerine_Contratos.M6;
using Tangerine_Presentador.M6;
using System.Diagnostics;

namespace Tangerine.GUI.M6
{
    public partial class ConsultarPropuesta : System.Web.UI.Page, IContratoConsultarPropuesta
    {
        PresentadorConsultarPropuesta presentadorConsultar;


        /// <summary>
        /// Constructor de la vista
        /// </summary>
        public ConsultarPropuesta()
        {
            this.presentadorConsultar = new PresentadorConsultarPropuesta(this);
        }


        public Literal Tabla
        {
            get
            {
                return tablaP;
            }
            set
            {
                tablaP = value;
            }
        }

        /// <summary>
        /// Carga inicial de la pagina
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try {
                    presentadorConsultar.consultarPropuestas();
                }
                catch (Exception ex)
                {
                    Response.Redirect("../M1/Dashboard.aspx");
                }
            }
        }
        
     
    }
}