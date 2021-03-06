﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ModificarCompania.aspx.cs" Inherits="Tangerine.GUI.M4.ModificarCompania" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Compañias
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Modificar
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Compañias</a></li>
    <li class="active">Modificar</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="alert" runat="server">
    </div>
    <div class="row">
            <!-- left column -->
            <div class="col-md-6">
              <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Datos de la Compañía</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <form role="form" name="modificar_compania" id="modificar_compania" method="post" runat="server">
                    <div class="box-body" runat="server">
                        <!--Nombre-->
                        <div class="form-group" runat="server">
                            <label for="InputNombre">Nombre</label> <label for="Requerido" style="color: red;">*</label>
                            <input runat="server" type="text" class="form-control" id="InputNombre1" name="InputNombre1" 
                                placeholder="Introduzca nombre de la compañía" maxlength="50" oninput="setCustomValidity('')" pattern="^[a-zA-Z0-9_.-]*$" required oninvalid="setCustomValidity('Campo inválido o vacío')">
                        </div>
                        <!--Acronimo-->
                        <div class="form-group" runat="server">
                            <label for="InputAcronimo">Acrónimo (opcional)</label>
                            <input runat="server" type="text" class="form-control" id="InputAcronimo1" name="InputAcronimo1" 
                                placeholder="Introduzca acrónimo de la compañía" maxlength="10" oninput="setCustomValidity('')" pattern="^[a-zA-Z0-9_.-]*$" oninvalid="setCustomValidity('Campo inválido o vacío')">
                        </div>
                        <!--RIF-->
                        <div class="form-group" runat="server">
                            <label for="InputRIF">RIF</label> <label for="Requerido" style="color: red;">*</label>
                            <input runat="server" type="text" class="form-control" 
                                pattern="^(\J\-[0-9]{9,13})$"
                                id="InputRIF1" name="InputRIF1" 
                                placeholder="Introduzca RIF de la compañía.    e.g: J-236861976" required>
                        </div>
                        <!--Direccion-->
                        <div class="form-group" runat="server">
                            <label for="InputLugar">Dirección</label> <label for="Requerido" style="color: red;">*</label>
                            <asp:DropDownList runat="server" class="form-control" id="InputDireccion1" name="InputDireccion1"></asp:DropDownList>
                        </div>
                        <!--Email-->
                        <div class="form-group" runat="server">
                            <label for="InputEmail">Correo Electrónico</label> <label for="Requerido" style="color: red;">*</label>
                            <input runat="server" type="email" class="form-control"
                                id="InputEmail1" name="InputEmail1" 
                                placeholder="Introduzca email de la compañía.    e.g: mail@ejemplo.com" maxlength="50" required/>
                        </div>
                        <!--Telefono-->
                        <div class="form-group" runat="server">
                            <label for="InputTelefono">Teléfono</label> <label for="Requerido" style="color: red;">*</label>
                            <input runat="server" type="text" class="form-control" 
                                id="InputTelefono1" name="InputTelefono1"
                                pattern="^([0-9]{4}\-[0-9]{7})?(\+[0-9]{1,2}\ [0-9]{3}\-[0-9]{7})?$" 
                                placeholder="Introduzca teléfono de la compañía     e.g: 0212-9774183" 
                                maxlength="15" required>
                        </div>
                        <!--Fecha Registro-->
                        <div class="form-group col-md-11" style="margin-left:-14px;" runat="server" >
                            <label for="InputFechaRegistro">Fecha de Registro</label> <label for="Requerido" style="color: red;">*</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </div>
                                <input class="form-control pull-right" id="datepicker1" type="text" runat="server" disabled="disabled" 
                                    clientidmode="static" required>
                            </div>
                        </div>
                        <!--Presupuesto-->
                        <div class="form-group" runat="server">
                            <label for="InputPresupuesto">Presupuesto Anual</label> <label for="Requerido" style="color: red;">*</label>
                            <input runat="server" type="number" class="form-control" 
                                id="InputPresupuesto1" name="InputPresupuesto1" 
                                placeholder="Introduzca el presupuesto anual de la Compañía" maxlength="10">
                        </div>
                        <!--Plazo de Pagos-->
                        <div class="form-group" runat="server">
                            <label for="InputPlazoPago">Plazo de Pagos (días)</label> <label for="Requerido" style="color: red;">*</label>
                            <input runat="server" type="number" class="form-control" id="InputPlazoPago1" name="InputPlazoPago1" 
                                placeholder="Introduzca el plazo para los pagos de la compañía" maxlength="4" required>
                        </div>
                     </div><!-- /.box-body -->

                    <div class="box-footer">
                        <asp:Button id="btnmodificar" class="btn btn-primary" OnClick="btnmodificar_Click" type="submit" 
                            runat="server" Text = "Modificar"></asp:Button>
                        <a class="btn btn-default" href="ConsultarCompania.aspx" style="margin-left: 3px"  >Regresar</a>

                    </div>
                </form>
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
          </div>
</asp:Content>
