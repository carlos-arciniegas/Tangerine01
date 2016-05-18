﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using DatosTangerine.M8;
using LogicaTangerine.M8;


namespace Tangerine.GUI.M8
{
    public partial class AnularFacturaM8 : System.Web.UI.Page
    {
        int _numeroFactura = 0;
        DateTime _fechaEmision = DateTime.Now;
        DateTime _fechaUltimoPago = DateTime.Now;
        int _montoTotal = 0;
        int _montoRestante = 0;
        string _descripcion = String.Empty;
        int _estatus = 0;
        int _proyectoId = 0;
        int _companiaId = 0;
        public static Facturacion theFactura = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            int idFac = int.Parse(Request.QueryString["idCont"]);
            if (!IsPostBack)
            {
                LogicaM8 facturaLogic = new LogicaM8();
                theFactura = facturaLogic.SearchFactura(idFac);

                this.textNumeroFactura_M8.Value = theFactura.idFactura.ToString();
                this.textFecha_M8.Value = theFactura.fechaFactura.ToString("dd/MM/yyyy");
                this.textDescripcion_M8.Value = theFactura.descripcionFactura;
                Compania compania = facturaLogic.SearchCompaniaFactura(int.Parse(theFactura.idCompaniaFactura.ToString()));
                this.textCliente_M8.Value = compania.NombreCompania;
                Proyecto proyecto = facturaLogic.SearchProyectoFactura(int.Parse(theFactura.idProyectoFactura.ToString()));
                this.textProyecto_M8.Value = proyecto.Nombre;
                this.textMonto_M8.Value = theFactura.montoFactura.ToString();
                //this._montoRestante.Value = theFactura.montoRestanteFactura.ToString();
            }  
        }

        protected void buttonAnularFactura_Click(object sender, EventArgs e)
        {
            //EMPIEZA AQUI!


            //
            Server.Transfer("ConsultarFacturaM8.aspx");
        }
    }
}