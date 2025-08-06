<%@ Page Title="Formulario del artículo" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="AppFinal.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/FormularioStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="formulario">
        <div class="formulario-articulo">

            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Código</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" BackColor="#0dcaf0" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoría</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" BackColor="#0dcaf0" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn-2" OnClick="btnAceptar_Click" />
                <a href="Gestion.aspx">Atrás</a>
            </div>
        </div>

        <div class="formulario-columna derecha">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" TextMode="MultiLine" Rows="2" ID="txtDescripcion" CssClass="form-control" />
            </div>
            <asp:UpdatePanel ID="updtpnlImagen" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtURLImagen" class="form-label">URL Imágen</label>
                        <asp:TextBox runat="server" ID="txtURLImagen" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtURLImagen_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://www.afim.com.eg/public/images/no-photo.png" runat="server" ID="imgArticulo"
                        Width="400px" Long="200px" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
