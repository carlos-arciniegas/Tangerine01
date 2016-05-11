﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ModificarFacturaM8.aspx.cs" Inherits="Tangerine.GUI.M8.ModificarFacturaM8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Facturación
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Factura
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestion Factura</a></li>
    <li class="active">Factura</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
            <!-- left column -->
            <div class="col-md-6"  runat ="server">
              <!-- general form elements -->
              <div class="box box-primary"  runat ="server">
                <div class="box-header with-border"  runat ="server">
                  <h3 class="box-title">Modificar Factura</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <form role="form"  runat ="server">
                  <div class="box-body"  runat ="server">

                    <div class="form-group"  runat ="server">
                      <label for="labelNumeroFactura_M8">Número Factura</label>
                      <select class="form-control" name="op1" disabled ="disabled"> 
                     <option>Numero</option>
                     <option>No Aplica</option>
                    </select>
                    
                    </div>

                    <div class="form-group"  runat ="server">
                      <label for="labelFecha_M8">Fecha</label>
                      <input type="date" class="form-control" id="textFecha_M8" placeholder="Fecha" disabled ="disabled">
                    </div>

                      <div class="form-group"  runat ="server">
                      <label for="labelCliente_M8">Cliente</label>
                      <input type="text" class="form-control" id="textCliente_M8" placeholder="Cliente" disabled ="disabled" >
                    </div>

                        <div class="form-group"  runat ="server">
                      <label for="labelProyecto_M8">Proyecto</label>
                      <input type="text" class="form-control" id="textProyecto_M8" placeholder="Proyecto" disabled ="disabled" >
                    </div>

                        <div class="form-group"  runat ="server">
                      <label for="labelDescripcion_M8">Descripción</label>
                      <input type="text" class="form-control" id="textDescripcion_M8" placeholder="Descripción">
                    </div>

                      
                        <div class="form-group"  runat ="server">
                      <label for="labelMonto_M8">Monto</label>
                      <input type="text" class="form-control" id="textMonto_M8" placeholder="Monto" disabled ="disabled" >
                    </div>

                       <div class="box-footer" runat ="server">
                    <asp:Button id="buttomModificar_M8" style="margin-top:5%" class="btn btn-primary"  type="submit" runat="server" Text = "Modificar"   ></asp:Button>
                  </div>

                  </div><!-- /.box-body -->

                 
                </form>
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
            <!-- right column -->
            <div class="col-md-6">
      
          </div>
</asp:Content>
