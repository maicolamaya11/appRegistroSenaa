<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Coordinador.Master" AutoEventWireup="true" CodeBehind="ListaProgramas.aspx.cs" Inherits="appRegistroSena.Vista.ListaProgramas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Estilos_RegistrarInstruc.css" rel="stylesheet" />
    <link href="css/BarraBusqueda.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h1 class="titulo-h1">LISTADO PROGRAMAS</h1>
    <section>
        <div class="input-box" style="margin-left:800px">
            <i>
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
                    <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z" />
                </svg>
            </i>
            <input id="txtBusqueda" runat="server" type="text" placeholder="Buscar..." />
            <asp:Button ID="btnGuardar" class="button" runat="server" Text="Buscar" Style="width: 30%; height: 81%; right: 4px;" OnClick="btnGuardar_Click2"/>
        </div>
    </section>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" style="margin-left: 190px;" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvProgramas" runat="server" DataKeyNames="idPrograma" AutoGenerateColumns="False" Style="width: 70%; text-align: center; margin-left: 190px; margin-top: 49px;" CssClass="styled-table">
                <HeaderStyle CssClass="styled-header" BackColor="#2E7D32" ForeColor="white" />
                <AlternatingRowStyle CssClass="alternate-row" BackColor="#A5D6A7" />
                <RowStyle CssClass="normal-row" BackColor="#E8F5E9" />
                <Columns>
                    <asp:BoundField DataField="idPrograma" HeaderText="ID de Usuario" Visible="false" />
                    <asp:BoundField DataField="ficha" HeaderText="Ficha" />
                    <asp:BoundField DataField="programa" HeaderText="Programa" />
                    <asp:BoundField DataField="jornada" HeaderText="Jornada" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <asp:Button ID="btnImprimir" runat="server" CssClass="btn-imprimir" Text="Imprimir Reporte" Style="margin-left: 700px;" OnClick="btnImprimir_Click1"/>



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
</asp:Content>
