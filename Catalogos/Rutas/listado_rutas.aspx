﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listado_rutas.aspx.cs" Inherits="Transportes_3Capas_Gen13.Catalogos.Rutas.listado_rutas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>lista de Rutas</h3>
            <asp:Button ID="Insertar" runat="server" Text="Agregar Ruta" CssClass="btn btn-primary btn-xs" Width="55px" OnClick="Insertar_Click" />
        </div>
        <div class="row">
            <asp:GridView ID="GVRutas" runat="server"
                CssClass="table table-bordered table-condensed table-striped"
                AutoGenerateColumns="false"
                DataKeyNames="ID_Ruta"
                OnRowCommand="GVRutas_RowCommand"
                OnRowDeleting="GVRutas_RowDeleting">

                <Columns>
                    <asp:BoundField DataField="ID_Ruta" HeaderText="ID Ruta" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Distancia" HeaderText="Distancia" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Fecha_salida" HeaderText="Fecha Salida" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Fecha_llegadaestimada" HeaderText="Fecha Llegada Estimada" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Fecha_llegadareal" HeaderText="Fecha Llegada Real" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Camion_ID" HeaderText="Camion ID" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Chofer_ID" HeaderText="Chofer ID" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Direccionorigen_ID" HeaderText="Direccion Origen ID" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Direcciondestino_ID" HeaderText="Direccion Destino ID" ItemStyle-Width="50px" ReadOnly="true" />

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Editar" ShowHeader="true" Text="Editar" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />

                    <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

