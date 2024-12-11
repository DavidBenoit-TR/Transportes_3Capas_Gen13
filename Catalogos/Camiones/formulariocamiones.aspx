<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formulariocamiones.aspx.cs" Inherits="Transportes_3Capas_Gen13.Catalogos.Camiones.formulariocamiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label ID="Titulo" runat="server" CssClass="text-center modal-title" Text=""></asp:Label>
            <asp:Label ID="subTitulo" runat="server" CssClass="text-center modal-title" Text=""></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-12">
                <%--Formulario--%>
                <div class="form-group">
                    <%--Etiquetado--%>
                    <asp:Label ID="lblmatricula" runat="server" Text="Matrícula"></asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtmatricula" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblcapacidad" runat="server" Text="Capacidad"></asp:Label>
                    <asp:TextBox ID="txtcapacidad" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblkilometraje" runat="server" Text="Kilometraje"></asp:Label>
                    <asp:TextBox ID="txtkilometraje" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblmarca" runat="server" Text="Marca"></asp:Label>
                    <asp:TextBox ID="txtmarca" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblmodelo" runat="server" Text="Modelo"></asp:Label>
                    <asp:TextBox ID="txtmodelo" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lbltipo" runat="server" Text="Tipo de Camión"></asp:Label>
                    <asp:TextBox ID="txttipo" runat="server" CssClass="form-control"></asp:TextBox>

                    <%--Campos especiales--%>
                    <br />
                    <br />
                    <asp:Label ID="lbldisponibilidad" runat="server" Text="Disponibilidad"></asp:Label>
                    <br />
                    <asp:CheckBox ID="chkdisponibilidad" runat="server" />
                    <br />
                    <br />

                    <asp:Label ID="lblimagen" runat="server" Text="Imagen"></asp:Label>
                    <input type="file" id="subeimagen" runat="server" class="btn btn-group" />
                    <asp:Button ID="btnsubeimagen" runat="server" CssClass="btn btn-primary" Text="Subir Imagen" OnClick="btnsubeimagen_Click" />

                    <asp:Label ID="lblurlfoto" runat="server" Text="Foto"></asp:Label>

                    <asp:Image ID="imgfoto" Width="100" Height="100" runat="server" />
                    <asp:Image ID="imgcamion" Width="100" Height="100" runat="server" />

                    <asp:Label ID="urlfoto" runat="server"></asp:Label>

                    <asp:Button ID="btnguardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnguardar_Click" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
