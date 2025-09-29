<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="AppFinal.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <asp:Label ID="lblPerfil" CssClass="form-label" Font-Bold="true" Font-Size="X-Large" runat="server" Text="Perfil"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblEmail" CssClass="form-label" Font-Size="Medium" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" BackColor="#333333" ForeColor="White" BorderColor="#0dcaf0" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblNombre" CssClass="form-label" Font-Size="Medium" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" BackColor="#333333" ForeColor="White" BorderColor="#0dcaf0" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblApellido" CssClass="form-label" Font-Size="Medium" runat="server" Text="Apellido"></asp:Label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" BackColor="#333333" ForeColor="White" BorderColor="#0dcaf0" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-4">
            <div class="mb-3">
                <asp:Label ID="lblImagen" runat="server" Text="Imágen"></asp:Label>
                <input type="file" id="txtImagen" class="form-control" runat="server" />
            </div>
            <asp:Image ID="imgNuevoPerfil" CssClass="img-fluid mb-3" ImageUrl="https://www.afim.com.eg/public/images/no-photo.png" runat="server" />
        </div>
        <div class="row">
            <div class="mb-3">
                <asp:Button ID="btnGuardar" CssClass="btn-2 focus-ring focus-ring-info" ForeColor="#0dcaf0" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
