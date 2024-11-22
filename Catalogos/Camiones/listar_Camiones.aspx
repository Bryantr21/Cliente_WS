<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listar_Camiones.aspx.cs" Inherits="Cliente_WS.Catalogos.Camiones.listar_Camiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <div class="row">
        <h3>Lista de camiones</h3>
        <p>
            <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-xs" Width="85px" OnClick="Insertar_Click" />
        </p>
    </div>
    <div class="row">
        <asp:GridView ID="GVCamiones" runat="server" CssClass="table table-bordered table-striped table-condensed" AutoGenerateColumns="false" DataKeyNames="Id_Camion" OnRowDeleting="GVCamiones_RowDeleting" OnRowCommand="GVCamiones_RowCommand" OnRowEditing="GVCamiones_RowEditing" OnRowUpdating="GVCamiones_RowUpdating" OnRowCancelingEdit="GVCamiones_RowCancelingEdit">
            <Columns>
                <asp:BoundField DataField="Id_Camion" HeaderText="Numero de Camion" ItemStyle-Width="85px" ReadOnly="true"></asp:BoundField>
                <asp:BoundField DataField="Matricula" HeaderText="Matricula" ItemStyle-Width="85px"></asp:BoundField>
                <asp:BoundField DataField="Tipo_camion" HeaderText="Tipo Camion" ItemStyle-Width="85px"></asp:BoundField>
                <asp:TemplateField HeaderText="Disponibilidad" ItemStyle-Width="50px">
                    <itemtemplate>
                        <div style="width: 100%">
                            <div style="width: 25%; margin: 0 auto">
                                <asp:CheckBox ID="chkDisponible" runat="server" Checked='<%#Eval("Disponibilidad") %>' Enabled="false" />
                            </div>
                        </div>
                    </itemtemplate>
                    <edititemtemplate>
                        <div style="width: 100%">
                            <div style="width: 25%; margin: 0 auto">
                                <asp:CheckBox ID="chkEditDisponible" runat="server" Checked='<%#Eval("Disponibilidad") %>' />
                            </div>
                        </div>
                    </edititemtemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UrlFoto" HeaderText="UrlFoto" ItemStyle-Width="85px"></asp:BoundField>
                <asp:ImageField HeaderText="Foto" ReadOnly="true" ItemStyle-Width="120px" ControlStyle-Height="120px" ControlStyle-Width="120px" DataImageUrlField="UrlFoto"></asp:ImageField>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="1" text="Ver detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px"></asp:ButtonField>
                <asp:CommandField ButtonType="Button" HeaderText="2" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-warning btn-xs" ItemStyle-Width="50px"></asp:CommandField>
                <asp:CommandField ButtonType="Button" HeaderText="3" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px"></asp:CommandField>

            </Columns>
        </asp:GridView>

    </div>
</div>
</asp:Content>
