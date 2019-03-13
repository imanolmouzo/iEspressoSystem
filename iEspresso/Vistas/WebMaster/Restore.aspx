<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Restore.aspx.cs" Inherits="Vistas_Restore" %>

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
                <div class="form-group">
                    <div class="col-md-10">
                        <label>Seleccione un archivo de backup</label>
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="484px" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="ButtonRestaurar" Text="Restaurar" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>