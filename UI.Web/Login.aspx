<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

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
        <asp:Panel ID="loginPanel" runat="server" Height="237px" GroupingText="Ingrese sus datos para iniciar sesión" TabIndex="2">
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="usuarioLabel" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="usuarioTextBox" runat="server" Width="153px"></asp:TextBox>
            <br />
            <br />
            &nbsp;<asp:Label ID="passLabel" runat="server" Text="Contraseña: "></asp:Label>
            <asp:TextBox ID="passTextBox" runat="server" Width="153px" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnIngresar" runat="server" BackColor="#0033CC" Font-Bold="True" Font-Overline="False" ForeColor="White" Text="Ingresar" Width="142px" OnClick="btnIngresar_Click"></asp:Button>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblError" runat="server" Text="Usuario o contraseña incorrectos" ForeColor="Red" Visible="False"></asp:Label>
            <br />
            <br />
            &nbsp;
            <asp:LinkButton ID="passLinkButton" runat="server" OnClick="passLinkButton_Click">Olvidé mi contraseña</asp:LinkButton>
            <br />
            <br />
        </asp:Panel>
    </form>
</body>
</html>
