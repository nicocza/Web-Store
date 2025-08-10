<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MarcasCategorias.aspx.cs" Inherits="AppFinal.MarcasCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="mb-3">
            <asp:Label runat="server" Text="Agrega tu Marca:" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtAgregaMarca" runat="server" CssClass="form-control" BackColor="#333333"></asp:TextBox>
            <asp:Button ID="btnAgregaMarca" runat="server" Text="Button" />
        </div>
    </div>

</asp:Content>
