<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteInstructor.aspx.cs" Inherits="appRegistroSena.Vista.ReporteInstructor" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="rvInstructores" runat="server" Width="65%"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
