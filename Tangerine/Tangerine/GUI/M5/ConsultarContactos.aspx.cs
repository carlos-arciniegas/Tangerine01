﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M5;

namespace Tangerine.GUI.M5
{
    public partial class ConsultarContactos : System.Web.UI.Page
    {
        public string contact
        {
            get
            {
                return this.tabla.Text;
            }
            set
            {
                this.tabla.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LogicaM5 prueba = new LogicaM5();

            if (!IsPostBack)
            {
                //Aqui ejecuto el filltable de la clase creada en logica para probar la conexion a la bd
                //los parametros son tipo de empresa 1 (Compania), id de la empresa 1.
                //prueba.fillTable(1,1);
                List<Contacto> listContact = prueba.fillTable(1,1);

                try
                {
                    foreach (Contacto theContact in listContact)
                    {
                        contact += ResourceGUIM5.AbrirTR;
                        contact += ResourceGUIM5.AbrirTD + theContact.Apellido.ToString() + ResourceGUIM5.Coma 
                            + theContact.Nombre.ToString() + ResourceGUIM5.CerrarTD;
                        contact += ResourceGUIM5.AbrirTD + theContact.Departamento.ToString() + ResourceGUIM5.CerrarTD;
                        contact += ResourceGUIM5.AbrirTD + theContact.Cargo.ToString() + ResourceGUIM5.CerrarTD;
                        contact += ResourceGUIM5.AbrirTD + theContact.Telefono.ToString() + ResourceGUIM5.CerrarTD;
                        contact += ResourceGUIM5.AbrirTD + theContact.Correo.ToString() + ResourceGUIM5.CerrarTD;
                        //Acciones de cada contacto
                        contact += ResourceGUIM5.AbrirTD;
                        contact += ResourceGUIM5.ButtonModContact + theContact.IdContacto + ResourceGUIM5.BotonCerrar 
                            + "<a style='margin-left:5px;' class='btn btn-danger glyphicon glyphicon-remove-circle'></a>";
                        contact += ResourceGUIM5.CerrarTD;
                        contact += ResourceGUIM5.CerrarTR;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            
        }
    }
}