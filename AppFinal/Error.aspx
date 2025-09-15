<%@ Page Title="Error" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="AppFinal.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hubo un problema</h1>
    <asp:Label ID="lblMensaje" runat="server" Text="Label" Font-Bold="true" Font-Size="Large"></asp:Label>
</asp:Content>
