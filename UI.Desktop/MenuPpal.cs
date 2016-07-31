using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace UI.Desktop
{
    public partial class MenuPpal : ApplicationForm
    {
        public MenuPpal(Persona usu)
        {
            InitializeComponent();
            UsuarioLogeado = usu;
            if (UsuarioLogeado.TipoPersona == Persona.TiposPersonas.Alumno)
            {
                alumnosToolStripMenuItem.Visible = false;
                comisionesToolStripMenuItem.Visible = false;
                especialidadesToolStripMenuItem.Visible = false;
                planesToolStripMenuItem.Visible = false;
                profesoresToolStripMenuItem.Visible = false;
                profesoresCursosToolStripMenuItem.Visible = false;
                reportesToolStripMenuItem.Visible = false;
                cursosToolStripMenuItem.Visible = false;
            }
            if (UsuarioLogeado.TipoPersona == Persona.TiposPersonas.Docente)
            {
                alumnosToolStripMenuItem.Visible = false;
                comisionesToolStripMenuItem.Visible = false;
                especialidadesToolStripMenuItem.Visible = false;
                materiasToolStripMenuItem.Visible = false;
                planesToolStripMenuItem.Visible = false;
                profesoresToolStripMenuItem.Visible = false;
                reportesPlanesToolStripMenuItem.Visible = false;
                cursosToolStripMenuItem.Visible = false;
            }
        }

        private Persona _usuarioLogeado;

        public Persona UsuarioLogeado
        {
            get { return _usuarioLogeado; }
            set { _usuarioLogeado = value; }
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alumnos alu = new Alumnos();
            alu.MdiParent = this;
            alu.Show();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comisiones com = new Comisiones();
            com.MdiParent = this;
            com.Show();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos cu = new Cursos();
            cu.MdiParent = this;
            cu.Show();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especialidades esp = new Especialidades();
            esp.MdiParent = this;
            esp.Show();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Materias mat = new Materias(UsuarioLogeado);
            mat.MdiParent = this;
            mat.Show();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planes plan = new Planes();
            plan.MdiParent = this;
            plan.Show();
        }

        private void profesoresCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocentesCursos dc = new DocentesCursos();
            dc.MdiParent = this;
            dc.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios usu = new Usuarios(UsuarioLogeado);
            usu.MdiParent = this;
            usu.Show();
        }


        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Show();
        }

        private void profesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Docentes doc = new Docentes();
            doc.MdiParent = this;
            doc.Show();
        }

        private void cursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inscripciones ins = new Inscripciones(UsuarioLogeado);
            ins.MdiParent = this;
            ins.Show();
        }

        private void reportesCursosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SeleccionPreReporte selec = new SeleccionPreReporte("Curso");
            selec.ShowDialog();
        }

        private void reportesPlanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeleccionPreReporte selec = new SeleccionPreReporte("Plan");
            selec.ShowDialog();
        }
    }
}
