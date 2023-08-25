<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Administrador.Master" AutoEventWireup="true" CodeBehind="ListarAprendices.aspx.cs" Inherits="appRegistroSena.Vista.ListarAprendices" %>
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
                        <h5 class="modal-title" id="editarModalLabel">Editar Registro</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>

                    <div class="modal-body">
                        <asp:TextBox ID="txtCodigo" runat="server" placeholder="Código" class="form-control mb-3 txt-codigo-registro"></asp:TextBox>
                        <asp:TextBox ID="txtEstado" runat="server" placeholder="Estado" class="form-control mb-3 txt-estado-registro"></asp:TextBox>
                        <asp:TextBox ID="txtFechaIngreso" runat="server" placeholder="Fecha Ingreso" class="form-control mb-3 txt-fechaIngreso-registro h-100"></asp:TextBox>
                        <asp:TextBox ID="txtHoraIngreso" runat="server" placeholder="Hora Ingreso" class="form-control mb-3 txt-horaIngreso-registro h-100"></asp:TextBox>
                        <asp:TextBox ID="txtFechaSalida" runat="server" placeHolder="Fecha Salida" class="form-control mb-3 txt-fechaSalida-registro"></asp:TextBox>
                        <asp:TextBox ID="txtHoraSalida" runat="server" placeHolder="Hora Salida" class="form-control mb-3 txt-horaSalida-registro"></asp:TextBox>
                        <asp:TextBox ID="txtDocumentoPerson" runat="server" placeHolder="Documento Personal" class="form-control mb-3 txt-documentoP-registro"></asp:TextBox>
                        <asp:TextBox ID="txtNombrePort" runat="server" placeHolder="Nombre Portero" class="form-control mb-3 txt-nombrePort-registro"></asp:TextBox>
                        <asp:TextBox ID="txtDocumentoUsua" runat="server" placeHolder="Documento Usuario" class="form-control mb-3 txt-documentoU-registro"></asp:TextBox>

                    </div>

                    <div class="modal-footer">
                        <%--<asp:Button id="btnActualizar" class="btn btn-primary" runat="server" Text="Actualizar" />--%>
                        <button id="btnActualizar" class="btn btn-primary" type="button">Actualizar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
