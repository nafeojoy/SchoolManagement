<%@ Page Title="" Language="C#" MasterPageFile="~/ReportUI/reportMaster.Master" AutoEventWireup="True" CodeBehind="WebForm2.aspx.cs" Inherits="SchoolManagementProject.ReportUI.WebForm2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="800px" 
        Width="1000px">
    </rsweb:ReportViewer>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

</asp:Content>
