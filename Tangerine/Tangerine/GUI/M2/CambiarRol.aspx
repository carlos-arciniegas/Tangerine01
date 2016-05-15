﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="CambiarRol.aspx.cs" Inherits="Tangerine.GUI.M2.CambiarRol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Modificacion de rol de Usuario
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Ejemplo</a></li>
    <li class="active">Página en blanco</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function showContent(nick,rol) {
            
            element2 = document.getElementById("usuarioCambiar");
            element2.placeholder = nick;

        }
        function hideContent() {

        }
    </script>
    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" >
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Selecciona el rol para el usuario</h4>
                </div>
                <div class="modal-body">  
                    <div class="box-body">     
                        <div class="form-group">
                            <label for="usuarioCambiar" class="col-sm-2 control-label">Usuario</label>
                            <div class="col-sm-10">
                                <input type="email" class="form-control" id="usuarioCambiar" placeholder="" runat="server" disabled>
                            </div>
                        </div>
                        <p>&nbsp;</p>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Rol</label>
                            <div class="col-sm-10">
                                <select class="form-control" id="rolCambiar" runat="server">
                                    <option>Administrador</option>
                                    <option>Director</option>
                                    <option>Gerente</option>
                                    <option>Programador</option>
                                </select>
                            </div>
                        </div>
                    </div><!-- /.box-body -->
                    <div class="box-footer">
                        <button id="botonCancelar" type="button" class="btn btn-default pull-left" data-dismiss="modal">Cancelar</button>
                        <button id="botonCambiar" type="button" class="btn btn-primary pull-right" data-dismiss="modal" OnClick="botonCambiar_Click">Cambiar</button>
                    </div><!-- /.box-footer -->
                </div>
            </div>
        </div>
    </div>
    
     <!-- Modal Cambiar Rol -->
    <div class="modal fade" id="myModalC" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" >
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabelC">Selecciona el rol para el usuario</h4>
                </div>


                <div class="modal-body">  
                    <div class="box-body">     
                    <div class="well">
                        <asp:Literal runat="server" ID="CamRol"></asp:Literal>
                    </div>
                    </div><!-- /.box-body -->
                    <div class="box-footer">
                        <button id="botonCancelar2" type="button" class="btn btn-default pull-left" data-dismiss="modal">Cancelar</button>
                        <button id="botonCambiar2" type="button" class="btn btn-primary pull-right" data-dismiss="modal" OnClick="botonCambiar_Click">Cambiar</button>
                    </div><!-- /.box-footer -->
                </div>
            </div>
        </div>
    </div>
    






    <div class="container-fluid">
        <div class="box box-info">
            <!--<div class="panel-heading">Filtrar empleados</div>-->
            <div class="box-header with-border">
                <h3 class="box-title">Lista de empleados sin cuenta de usuario</h3>
                <div class="box-tools">
                <div class="input-group input-group-sm" style="width: 150px;">
                    <input name="table_search" class="form-control pull-right" placeholder="Search" type="text">

                    <div class="input-group-btn">
                        <button type="submit" class="btn btn-default"><i class="fa fa-search"></i></button>
                    </div>
                </div>
            </div>

            </div><!-- /.box-header -->
            <div class="box-body">
                <div class="table-responsive">
                    <table class="table no-margin">
                        <thead>
                            <tr>
                                <th>Nombres</th>
                                <th>Apellidos</th>
                                <th>Usuario</th>
                                <th>Rol</th>
                                <th></th>
                            </tr>
                        </thead>
                        <asp:Literal runat="server" ID="tablaempleados"></asp:Literal>
                        <tbody>
     
                        </tbody>
                        </table>
                    <nav>
                        <ul class="pagination">
                            <li>
                                <a href="#" aria-label="Previous">
                                    <span aria-hidden="true">&laquo;</span>
                                </a>
                            </li>
                            <li><a href="#">1</a></li>
                            <li><a href="#">2</a></li>
                            <li><a href="#">3</a></li>
                            <li><a href="#">4</a></li>
                            <li><a href="#">5</a></li>
                            <li>
                                <a href="#" aria-label="Next">
                                    <span aria-hidden="true">&raquo;</span>
                                </a>
                            </li>
                        </ul>
                    </nav>
                </div><!-- /.table-responsive -->
            </div>
        </div>
    </div>
</asp:Content>