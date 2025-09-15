<%@ Page Title="Tu Perfil" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="AppFinal.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Bienvenido de nuevo</h1>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <%if (Session["usuario"] != null && ((Model.Usuario)Session["usuario"]).TipoUsuario == Model.TipoUsuario.ADMIN)
                    {
                %>
                <asp:Button ID="btnAdmin" runat="server" Text="Ingresar como admin" CssClass="btn-2 focus-ring focus-ring-info" OnClick="btnAdmin_Click" />
                <%} %>
                <%if (Session["usuario"] != null && ((Model.Usuario)Session["usuario"]).TipoUsuario == Model.TipoUsuario.NORMAL)
                    {
                %>
                <asp:Button ID="btnUsuario" runat="server" Text="Ingresar como usuario" CssClass="btn-2 focus-ring focus-ring-info" OnClick="btnUsuario_Click" />
                <%} %>
            </div>
        </div>
    </div>

</asp:Content>
