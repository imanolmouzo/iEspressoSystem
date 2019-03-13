<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="MenuRecetas.aspx.cs" Inherits="Vistas_MenuRecetas" %>

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
    <% foreach (BE.Receta R in SEGURIDAD.TechnicalController.lsRecetas) { %>
    <div class="well">
        <h3>
            <strong><%= R.Nombre %></strong>
            <span class="pull-right label label-default">
                <%= R.Precio.ToString("c") %>
            </span>
        </h3>
        <div class="pull-right">
            <% string url = "/Vistas/Cliente/MenuRecetas.aspx?ID_Receta=" + R.ID; %>
            <a href="<%= url %>" class="btn btn-primary">Agregar
            </a>
        </div>
        <span class="lead">
            <%= "Capsula: " + R.Capsula.Nombre %><br>
        </span>
        <span class="lead">
            <%= R.Descripcion %><br>
        </span>
        <% string ingredientes = "Ingredientes: "; %>
        <% foreach (BE.Ingrediente Ing in R.Ingredientes) { ingredientes = ingredientes + Ing.Nombre + ", "; } %>
        <span class="lead">
            <%= ingredientes %>
        </span>
    </div>
        <% } %>

</asp:Content>