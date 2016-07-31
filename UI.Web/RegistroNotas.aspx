<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroNotas.aspx.cs" Inherits="UI.Web.RegistroNotas" %>

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
        <asp:Panel ID="elegirPanel" runat="server" BorderStyle="Solid" BackColor="#CCCCCC" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" Height="122px">
            <br />
            <asp:Label ID="lblPlan" runat="server" Text="Plan:"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="ddlPlan" runat="server" OnSelectedIndexChanged="ddlPlan_SelectedIndexChanged">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblComision" runat="server" Text="Comisión: "></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlComision" runat="server" OnSelectedIndexChanged="ddlComision_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblAnio" runat="server" Text="Año: "></asp:Label>
            &nbsp;<asp:TextBox ID="txtAnio" runat="server" OnTextChanged="txtAnio_TextChanged"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCurso" runat="server" Text="Curso: "></asp:Label>
            <asp:DropDownList ID="ddlCurso" runat="server" OnSelectedIndexChanged="ddlCurso_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            &nbsp;           
        </asp:Panel>
        <asp:Panel ID="buttonsPanel" runat="server" BackColor="Gray" Font-Bold="True" Font-Names="Century Gothic" Height="34px" style="margin-top: 0px">
                &nbsp;&nbsp;
                <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbtnMenuPpal" runat="server" OnClick="lbtnMenuPpal_Click">Volver al Menú Principal</asp:LinkButton>
            </asp:Panel>
        <asp:Panel ID="gridPanel" runat="server" BorderStyle="Solid" GroupingText="Registro de notas" BackColor="#CCCCCC" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" Height="196px" style="margin-top: 0px">            
            <asp:GridView ID="gvNotas" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="AluNomYApe" HeaderText="Alumno" />
                    <asp:BoundField DataField="Nota" HeaderText="Nota" />
                    <asp:BoundField DataField="Condicion" HeaderText="Condición" />
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
    </form>
</body>
</html>
