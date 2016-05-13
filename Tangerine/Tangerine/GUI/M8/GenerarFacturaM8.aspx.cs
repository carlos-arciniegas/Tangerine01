﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M8;

namespace Tangerine.GUI.M8
{
    public partial class GenerarFacturaM8 : System.Web.UI.Page
    {
        DateTime _fechaEmision = DateTime.Now;
        int _montoTotal = 0;
        int _montoRestante = 0;
        string _Descripcion = String.Empty;
        int _proyectoId = 0;
        int _companiaId = 0;

        protected void Page_Load( object sender, EventArgs e )
        {
            textFecha_M8.Value = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected void buttomGenerarFactura_Click( object sender, EventArgs e )
        {
             _montoTotal = int.Parse(textMonto_M8.Value);
            _fechaEmision = DateTime.Parse(textFecha_M8.Value);
            _montoRestante = int.Parse(textMonto_M8.Value);
            _Descripcion = textDescripcion_M8.Value;

            Facturacion factura = new Facturacion(_fechaEmision, _montoTotal, _montoRestante, _Descripcion, 1, 1 );
            LogicaM8 facturaLogic = new LogicaM8();
            facturaLogic.AddNewFactura(factura);

        }
    }
}