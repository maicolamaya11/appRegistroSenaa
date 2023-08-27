<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Administrador.Master" AutoEventWireup="true" CodeBehind="ListaInstructores.aspx.cs" Inherits="appRegistroSena.Vista.ListaInstructores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="css/Estilos_DataTables.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="JavaScript/jquery-3.6.0.js"></script>
    <script src="JavaScript/tablaAprendices.js"></script>
    <script src="JavaScript/bootstrap.bundle.js"></script>
    <script src="JavaScript/bootstrap.min.js"></script>
    <script src="JavaScript/sweetalert-dev.js"></script>
    <link href="css/sweetalert.css" rel="stylesheet" />
    <script src="JavaScript/sweetalert.min.js"></script>
    <script src="JavaScript/datatables.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center">LISTADO INSTRUCTORES</h1>
   
     <div id="form1" runat="server">
        <div class="container my-2" style="margin-left: 380px; width: 40%;">
            <div class="row flex-shrink-1" style="margin-top: 50px;">
                <table id="DataTableRegistros" class="table table-striped">
                    <thead>
                        <tr>
                            <th>nombres</th>
                            <th>apellidos</th>
                            <th>documento</th>
                            <th>programa</th>       
                            <th>rol</th>                                  
                            <th>Opc</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
        </div>

        <div class="modal fade venmodal" id="editarModal" tabindex="-1" role="dialog" aria-labelledby="editarModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="editarModalLabel">Editar Registro de Aprendiz</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>

            <div class="modal-body">
                <asp:TextBox ID="txtNombre" runat="server" placeholder="Código" class="form-control mb-3 txt-nombres-personal"></asp:TextBox>
                <asp:TextBox ID="txtApellido" runat="server" placeholder="Estado" class="form-control mb-3 txt-apellidos-personal"></asp:TextBox>
                <asp:TextBox ID="txtDocumentos" runat="server" placeholder="Fecha Ingreso" class="form-control mb-3 txt-documento-personal h-100"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text="Programa"></asp:Label>
                <asp:DropDownList ID="ddlPrograma" runat="server" class="form-control mb-3 txt-programa-personal h-100"></asp:DropDownList>
                <%--<asp:TextBox ID="txtPrograma" runat="server" placeholder="Hora Ingreso" class="form-control mb-3 txt-programa-personal h-100"></asp:TextBox>--%>
               <%-- <asp:TextBox ID="txtRol" runat="server" placeHolder="Fecha Salida" class="form-control mb-3 txt-rol-personal"></asp:TextBox>--%>
            </div>

            <div class="modal-footer">
                <button id="btnActualizar" class="btn btn-primary" type="button">Actualizar</button>
            </div>
        </div>
    </div>
</div>

<script>
    $('#DataTableRegistros').on('click', '.btnEditar', function (e) {
        e.preventDefault();
        var rowData = $('#DataTableRegistros').DataTable().row($(this).closest('tr')).data();
        var idPer = rowData.idPersonal;

        $.ajax({
            url: "ListarAprendices.aspx/mtdCargarDatos",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ idPersonal: idPer }),
            success: function (Data) {
                var datosProducto = Data.d;

                $('#<%= txtNombre.ClientID %>').val(datosProducto[0]["nombres"]);
                $('#<%= txtApellido.ClientID %>').val(datosProducto[0]["apellidos"]);
                $('#<%= txtDocumentos.ClientID %>').val(datosProducto[0]["documento"]);
                $('#<%= ddlPrograma.ClientID %>').val(datosProducto[0]["idPrograma"]);
              <%--  $('#<%= txtRol.ClientID %>').val(datosProducto[0]["rol"]);--%>

                $('#editarModal').modal('show');
            },
            error: function (error) {
                console.log(error);
            }
        });
    });
</script>
          <script>
              $('#btnActualizar').on('click', function (e) {
                  e.preventDefault();

                  var idPersonal = idPer;
                  var nombres = $('.txt-nombres-personal').val();
                  var apellidos = $('.txt-apellidos-personal').val();
                  var documento = $('.txt-documento-personal').val();
                  var idPrograma = $('.txt-programa-personal').val();


                  var DatosActualizados = {
                      idPersonal: idPersonal,
                      nombres: nombres,
                      apellidos: apellidos,
                      documento: documento,
                      idPrograma: idPrograma,
                  };
                  // Realiza la petición Ajax
                  $.ajax({
                      url: "ListarAprendices.aspx/mtdActualizarAprendiz",
                      type: "POST",
                      data: JSON.stringify({ data: DatosActualizados }),
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      success: function (response) {

                          recargarTabla();
                          swal("¡Éxito!", "Los datos se actualizaron correctamente.", "success");
                          $('#editarModal').modal('hide'); // Cierra la ventana modal
                      },
                      error: function (error) {
                          console.log(error);
                      }

                  });
              });
              function recargarTabla() {
                  $.ajax({
                      url: "ListarAprendices.aspx/mtdListar",
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      success: function (response) {
                          listaPersonal = response.d;
                          // Limpiar los datos actuales de la tabla
                          table.clear();
                          // Agregar los nuevos datos a la tabla
                          table.rows.add(listaPersonal);
                          // Dibujar la tabla con los datos actualizados
                          table.draw();

                          console.log(listaPersonal);
                      },
                      error: function (error) {
                          console.log(error);
                      }
                  });

              }
          </script>
    </div>
</asp:Content>
