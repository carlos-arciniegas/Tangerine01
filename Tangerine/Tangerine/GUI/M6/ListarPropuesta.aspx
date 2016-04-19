﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ListarPropuesta.aspx.cs" Inherits="Tangerine.GUI.M6.EjemploM6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Propuestas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    listado de propuestas
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Propuestas</a></li>
    <li class="active">listado de propuestas</li>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="box">
        <div class="box-header">
            <h3 class="box-title">Propuestas</h3>

            
        </div>

        <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Detalle Propuesta </h4>
                    </div>
                    <div class="modal-body">
                       
                        <div class="box box-primary">
                <div class="box-header with-border">
                  
                </div><!-- /.box-header -->
                <!-- form start -->
                
                  <div class="box-body">

                    <div class="form-group">
                      <label for="labelNumeroFactura_M8">Numero de Referencia</label>
                      <input type="text" class="form-control" id="textNumeroFactura_M8"  disabled="disabled">
                    </div>

                    <div class="form-group">
                      <label for="labelFecha_M8">Fecha de registro</label>
                        <div class="input-group date">
                  <div class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                  </div>
                  <input type="text" class="form-control pull-right" id="datepicker" disabled="disabled">
                </div>
                     
                    </div>

                      <div class="form-group">
                      <label for="labelCompañia_M8">Compañía</label>
                      <input type="text" class="form-control" id="textCompañia_M8" placeholder="Compañía" disabled="disabled">
                    </div>

                        <div class="form-group">
                      <label for="labelProyecto_M8">Proyecto</label>
                      <input type="text" class="form-control" id="textProyecto_M8" placeholder="Proyecto" disabled="disabled">
                    </div>

                      
                        <div class="form-group">
                      <label for="labelMonto_M8">Monto</label>
                      <input type="text" class="form-control" id="textMonto_M8" placeholder="Monto" disabled="disabled">
                    </div>




                  </div><!-- /.box-body -->

                
              </div>



                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                        
                    </div>
                </div>
            </div>
        </div>
        <!-- /.box-header -->
        <div class="box-body table-responsive no-padding">
            <table id="listar" class="table table-bordered table-striped dataTable">
                 <thead>
                    <tr>
                        <th>N° Referencia</th>
                        <th>Cliente</th>
                        <th>Fecha Modificacion</th>
                        <th>Estatus</th>
                        <th>Descripcion</th>
                        <th>Moneda/Pago</th>
                        <th style="text-align: center;">Acciones</th>
                    </tr>
                  </thead>
                <tbody>
                    <tr>
                        <td>TRSC012016</td>
                        <td>Trascend</td>
                        <td>13-04-2016</td>
                        <td><span class="label label-success">Aprobado</span></td>
                        <td>Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.</td>
                        <th style="text-align: center;"><a class="glyphicon glyphicon-euro"></a></th>
                        <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a><a class="btn btn-default glyphicon glyphicon-edit" href="ModificarPropuesta.aspx"></a><a class="btn btn-danger glyphicon glyphicon-remove-circle" data-target="#myModal"></a></th>
                    </tr>
                    <tr>
                        <td>PPSI022016</td>
                        <td>Pepsi</td>
                        <td>13-04-2016</td>
                        <td><span class="label label-warning">En ejecucion</span></td>
                        <td>Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.</td>
                        <th style="text-align: center;"><a class="glyphicon glyphicon-usd"></a></th>
                        <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign"></a><a class="btn btn-default glyphicon glyphicon-edit" href="ModificarContacto.aspx"></a><a class="btn btn-danger glyphicon glyphicon-remove-circle"></a></th>
                    </tr>
                    <tr>
                        <td>GGLE012016</td>
                        <td>Google</td>
                        <td>13-04-2016</td>
                        <td><span class="label label-warning">En ejecucion</span></td>
                        <td>Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.</td>
                        <th style="text-align: center;"><a class="glyphicon glyphicon-bitcoin"></a></th>
                        <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign"></a><a class="btn btn-default glyphicon glyphicon-edit" href="ModificarContacto.aspx"></a><a class="btn btn-danger glyphicon glyphicon-remove-circle"></a></th>
                    </tr>
                    <tr>
                        <td>TBCA012016</td>
                        <td>Tebca</td>
                        <td>13-04-2016</td>
                        <td><span class="label label-danger">Cerrado</span></td>
                        <td>Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.</td>
                        <th style="text-align: center;"><a class="glyphicon glyphicon-usd"></a></th>
                        <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign"></a><a class="btn btn-default glyphicon glyphicon-edit" href="ModificarContacto.aspx"></a><a class="btn btn-danger glyphicon glyphicon-remove-circle"></a></th>
                    </tr>
                </tbody>
            </table>
        </div>
        <!-- /.box-body -->
    </div>
    <!-- /.box -->

     <script type="text/javascript">
         $(document).ready(function () {

             var table = $('#listar').DataTable({
                 "language": {
                     "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                 }
             });
             var req;
             var tr;

             $('#listar tbody').on('click', 'a', function () {
                 if ($(this).parent().hasClass('selected')) {
                     req = $(this).parent().prev().prev().prev().prev().text();
                     tr = $(this).parents('tr');//se guarda la fila seleccionada
                     $(this).parent().removeClass('selected');

                 }
                 else {
                     req = $(this).parent().prev().prev().prev().prev().text();
                     tr = $(this).parents('tr');//se guarda la fila seleccionada
                     table.$('tr.selected').removeClass('selected');
                     $(this).parent().addClass('selected');
                 }
             });



             $('#modal-delete').on('show.bs.modal', function (event) {
                 var modal = $(this)
                 modal.find('.modal-title').text('Eliminar requerimiento:  ' + req)
                 modal.find('#req').text(req)
             })
             $('#btn-eliminar').on('click', function () {
                 table.row(tr).remove().draw();//se elimina la fila de la tabla
                 $('#modal-delete').modal('hide');//se esconde el modal
             });


         });

         </script>


</asp:Content>
