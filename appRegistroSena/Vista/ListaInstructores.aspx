<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Administrador.Master" AutoEventWireup="true" CodeBehind="ListaInstructores.aspx.cs" Inherits="appRegistroSena.Vista.ListaInstructores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center">LISTADO INSTRUCTORES</h1>
    <style>
        .styled-table {
            margin: auto;
            border-collapse: separate;
            border-spacing: 0;
            border: 1px solid #81C784;
            border-radius: 15px;
            overflow: hidden;
            width: 90%;
            font-size: 16px;
        }

        .styled-header {
            padding: 12px;
            text-align: center;
            border-bottom: 1px solid #81C784;
            border-radius: 15px 15px 0 0;
        }

        .alternate-row {
            background-color: #A5D6A7;
        }

        .normal-row {
            background-color: #E8F5E9;
        }

        /* Estilos adicionales para los bordes redondeados de las filas */
        .styled-table tr:first-child td:first-child {
            border-top-left-radius: 10px;
        }

        .styled-table tr:first-child td:last-child {
            border-top-right-radius: 10px;
        }

        .styled-table tr:last-child td:first-child {
            border-bottom-left-radius: 10px;
        }

        .styled-table tr:last-child td:last-child {
            border-bottom-right-radius: 10px;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvInstructor" runat="server" DataKeyNames="idUsuario" AutoGenerateColumns="False" style="width: 70%; text-align:center; margin-left: 300px; margin-top: 102px;" CssClass="styled-table">
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
                </Columns>
            </asp:GridView>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
