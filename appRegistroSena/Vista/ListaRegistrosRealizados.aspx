<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Administrador.Master" AutoEventWireup="true" CodeBehind="ListaRegistrosRealizados.aspx.cs" Inherits="appRegistroSena.Vista.ListaRegistrosRealizados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/Estilos_DataTables.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="JavaScript/jquery-3.6.0.js"></script>
    <script src="JavaScript/datatables.js"></script>
    <script src="JavaScript/bootstrap.bundle.js"></script>
    <script src="JavaScript/bootstrap.min.js"></script>
    <script src="SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="SweetAlert/Styles/sweetalert.css" rel="stylesheet" />
    <link href="css/Input.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="form1" runat="server">
        <div class="container my-2" style="margin-left: 380px; width: 40%;">
            <div class="row flex-shrink-1" style="margin-top: 50px;">
                <table id="DataTableRegistros" class="table table-striped">
                    <thead>
                        <tr>
                            <th>Codigo</th>
                            <th>Documento</th>
                            <th>Nombre Personal</th>
                            <th>Tipo Vehiculo</th>
                            <th>Nombre Objeto</th>
                            <th>Nombre Guarda</th>
                            <th>Porteria</th>
                            <th>Hora Ingreso</th>
                            <th>Fecha Ingreso</th>
                            <th>Opc</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
        </div>
    </div>


    <asp:TextBox ID="txtDato" runat="server" Style="color: #031529; background: #031529; border: none;"></asp:TextBox>

    <div class="modal fade" id="staticBackdrop" tabindex="-1" role="dialog" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="staticBackdropLabel">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                     <asp:Label ID="lblEstado" CssClass="form__input" runat="server" Text="Estado: "></asp:Label>
                        <asp:TextBox ID="txtEstado" CssClass="form__input" runat="server"></asp:TextBox>
                        <asp:Label ID="lblObservacion" CssClass="form__input" runat="server" Text="Observaciones: "></asp:Label>
                        <asp:TextBox ID="txtObservacion" CssClass="form__input" runat="server" TextMode="MultiLine" style="height:100px;"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnActualizar" class="btn btn-primary" runat="server" Text="Dar Salida" OnClick="btnActualizar_Click" />

                </div>
            </div>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            table = $('#DataTableRegistros').DataTable({
                data: jsonData,
                columns: [
                    { data: 'codigo' },
                    { data: 'documento' },
                    { data: 'NombrePersonal' },
                    { data: 'tipoVehiculo' },
                    { data: 'nombre' },
                    { data: 'NombreUsuario' },
                    { data: 'nombrePorteria' },
                    { data: 'horaIngreso' },
                    { data: 'fechaIngreso' },
                    {
                        "data": null,
                        render: function (data, type, row) {
                            return '<button type="button" id="btncargar" class="btn btn-update btn-primary" data-id="' + data.idRegistro + '" data-bs-toggle="modal" data-bs-target="#staticBackdrop"> Salida </button > ';
                        }
                    },

                ]


            })
            $('#DataTableRegistros').on('click', '#btncargar', function () {
                id = $(this).data('id');
                document.getElementById('<%= txtDato.ClientID %>').value = id;
                cargardatos(id);
            })

        })
        function cargardatos(idRegistro) {
            $.ajax({
                type: "POST",
                url: "ListaRegistrosRealizados.aspx/cargardatos",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ idRegistro: idRegistro }),
                success: function (dat) {
                    var Carga = dat.d;
                }, error: function (xhr, textStatus, errorThrown) {
                    // Manejar cualquier error que ocurra durante la llamada AJAX
                    console.error('No entra');
                }
            });
        }

    </script>

</asp:Content>
