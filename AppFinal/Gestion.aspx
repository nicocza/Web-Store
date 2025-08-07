<%@ Page Title="Gestión de artículos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Gestion.aspx.cs" Inherits="AppFinal.Gestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView runat="server" ID="dgvArticulos" DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" CssClass="table table-dark table-bordered"
        AutoGenerateColumns="false" OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" PageSize="10" HeaderStyle-HorizontalAlign="Center"
        RowStyle-HorizontalAlign="Center" HeaderStyle-BorderColor="#0dcaf0" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="#0dcaf0" PagerStyle-BackColor="#0dcaf0">
        <Columns>
            <asp:BoundField HeaderText="Código" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:F2}" />
            <asp:CommandField ShowSelectButton="true" SelectText="✏️" HeaderText="Acción" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnIrAFormulario" runat="server" Text="Agregar" CssClass="btn-2" OnClick="btnIrAFormulario_Click" />
</asp:Content>
