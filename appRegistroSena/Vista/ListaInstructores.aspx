<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Coordinador.Master" AutoEventWireup="true" CodeBehind="ListaInstructores.aspx.cs" Inherits="appRegistroSena.Vista.Lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="css/Estilos_RegistrarInstruc.css" rel="stylesheet" />
    <link href="css/BarraBusqueda.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h1 class="titulo-h1">LISTADO INSTRUCTORES</h1>
    <section>
        <div class="input-box">
            <i>
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
                    <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z" />
                </svg>
            </i>
            <input id="txtBusqueda" runat="server" type="text" placeholder="Buscar..." />
            <asp:Button ID="btnGuardar" class="button" runat="server" Text="Buscar" OnClick="Button1_Click" Style="width: 30%; height: 81%; right: 4px;" />
        </div>
    </section>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" style="margin-left: 190px;" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvInstructor" runat="server" DataKeyNames="idUsuario" AutoGenerateColumns="False" Style="width: 70%; text-align: center; margin-left: 300px; margin-top: 49px;" CssClass="styled-table">
                <HeaderStyle CssClass="styled-header" BackColor="#2E7D32" ForeColor="white" />
                <AlternatingRowStyle CssClass="alternate-row" BackColor="#A5D6A7" />
                <RowStyle CssClass="normal-row" BackColor="#E8F5E9" />
                <Columns>
                    <asp:BoundField DataField="idUsuario" HeaderText="ID de Usuario" Visible="false" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombres" />
                    <asp:BoundField DataField="apellido" HeaderText="Apellidos" />
                    <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="email" HeaderText="Correo Electrónico" />
                    <asp:BoundField DataField="documento" HeaderText="Documento" />
                    <asp:BoundField DataField="ficha" HeaderText="Ficha" />
                    <asp:BoundField DataField="programa" HeaderText="Programa" />
                    <asp:BoundField DataField="jornada" HeaderText="Jornada" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <asp:Button ID="btnImprimir" runat="server" CssClass="btn-imprimir" Text="Imprimir Reporte" Style="margin-left: 800px;" OnClick="btnImprimir_Click" />



    <style>
        .btn-imprimir {
            background-color: #2f852c;
            color: white;
            border: none;
            border-radius: 5px;
            padding: 8px 12px;
            cursor: pointer;
            display: flex;
            align-items: center;
        }

            .btn-imprimir i {
                margin-right: 6px;
            }

        .titulo-h1 {
            text-align: center;
            font-size: 36px;
            margin-bottom: 30px;
            color: #3e964a;
            text-transform: uppercase;
            letter-spacing: 2px;
            border-bottom: 3px solid #7bb06e;
            padding-bottom: 10px;
        }
    </style>

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
