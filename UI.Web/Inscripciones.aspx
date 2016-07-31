<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscripciones.aspx.cs" Inherits="UI.Web.Inscripciones" %>

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
        <asp:Panel ID="gridPanel" runat="server" BorderStyle="Solid" GroupingText="Lista de inscripciones" BackColor="#CCCCCC" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" Height="197px">
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="AluNomYApe" HeaderText="Alumno" />
                    <asp:BoundField DataField="ComisionMateriaAnio" HeaderText="Curso" />
                    <asp:BoundField DataField="Condicion" HeaderText="Condición" />
                    <asp:BoundField DataField="Nota" HeaderText="Nota" />
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
            <br />
        </asp:Panel>
        <asp:Panel ID="formPanel" runat="server" Height="219px" BorderStyle="Solid" GroupingText="Complete los datos: " BackColor="#CCCCCC" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" Visible="False">
            <br />
            &nbsp;
            <asp:Label ID="lblAlumno" runat="server" Text="Alumno: "></asp:Label>            
            <asp:DropDownList ID="ddlAlumno" runat="server">
            </asp:DropDownList>            
            <br />
            <br />
            &nbsp;
            <asp:Label ID="lblCurso" runat="server" Text="Curso: "></asp:Label>
            <asp:DropDownList ID="ddlCurso" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            &nbsp;
            <asp:Label ID="lblCondicion" runat="server" Text="Condición: "></asp:Label>           
            <asp:DropDownList ID="ddlCondicion" runat="server">
            </asp:DropDownList>          
            <br />
            <br />
            &nbsp;
            <asp:Label ID="lblNota" runat="server" Text="Nota: "></asp:Label>
            <asp:TextBox ID="txtbNota" runat="server"></asp:TextBox>
            <br />
            <br />
        </asp:Panel>
        <asp:Panel ID="gridActionsPanel" runat="server" BackColor="#666666" Height="28px" style="margin-top: 0px">
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Outset" BorderWidth="3px" EnableTheming="True" Font-Bold="False" Font-Names="Comic Sans MS" Font-Overline="False" ForeColor="Black">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Outset" BorderWidth="3px" Font-Names="Comic Sans MS" Font-Strikeout="False" ForeColor="Black">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Outset" BorderWidth="3px" Font-Names="Comic Sans MS" ForeColor="Black">Nuevo</asp:LinkButton>
        &nbsp;
            <asp:LinkButton ID="lbtnMenuPpal" runat="server" OnClick="lbtnMenuPpal_Click">Volver al Menú Principal</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="formActionsPanel" runat="server" BackColor="#666666" Height="29px" style="margin-top: 0px">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Outset" BorderWidth="3px" Font-Names="Comic Sans MS" ForeColor="Black" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Outset" BorderWidth="3px" Font-Names="Comic Sans MS" ForeColor="Black" OnClick="cancelarLinkButton_Click" CausesValidation="False">Cancelar</asp:LinkButton>
        </asp:Panel>
    </form>
</body>
</html>
