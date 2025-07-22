<%@ Page Title="NICOCZA Web Store" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppFinal.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%
            foreach (Model.Articulo arti in ListaArticulo)
            {
        %>
        <div class="col">
            <div class="card">
                <img src="<%: arti.UrlImagen %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%: arti.Nombre %></h5>
                    <p class="card-text"><%: arti.Descripcion %></p>
                </div>
            </div>
        </div>
        <%  } %>

    </div>
</asp:Content>
