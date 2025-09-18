<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="AppFinal.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Contacto.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contact-form">
        <div class="form-group">
            <asp:Label ID="lblEmail" Font-Bold="true" Font-Size="X-Large" CssClass="form-label" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" CssClass="form-control" BackColor="#333333" BorderColor="#0dcaf0" ForeColor="White" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblAsunto" Font-Bold="true" Font-Size="X-Large" CssClass="form-label" runat="server" Text="Asunto"></asp:Label>
            <asp:TextBox ID="txtAsunto" CssClass="form-control" BackColor="#333333" BorderColor="#0dcaf0" ForeColor="White" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblMensaje" Font-Bold="true" Font-Size="X-Large" CssClass="form-label" runat="server" Text="Mensaje"></asp:Label>
            <asp:TextBox ID="txtMensaje" TextMode="MultiLine" CssClass="form-control" BackColor="#333333" BorderColor="#0dcaf0" ForeColor="White" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnEnviar" CssClass="btn-2 focus-ring focus-ring-info" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
        </div>
    </div>
</asp:Content>
