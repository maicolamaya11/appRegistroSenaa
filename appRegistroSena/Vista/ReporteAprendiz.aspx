﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteAprendiz.aspx.cs" Inherits="appRegistroSena.Vista.ReporteAprendiz" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="rvAprendiz" runat="server" Width="73%"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
