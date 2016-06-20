﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tangerine_Contratos.M3;
using Tangerine_Presentador.M3;


namespace Tangerine.GUI.M3
{
    public partial class ModificarLead : System.Web.UI.Page, IContratoModificarClientePotencial
    {
        
        PresentadorModificarClientePotencial presentador;

        public ModificarLead() 
        {
            presentador = new PresentadorModificarClientePotencial(this);
        }

        #region Contrato
        public String NombreEtiqueta 
        {
            get 
            {
                return this.nombre.Value;
            }
            set 
            {
                this.nombre.Value = value;
            }
        }

        public String RifEtiqueta 
        {
            get 
            {
                return this.rif.Value;
            }
            set 
            {
                this.rif.Value = value;
            }
        }

        public String CorreoElectronico
        {
            get 
            {
                return this.correo.Value;
            }
            set 
            {
                this.correo.Value = value;
            }
        }

        public float PresupuestoInversion
        {
            get
            {
                return Convert.ToSingle(this.presupuesto.Value);
            }
            set
            {
                this.presupuesto.Value = value.ToString();
            }

        }

        public int NumeroLlamadas
        {
            get 
            {
                return Int32.Parse(this.numLlamadas.Value);
            }

            set
            {
                this.numLlamadas.Value = value.ToString();
            }
        }

        public int NumeroVisitas 
        {
            get
            {
                return Int32.Parse(this.visitas.Value);
            }
            set
            {
                this.visitas.Value = value.ToString();
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
             int idClip = int.Parse(Request.QueryString["idclp"]);
              if (!IsPostBack)
              {
                  presentador.Llenar(idClip);        
              }
          }


        protected void Modificar_Click(object sender, EventArgs e)
        {
            //Cuidado , recordar cambiar luego del this , el id que tenga la interfaz 

            // String nombre = this.idnombre.Value;

            /*int idClip = int.Parse(Request.QueryString["idclp"]);


            String nombre = this.nombre.Value;
            String rif = this.rif.Value;
            String email = this.email.Value;

            float presupuesto = float.Parse(this.presupuesto.Value.ToString());
            int llamadas = int.Parse(this.llamadas.Value.ToString());
            int visitas = int.Parse(this.visitas.Value.ToString());
            ClientePotencial nuevoCliente = new ClientePotencial(idClip,nombre,rif,email,presupuesto,llamadas,visitas);

            LogicaM3 logica = new LogicaM3();
            //logica.ModificarNuevoclientePotencial(logica.BuscarClientePotencial(idClip));
            logica.ModificarNuevoclientePotencial( nuevoCliente );
            Response.Redirect("Listar.aspx");
            */

           
   
        }
    
    
    
    
    }
    
}