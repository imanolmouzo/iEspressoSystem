<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Bitacora.aspx.cs" Inherits="Vistas_Bitacora" %>

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
                    <li><a runat="server" href="~/Vistas/WebMaster/Bitacora">Bitacora</a></li>
                    <li><a runat="server" href="~/Vistas/WebMaster/Backup">Backup</a></li>
                    <li><a runat="server" href="~/Vistas/WebMaster/Restore">Restore</a></li>
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

    <div class="row">
        <h3>Bitacora</h3>

        <div class="col-xs-8" style="left: 3px; top: 3px; width: 62%">
            <% if (lsBitacora != null)
                { %>
            <table class="table">
                <thead>
                    <tr>
                        <th style="width: 98px">ID</th>
                        <th style="width: 256px">Fecha</th>
                        <th style="width: 374px">Evento</th>
                        <th style="width: 336px">Usuario</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (var b in lsBitacora)
                        { %>
                    <tr>
                        <td style="width: 98px"><%= b.ID %></td>
                        <td style="width: 256px"><%= b.Fecha %></td>
                        <td style="width: 374px"><%= b.Evento %></td>
                        <td style="width: 336px"><%= b.Usuario.Username %></td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
            <% }
                else
                { %>
            <div class="alert alert-warning">No hay registros de la fecha solicitada.</div>
            <% } %>
        </div>  
        <div class="col-xs-4" style="left: 14px; top: -23px; width: 34%;">
            <div class="form-group">
                <label for="FechaInicio">Desde</label>
                <input id="FechaInicio" type="text" class="form-control js-datepicker" placeholder="26/08/2018" runat="server" />
            </div>
            <div class="form-group">
                <label for="FechaFin">Hasta</label>
                <input id="FechaFin" type="text" class="form-control js-datepicker" placeholder="11/09/2018" runat="server" />
            </div>
            <asp:Button ID="ButtonFiltrar" Text="Filtrar" OnClick="ButtonFiltrar_Click" CssClass="btn btn-primary" runat="server" />
            <asp:Button ID="ButtonLimpiar" Text="Limpiar" OnClick="ButtonLimpiar_Click" CssClass="btn btn-primary" runat="server" />
        </div>
        </div>
</asp:Content>
