<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperaPass.aspx.cs" Inherits="UI.Web.RecuperaPass" %>

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
        <asp:Panel ID="Panel1" runat="server" GroupingText="Recuperar contraseña">
            <br />
            &nbsp;<asp:Label ID="usuarioLabel" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="usuarioTextBox" runat="server" Width="175px" style="margin-left: 2px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="ValidadorUsuario" runat="server" ControlToValidate="usuarioTextBox" ErrorMessage="El usuario no puede ser vacío" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
            <br />
            <br />
            &nbsp;&nbsp; &nbsp;<asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="emailTextBox" runat="server" Width="175px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="ValidadorEmail" runat="server" ErrorMessage="El email no puede ser vacío" ForeColor="#FF3300" ControlToValidate="emailTextBox">*</asp:RequiredFieldValidator>
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnRecuperar" runat="server" BackColor="#0033CC" Font-Bold="True" Font-Overline="False" ForeColor="White" OnClick="btnRecuperar_Click" Text="Recuperar" Width="142px" />
            <br />
            <br />
            <asp:LinkButton ID="lbtnMenuPpal" runat="server" OnClick="lbtnMenuPpal_Click">Volver al Menú Principal</asp:LinkButton>
            <br />
            <br />
        </asp:Panel>
    </form>
</body>
</html>
