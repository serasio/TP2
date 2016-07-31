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
using Negocio;
using Util;

namespace UI.Desktop
{
    public partial class DocenteCursoDesktop : ApplicationForm
    {
        public DocenteCursoDesktop()
        {
            InitializeComponent();
        }

        List<Curso> listcurso = new List<Curso>();
        List<Persona> listdoc = new List<Persona>();
        

        public DocenteCursoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public DocenteCursoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            DocCursoLogic docCurso = new DocCursoLogic();
            DocCursoActual = docCurso.GetOne(ID);
            MapearDeDatos();
        }

        private DocenteCurso _docCursoActual;
        
        public DocenteCurso DocCursoActual
        {
            get { return _docCursoActual; }
            set { _docCursoActual = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.DocCursoActual.ID.ToString();
            this.cmbCargo.SelectedText = this.DocCursoActual.Cargo.ToString();
            this.cmbCurso.Text = this.DocCursoActual.IDCurso.ToString();
            this.cmbDocente.Text = this.DocCursoActual.IDDocente.ToString();

            if (Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            if (Modo == ModoForm.Consulta)
            {
                txtID.ReadOnly = true;
                cmbCargo.Enabled = false;
                cmbCurso.Enabled = false;
                cmbDocente.Enabled = false;
                btnAceptar.Text = "Aceptar";
            }
            if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
                cmbCargo.Enabled = false;
                cmbCurso.Enabled = false;
                cmbDocente.Enabled = false;
            }
        }

        public override void MapearADatos()
        {
            if(Modo==ModoForm.Alta)
            {
                DocenteCurso docCurso = new DocenteCurso();
                DocCursoActual = docCurso;
                DocCursoActual.Cargo = (DocenteCurso.TiposCargos)cmbCargo.SelectedIndex;
                DocCursoActual.IDCurso = listcurso[cmbCurso.SelectedIndex].ID;
                DocCursoActual.IDDocente = listdoc[cmbDocente.SelectedIndex].ID;
                DocCursoActual.State = Entidad.States.Nuevo;
            }

            if(Modo==ModoForm.Modificacion)
            {
                this.DocCursoActual.ID = int.Parse(this.txtID.Text);
                this.DocCursoActual.Cargo = (DocenteCurso.TiposCargos)cmbCargo.SelectedIndex;
                this.DocCursoActual.IDCurso = listcurso[cmbCurso.SelectedIndex].ID;
                this.DocCursoActual.IDDocente = listdoc[cmbDocente.SelectedIndex].ID;
                //DocCursoActual.State = Entidad.States.Modificado;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            DocCursoLogic docCurso = new DocCursoLogic();
            docCurso.Save(DocCursoActual);
        }
        public override bool Validar()
        {
            if (this.cmbCargo.SelectedIndex == -1)
            {
                Notificar("No puedes dejar el cargo sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.cmbCurso.SelectedIndex == -1 || this.cmbCurso.Text.Count() < 1)
            {
                Notificar("No puedes dejar el curso sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.cmbDocente.SelectedIndex == -1)
            {
                Notificar("No puedes dejar el docente sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public new void Notificar(string mensaje, string titulo, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        
        public new void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(mensaje, this.Text, botones, icono);
        }

        private void DocenteCursoDesktop_Load(object sender, EventArgs e)
        {
            PersonaLogic docLogic = new PersonaLogic();
            CursoLogic curso = new CursoLogic();
            List<string> listtipoper = new List<string>();
            AutoCompleteStringCollection accCurso = new AutoCompleteStringCollection();
            AutoCompleteStringCollection accDocente = new AutoCompleteStringCollection();
            listcurso = curso.GetAll();
            listdoc = docLogic.GetNom(Persona.TiposPersonas.Docente);
            listtipoper.Add("Titular");
            listtipoper.Add("Auxiliar");
            listtipoper.Add("Suplente");
            cmbCargo.DataSource = listtipoper;
            if (listcurso.Count >= 1)
            {
                foreach (Curso cur in listcurso)
                {
                    accCurso.Add(cur.MateriaComision);
                }
                //Cargo el combo
                this.cmbCurso.DataSource = listcurso;
                this.cmbCurso.DisplayMember = "MateriaComision";
                //Cargo el autocomplete
                this.cmbCurso.AutoCompleteCustomSource = accCurso;
                this.cmbCurso.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.cmbCurso.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }

            else
            {
                cmbCurso.Text = "No hay cursos cargados";
                cmbCurso.Enabled = false;
                cmbDocente.Enabled = false;
                cmbCargo.Enabled = false;
                btnAceptar.Visible = false;
            }

            if (listdoc.Count >= 1)
            {
                foreach (Persona doc in listdoc)
                {
                    accDocente.Add(doc.NombreYApellido);
                }
                //Cargo el combo
                this.cmbDocente.DataSource = listdoc;
                this.cmbDocente.DisplayMember = "NombreYApellido";
                //Cargo el autocomplete
                this.cmbDocente.AutoCompleteCustomSource = accDocente;
                this.cmbDocente.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.cmbDocente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }

            else
            {
                cmbCurso.Text = "No hay docentes cargados";
                cmbCurso.Enabled = false;
                cmbDocente.Enabled = false;
                cmbCargo.Enabled = false;
                btnAceptar.Visible = false;
            }
            // no se de donde sacar el ID del docente porque no hay ninguna clase Docente. sera de Personas??
            //cmbCargo.DataSource=docCurso  deberia ser TiposCargos que es una enumeracion
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Validar())
            {
                if (btnAceptar.Text == "Guardar")
                {
                    GuardarCambios();
                    DocCursoActual.State = Entidad.States.Modificado;
                    this.Close();
                }
            }
                if (btnAceptar.Text == "Eliminar")
                {
                    DocCursoLogic doc = new DocCursoLogic();
                    doc.Delete(DocCursoActual.ID);
                    DocCursoActual.State = Entidad.States.Eliminado;
                    GuardarCambios();
                    this.Close();
                }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
