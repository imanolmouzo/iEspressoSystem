<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Backup.aspx.cs" Inherits="Vistas_Backup" %>

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
        <div class="col-md-8">
            <div class="form-horizontal">
                <hr />
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                </asp:PlaceHolder>
                <div class="form-group">
                    <div class="col-md-10">
                        <label for="txtBackupName">Nombre del backup</label>
                        <asp:TextBox runat="server" ID="txtBackupName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBackupName"
                            CssClass="text-danger" ErrorMessage="Debe ingresar el nombre del backup." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="ButtonBackup" Text="Realizar backup" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-8">
            <% if (lsBackup != null)
                {%>
            <table class="table">
                <thead>
                    <tr>
                        <th>Archivos de backup realizados</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (var archivo in lsBackup)
                        { %>
                    <tr>
                        <td><%= archivo %></td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
            <% }
                else
                { %>
            <div class="alert alert-warning">No existe ningun backup.</div>
            <% } %>
        </div>
    </div>
</asp:content>