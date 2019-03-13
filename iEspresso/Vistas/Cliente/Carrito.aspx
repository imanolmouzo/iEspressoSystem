<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Carrito.aspx.cs" Inherits="Vistas_Cliente_Carrito" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand">iEspresso</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li><a runat="server" href="~/Vistas/Cliente/MenuCapsulas">Capsulas</a></li>
                    <li><a runat="server" href="~/Vistas/Cliente/MenuRecetas">Recetas</a></li>
                    <li><a runat="server" href="~/Vistas/Cliente/Carrito">Carrito</a></li>
                </ul>
                <asp:LoginView runat="server" ViewStateMode="Disabled">
                    <AnonymousTemplate>
                        <ul class="nav navbar-nav navbar-right">
                            <li><a runat="server" href="~/Inicio">Logout</a></li>
                        </ul>
                    </AnonymousTemplate>
                </asp:LoginView>
            </div>
        </div>
    </div>
    <br>
    <% if (SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Carrito.lsProductos.Count > 0)
        { %>
    <% foreach (BE.Producto P in SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Carrito.lsProductos)
        { %>
    <div class="well">
        <h3>
            <strong><%= P.Nombre %></strong>
            <span class="pull-right label label-default">
                <% if (P.GetType() == typeof(BE.Capsula))
                    { %>
                <%= (P.Precio * 10).ToString("c") %>
                <% } %>
                <% else
                    { %>
                <%= P.Precio.ToString("c") %>
                <% } %>
            </span>
        </h3>
        <div class="pull-right">
            <% string url = "/Vistas/Cliente/Carrito.aspx?ID_Producto=" + P.ID; %>
            <a href="<%= url %>" class="btn btn-warning">Quitar
            </a>
        </div>
        <span class="lead">
            <%= P.Descripcion %>
        </span>
    </div>
        <% } %>
    <br>
    <div class="pull-right">
        <div class="form-group">
            <asp:Label ID="LabelT" runat="server" Text="Total: "></asp:Label>
            <asp:Button runat="server" OnClick="ButtonConfirmar_Click" Text="Confirmar" CssClass="btn btn-primary" ID="ButtonConfirmar" BackColor="#3EAC41" BorderColor="#3EAC41" />
        </div>
    </div>
    <% } %>
        <% else
    { %>
    <div class="alert alert-warning">El carrito esta vacio.</div>
        <% } %>
        
</asp:Content>
