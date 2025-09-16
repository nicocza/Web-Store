<%@ Page Title="Registro" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="AppFinal.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label ID="lblEmail" Font-Bold="true" Font-Size="X-Large" runat="server" Text="Ingrese su email"></asp:Label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" BackColor="#333333" ForeColor="White" BorderColor="#0dcaf0" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnRegistrar" CssClass="btn-2 focus-ring focus-ring-info" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" />
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label ID="lblPass" Font-Bold="true" Font-Size="X-Large" runat="server" Text="Ingrese su contraseña"></asp:Label>
                <asp:TextBox ID="txtPass" CssClass="form-control" BackColor="#333333" ForeColor="White" BorderColor="#0dcaf0" TextMode="Password" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

</asp:Content>
