﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using DatosTangerine;
using Tangerine_Presentador.M8;
using Tangerine_Contratos.M8;


namespace Tangerine.GUI.M8
{
    public partial class AnularFacturaM8 : System.Web.UI.Page, IContratoAnularFactura
    {
        #region contrato
        public string numero
        {
            get
            {
                return this.NumeroFactura.Text;
            }

            set
            {
                this.NumeroFactura.Text = value;
            }
        }

        public string fecha
        {
            get
            {
                return this.Fecha.Text;
            }

            set
            {
                this.Fecha.Text = value;
            }
        }

        public string compania
        {
            get
            {
                return this.Compania.Text;
            }

            set
            {
                this.Compania.Text = value;
            }
        }

        public string descripcion
        {
            get
            {
                return this.Descripcion.Text;
            }

            set
            {
                this.Descripcion.Text = value;
            }
        }

        public string proyecto
        {
            get
            {
                return this.Proyecto.Text;
            }

            set
            {
                this.Proyecto.Text = value;
            }
        }

        public string monto
        {
            get
            {
                return this.Monto.Text;
            }

            set
            {
                this.Monto.Text = value;
            }
        }

        public string moneda
        {
            get
            {
                return this.TipoMoneda.Text;
            }

            set
            {
                this.TipoMoneda.Text = value;
            }
        }

        public string alertaClase
        {
            set { alert.Attributes[ResourceGUIM8.alertClase] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes[ResourceGUIM8.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }

        DateTime _fechaEmision = DateTime.Now;

        DateTime _fechaUltimoPago = DateTime.Now;
        #endregion

        #region presentador
        PresentadorAnularFactura _presentador;

        public AnularFacturaM8()
        {
            _presentador = new PresentadorAnularFactura(this);
        }
        #endregion

        /// <summary>
        /// Carga la ventana AnularFactura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="idF">Representa el Id de la Entidad Factura</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try 
            { 
                this.numero = Request.QueryString[ResourceGUIM8.idF];
                if (!IsPostBack)
                {
                    _presentador.cargarFactura();                
                }  
            }
            catch
            {
                Response.Redirect(ResourceGUIM8.volver);
            }
        }

        /// <summary>
        /// Accion del Boton Anular, que va a anular la factura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonAnularFactura_Click(object sender, EventArgs e)
        {            
            if (_presentador.anularFactura())
            {
                Response.Redirect(ResourceGUIM8.volverAnular);
            }
            Server.Transfer(ResourceGUIM8.redirectHome);
        }
    }
}