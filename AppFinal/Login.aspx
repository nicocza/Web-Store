<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AppFinal.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label ID="lblEmail" runat="server" Text="Ingrese su email" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control " BackColor="#333333" ForeColor="White" BorderColor="#0dcaf0"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn-2 focus-ring focus-ring-info" OnClick="btnIngresar_Click" />
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label ID="lblPass" runat="server" Text="Ingrese su contraseña" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" BackColor="#333333" ForeColor="White" BorderColor="#0dcaf0" TextMode="Password"></asp:TextBox>
            </div>
        </div>
    </div>

</asp:Content>
