<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Coordinador.Master" AutoEventWireup="true" CodeBehind="ListarProgramasCoor.aspx.cs" Inherits="appRegistroSena.Vista.ListarProgramasCoor" %>

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
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
        </div>
    </div>
    <asp:TextBox ID="txtDato" runat="server" Style="color: #031529; background: #031529; border: none;"></asp:TextBox>

    <script>
        $(document).ready(function () {
            table = $('#DataTablePrograma').DataTable({
                data: jsonData,
                columns: [
                    { data: 'programa' },
                    { data: 'ficha' },
                    { data: 'jornada' }
                ]
            });

        });

    </script>
</asp:Content>
