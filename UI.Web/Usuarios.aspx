<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Ridge" BorderWidth="5px" Direction="LeftToRight" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="Black" GroupingText="Lista de usuarios" HorizontalAlign="Left">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
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
    <asp:Panel ID="formPanel" Visible="false" runat="server" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Ridge" BorderWidth="5px" Direction="LeftToRight" Font-Bold="True" Font-Italic="False" Font-Names="Century Gothic" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" GroupingText="Complete los datos: " HorizontalAlign="Left" Height="302px">
        <br />
        &nbsp;<asp:Label ID="personaLabel" runat="server" Text="Persona: "></asp:Label>
        <asp:DropDownList ID="ddlPersona" runat="server" OnSelectedIndexChanged="ddlPersona_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="personaLinkButton" runat="server" OnClick="personaLinkButton_Click">Crear nueva persona</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="tipoPersonaLabel" runat="server" Text="Tipo persona: "></asp:Label>
        &nbsp;<asp:DropDownList ID="ddlTipoPersona" runat="server">
            <asp:ListItem>Alumno</asp:ListItem>
            <asp:ListItem>Docente</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        &nbsp;<asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
        &nbsp;<asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="ValidadorUsuario" runat="server" ControlToValidate="nombreUsuarioTextBox" ErrorMessage="El usuario no puede estar vacío" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidadorNombre" runat="server" ControlToValidate="nombreTextBox" EnableTheming="True" ErrorMessage="El Nombre no puede estar vacìo." ForeColor="#FF3300">*</asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;<asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
        &nbsp;<asp:TextBox ID="claveTextBox" runat="server" TextMode="Password"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="ValidadorClave" runat="server" ControlToValidate="claveTextBox" ErrorMessage="La Clave no puede estar vacìa." ForeColor="#FF3300">*</asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidadorApellido" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="El Apellido no puede estar vacìo." ForeColor="#FF3300">*</asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;<asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave: "></asp:Label>
        <asp:TextBox ID="repetirClaveTextBox" runat="server" OnTextChanged="repetirClaveTextBox_TextChanged" TextMode="Password"></asp:TextBox>
        &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="claveTextBox" ControlToValidate="repetirClaveTextBox" ErrorMessage="Las Claves no coinciden." ForeColor="#FF3300">*</asp:CompareValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="ValidadorEMail" runat="server" ControlToValidate="emailTextBox" ErrorMessage="E-Mail invàlido." ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="ValidadorEMailNotNull" runat="server" ControlToValidate="emailTextBox" ErrorMessage="El E-Mail no puede estar vacìo." ForeColor="#FF3300">*</asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado "></asp:Label>
        <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
        <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="#FF3300" Height="47px" />
        <br />
        <br />
        <br />
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server" BackColor="#666666">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Outset" BorderWidth="3px" EnableTheming="True" Font-Bold="False" Font-Names="Comic Sans MS" Font-Overline="False" ForeColor="Black">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Outset" BorderWidth="3px" Font-Names="Comic Sans MS" Font-Strikeout="False" ForeColor="Black">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Outset" BorderWidth="3px" Font-Names="Comic Sans MS" ForeColor="Black">Nuevo</asp:LinkButton>
        &nbsp;
            <asp:LinkButton ID="lbtnMenuPpal" runat="server" OnClick="lbtnMenuPpal_Click">Volver al Menú Principal</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server" BackColor="#666666">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Outset" BorderWidth="3px" Font-Names="Comic Sans MS" ForeColor="Black">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CausesValidation="False" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Outset" BorderWidth="3px" Font-Names="Comic Sans MS" ForeColor="Black">Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Content>

