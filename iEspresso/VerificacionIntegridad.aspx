<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="VerificacionIntegridad.aspx.cs" Inherits="IntegridadCorrupta" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <%  BLL.DVV gestorDVV = new BLL.DVV();
        gestorDVV.VerificarIntegridad();

        BLL.DVH gestorDVH = new BLL.DVH();
        gestorDVH.VerificarIntegridad(); %>

    <% if (SEGURIDAD.TechnicalController.IntegridadCorrupta)
        { %>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#CC0000" Text="Base de datos alterada. Detectado por DVV."></asp:Label>
    <br />
    <br />
    <% } %>

    <% if (SEGURIDAD.TechnicalController.lsUsuariosAlterados.Count > 0)
        { %>
    <div class="row">
        <h3>El DVH indica que los siguientes usuarios fueron modificados</h3>

        <div class="col-xs-8" style="left: 3px; top: 3px; width: 62%">
            <table class="table">
                <thead>
                    <tr>
                        <th style="width: 98px">ID</th>
                        <th style="width: 256px">Usuario</th>
                        <th style="width: 256px">Permiso</th>
                        <th style="width: 98px">Estado</th>
                        <th style="width: 500px">DVH</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (BE.Usuario u in SEGURIDAD.TechnicalController.lsUsuariosAlterados)
                        { %>
                    <tr>
                        <td style="width: 98px"><%= u.ID %></td>
                        <td style="width: 256px"><%= u.Username %></td>
                        <td style="width: 256px"><%= u.Permiso %></td>
                        <td style="width: 98px"><%= u.Estado %></td>
                        <td style="width: 500px"><%= u.DVH %></td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
        </div>
        <br>
        <div class="pull-right">
            <div class="form-group">
                <asp:Button runat="server" OnClick="ButtonOk_Click" Text="Ok" CssClass="btn btn-primary" ID="ButtonOk" BackColor="#006666" BorderColor="#006666" />
            </div>
        </div>
    </div>
    <% } %>
    <br />
    <br />
    <% if (SEGURIDAD.TechnicalController.lsCapsulasAlteradas.Count > 0)
        { %>
    <div class="row">
        <h3>El DVH indica que las siguientes capsulas fueron modificadas</h3>

        <div class="col-xs-8" style="left: 3px; top: 3px; width: 62%">
            <table class="table">
                <thead>
                    <tr>
                        <th style="width: 98px">ID</th>
                        <th style="width: 256px">Capsula</th>
                        <th style="width: 98px">Intensidad</th>
                        <th style="width: 500px">Descripcion</th>
                        <th style="width: 256px">Tipo</th>
                        <th style="width: 128px">Precio</th>
                        <th style="width: 98px">Stock</th>
                        <th style="width: 500px">DVH</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (BE.Capsula c in SEGURIDAD.TechnicalController.lsCapsulasAlteradas)
                        { %>
                    <tr>
                        <td style="width: 98px"><%= c.ID %></td>
                        <td style="width: 256px"><%= c.Nombre %></td>
                        <td style="width: 98px"><%= c.Intensidad %></td>
                        <td style="width: 500px"><%= c.Descripcion %></td>
                        <td style="width: 256px"><%= c.Tipo %></td>
                        <td style="width: 128px"><%= c.Precio %></td>
                        <td style="width: 98px"><%= c.Stock %></td>
                        <td style="width: 500px"><%= c.DVH %></td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
        </div>
        <br>
    </div>
    <% } %>

    <% if(!SEGURIDAD.TechnicalController.IntegridadCorrupta && SEGURIDAD.TechnicalController.lsUsuariosAlterados.Count == 0)
        { Response.Redirect("~/Account/Login.aspx"); } %>
</asp:Content>
