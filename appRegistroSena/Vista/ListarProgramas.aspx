<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Administrador.Master" AutoEventWireup="true" CodeBehind="ListarProgramas.aspx.cs" Inherits="appRegistroSena.Vista.ListarProgramas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Estilos_DataTables.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="JavaScript/jquery-3.6.0.js"></script>
    <script src="JavaScript/datatables.js"></script>
    <script src="JavaScript/bootstrap.bundle.js"></script>
    <script src="JavaScript/bootstrap.min.js"></script>
    <script src="JavaScript/DataTablePrograma.js"></script>
    <script src="SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="SweetAlert/Styles/sweetalert.css" rel="stylesheet" />   
    <link href="css/Input.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="form1" runat="server">
        <div class="container my-2" style="margin-left: 380px; width: 40%;">
            <div class="row flex-shrink-1" style="margin-top: 50px;">
                <table id="DataTablePrograma" class="table table-striped">
                    <thead>
                        <tr>
                            <th>Programa</th>
                            <th>Ficha</th>
                            <th>Jornada</th>
                            <th>Opciones</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
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
                        <asp:Label ID="lblPrograma" CssClass="form__input" runat="server" Text="Programa: "></asp:Label>
                        <asp:TextBox ID="txtPrograma" CssClass="form__input" runat="server"></asp:TextBox>
                        <asp:Label ID="lblFicha" CssClass="form__input" runat="server" Text="Ficha: "></asp:Label>
                        <asp:TextBox ID="txtFicha" CssClass="form__input" runat="server"></asp:TextBox>
                        <asp:Label ID="lblJornada" CssClass="form__input" runat="server" Text="Jornada: "></asp:Label>
                        <asp:TextBox ID="txtJornada" CssClass="form__input" runat="server"></asp:TextBox>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnActualizar" class="btn btn-primary" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                        <asp:Button ID="btnEliminar" class="btn btn-danger" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            table = $('#DataTablePrograma').DataTable({
                data: jsonData,
                columns: [
                    { data: 'programa' },
                    { data: 'ficha' },
                    { data: 'jornada' },
                    {
                        "data": null,
                        render: function (data, type, row) {
                            return '<button type="button" id="btncargar" class="btn btn-update btn-primary" data-id="' + data.idPrograma + '" data-bs-toggle="modal" data-bs-target="#staticBackdrop"> Editar </button > ';
                        }
                    },
                ]
            });
            $('#DataTablePrograma').on('click', '#btncargar', function () {
                id = $(this).data('id');
                document.getElementById('<%= txtDato.ClientID %>').value = id;
                cargardatos(id);
            })
        });


        function cargardatos(idPrograma) {
            $.ajax({
                type: "POST",
                url: "ListarProgramas.aspx/cargardatos",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ idProgramas: idPrograma }),
                success: function (dat) {
                    var Carga = dat.d;
                    document.getElementById('<%= txtPrograma.ClientID %>').value = Carga[0]["programa"];
                    document.getElementById('<%= txtFicha.ClientID %>').value = Carga[0]["ficha"];
                    document.getElementById('<%= txtJornada.ClientID %>').value = Carga[0]["jornada"];
                }, error: function (xhr, textStatus, errorThrown) {
                    // Manejar cualquier error que ocurra durante la llamada AJAX
                    console.error('No entra');
                }
            });
        }


    </script>
</asp:Content>
