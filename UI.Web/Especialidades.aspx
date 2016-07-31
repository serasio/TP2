<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Panel ID="gridPanel" runat="server" BorderStyle="Solid" GroupingText="Lista de especialidades" BackColor="#CCCCCC" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" Height="196px">
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="formPanel" runat="server" Height="140px" BorderStyle="Solid" GroupingText="Complete los datos:" BackColor="#CCCCCC" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" Visible="False">
            <br />
            <asp:Label ID="descLabel" runat="server" Text="Descripción: "></asp:Label>
            <asp:TextBox ID="descTextBox" runat="server" Width="111px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ValidadorDescripcion" runat="server" ErrorMessage="La descripción no puede ser vacía." ForeColor="#FF3300" ControlToValidate="descTextBox">*</asp:RequiredFieldValidator>
            <br />
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="#FF3300" Height="53px" style="margin-top: 21px" />
        </asp:Panel>
        <asp:Panel ID="gridActionsPanel" runat="server" BackColor="#666666">
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Outset" BorderWidth="3px" EnableTheming="True" Font-Bold="False" Font-Names="Comic Sans MS" Font-Overline="False" ForeColor="Black">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Outset" BorderWidth="3px" Font-Names="Comic Sans MS" Font-Strikeout="False" ForeColor="Black">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Outset" BorderWidth="3px" Font-Names="Comic Sans MS" ForeColor="Black">Nuevo</asp:LinkButton>
        &nbsp;
            <asp:LinkButton ID="lbtnMenuPpal" runat="server" OnClick="lbtnMenuPpal_Click">Volver al Menú Principal</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="formActionsPanel" runat="server" BackColor="#666666">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Outset" BorderWidth="3px" Font-Names="Comic Sans MS" ForeColor="Black" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Outset" BorderWidth="3px" Font-Names="Comic Sans MS" ForeColor="Black" OnClick="cancelarLinkButton_Click" CausesValidation="False">Cancelar</asp:LinkButton>
        </asp:Panel>
    </form>
</body>
</html>