﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DominioTangerine;
using LogicaTangerine;
using Tangerine_Contratos.M6;
using Tangerine_Presentador.M6;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace Tangerine.GUI.M6
{
    public partial class ModificarPropuesta : System.Web.UI.Page, IContratoModificarPropuesta
    {
        PresentadorModificarPropuesta presenter;

        /// <summary>
        /// Constructor de la vista
        /// </summary>
        public ModificarPropuesta()
        {
            this.presenter = new PresentadorModificarPropuesta(this);
        }

        /// <summary>
        /// Carga inicial de la pagina
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    presenter.LlenarVista();
                } 
            }
            catch 
            {
                Response.Redirect("../M6/ConsultarPropuesta.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
           
        }

        /// <summary>
        /// Accion del boton a presionar "Modificar"
        /// </summary>
        protected void ModificarPropuesta_Click(object sender, EventArgs e)
        {
            try
            {
                presenter.ModificarPropuesta();
                Response.Redirect("../M6/ConsultarPropuesta.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD)
            {
                Response.Redirect("../M6/ConsultarPropuesta.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                Response.Redirect("../M6/ModificarPropuesta.aspx?id=" + Request.QueryString.Get("id") + "&idReq=0", false);
                Context.ApplicationInstance.CompleteRequest();
            }

        }

        #region Contrato
        public Literal Requerimientos
        {
            get
            {
                return requerimientos;
            }
            set
            {
                requerimientos = value;
            }
        }

        public string reqABorrar
        {
            get
            {
                try
                {
                    return Request.QueryString.Get("idReq");
                }
                catch (Exception e)
                {
                    Response.Redirect("../M6/ConsultarPropuesta.aspx");
                    return null;
                }
            }
        } 

        public string ContenedorCompania
        {
            get { return cliente_id.Value; }
            set { cliente_id.Value = value; }
        }

        public string IdCompania
        {
            get
            {
                return cliente_id.Value;
            }
        }

        public string IdPropuesta
        {
            get 
            {
                try
                {
                    return Request.QueryString.Get("id");
                }
                catch (Exception e)
                {
                    Response.Redirect("../M6/ConsultarPropuesta.aspx");
                    return null;
                }
            }
        }
        
        public string Descripcion
        {
            get { return descripcion.Value; }
            set { descripcion.Value = value; }

        }

        public string ComboDuracion
        {
            get { return comboDuracion.Value; }
            set { comboDuracion.Value = value; }
        }
        
        public string TextoDuracion
        {

            get { return textoDuracion.Value; }
            set { textoDuracion.Value = value; }
        }
        
        public string DatePickerUno
        {
            get { return datepicker1.Value; }
            set { datepicker1.Value = value; }
        }
        
        public string DatePickerDos
        {
            get { return datepicker2.Value; }
            set { datepicker2.Value = value; }
        }
        
        public string TipoCosto
        {
            get { return comboTipoCosto.Value; }
            set { comboTipoCosto.Value = value; }
        }

        public string TextoCosto
        {
            get { return textoCosto.Value; }
            set { textoCosto.Value = value; }
        }
        
        public string FormaPago
        {
            get { return formaPago.Value; }
            set { formaPago.Value = value; }
        }
        
        public string ComboCuota
        {
            get { return cantidadCuotas.Value; }
            set { cantidadCuotas.Value = value; }
        }
        
        public string ComboStatus
        {
            get { return comboEstatus.Value; }
            set { comboEstatus.Value = value; }
        }
        #endregion
    
    }
}