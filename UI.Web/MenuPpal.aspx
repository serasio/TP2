<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPpal.aspx.cs" Inherits="UI.Web.MenuPpal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Menu ID="Menu1" runat="server">
            <DynamicItemTemplate>
                <%# Eval("Text") %>
            </DynamicItemTemplate>
            <Items>
                <asp:MenuItem Text="Listas" Value="Ambos">
                    <asp:MenuItem Text="Alumnos" Value="Alumno" NavigateUrl="~/Alumnos.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Comisiones" Value="Comisiones" NavigateUrl="~/Comisiones.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Cursos" Value="Alumno" NavigateUrl="~/Cursos.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Profesores" Value="Profesor" NavigateUrl="~/Docentes.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Especialidades" Value="Especialidades" NavigateUrl="~/Especialidades.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Materias" Value="Alumno" NavigateUrl="~/Materias.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Planes" Value="Planes" NavigateUrl="~/Planes.aspx"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DocentesCursos.aspx" Text="Profesores Cursos" Value="Profesor"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Usuarios.aspx" Text="Usuarios" Value="Usuarios"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Inscripciones" Value="Ambos">
                    <asp:MenuItem Text="Curso" Value="Ambos" NavigateUrl="~/Inscripciones.aspx"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Registros" Value="Registros">
                    <asp:MenuItem Text="Notas" Value="Notas" NavigateUrl="~/RegistroNotas.aspx"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Reportes" Value="Profesor">
                    <asp:MenuItem Text="Cursos" Value="Profesor"></asp:MenuItem>
                    <asp:MenuItem Text="Planes" Value="Planes" NavigateUrl="~/ReportePlan.aspx"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Salir" Value="Ambos" NavigateUrl="~/Login.aspx"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </div>
    </form>
</body>
</html>

