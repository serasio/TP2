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

namespace UI.Desktop
{
    public partial class InscripcionDesktop : ApplicationForm
    {
        public InscripcionDesktop()
        {
            InitializeComponent();

        }

        List<Persona> listalumnos = new List<Persona>();
        List<Curso> listcursos = new List<Curso>();
        List<string> listcondiciones = new List<string>();

        private void InscripcionDesktop_Load(object sender, EventArgs e)
        {
            PersonaLogic pl = new PersonaLogic();
            CursoLogic cl = new CursoLogic();
            AutoCompleteStringCollection accalu = new AutoCompleteStringCollection();
            AutoCompleteStringCollection acccurso = new AutoCompleteStringCollection();
            listalumnos = pl.GetNom(Persona.TiposPersonas.Alumno);
            if (UsuarioLogeado.TipoPersona == Persona.TiposPersonas.Alumno)
                listcursos = cl.GetCursosAlumno(UsuarioLogeado.IDPlan);
            else
                listcursos = cl.GetCursos();

            if (this.Modo == ModoForm.Alta)
            {
                listcondiciones.Add("Cursando");
                cmbCondiciones.DataSource = listcondiciones;
                cmbCondiciones.Enabled = false;
                txtNota.Enabled = false;

                if (listalumnos.Count >= 1)
                {
                    foreach (Persona per in listalumnos)
                    {
                        accalu.Add(per.NombreYApellido);
                    }
                    this.cmbAlumnos.DataSource = listalumnos;
                    this.cmbAlumnos.DisplayMember = "NombreYApellido";
                    this.cmbAlumnos.AutoCompleteCustomSource = accalu;
                    this.cmbAlumnos.AutoCompleteMode = AutoCompleteMode.Suggest;
                    this.cmbAlumnos.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }

                else
                {
                    this.cmbAlumnos.Text = "No hay alumnos cargados";
                    this.cmbAlumnos.Enabled = false;
                    this.cmbCursos.Enabled = false;
                }

                if (listcursos.Count >= 1)
                {
                    foreach (Curso cur in listcursos)
                    {
                        accalu.Add(cur.ComMatYear);
                    }
                    this.cmbCursos.DataSource = listcursos;
                    this.cmbCursos.DisplayMember = "ComMatYear";
                    this.cmbCursos.AutoCompleteCustomSource = acccurso;
                    this.cmbCursos.AutoCompleteMode = AutoCompleteMode.Suggest;
                    this.cmbCursos.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }

                else
                {
                    this.cmbCursos.Text = "No hay cursos cargados";
                    this.cmbAlumnos.Enabled = false;
                    this.cmbCursos.Enabled = false;
                    this.cmbCondiciones.Enabled = false;
                    this.txtNota.Enabled = false;
                }
            }
            else if (Modo == ModoForm.Modificacion)
            {
                listcondiciones.Add("Libre");
                listcondiciones.Add("Cursando");
                listcondiciones.Add("Regular");
                cmbCondiciones.DataSource = listcondiciones;
                cmbAlumnos.DataSource = listalumnos;
                cmbCursos.DataSource = listcursos;
                cmbAlumnos.DisplayMember = "NombreYApellido";
                cmbCursos.DisplayMember = "ComMatYear";
            }           
        }

        public InscripcionDesktop(ModoForm modo, Persona usu) : this()
        {
            this.Modo = modo;
            UsuarioLogeado = usu;
        }

        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.InscripcionActual.ID.ToString();
            this.cmbAlumnos.Text = this.InscripcionActual.AluNomYApe.ToString();
            this.cmbCursos.Text = this.InscripcionActual.ComisionMateriaAnio.ToString();
            this.cmbCondiciones.Text = this.InscripcionActual.Condicion.ToString();
            this.txtNota.Text = this.InscripcionActual.Nota.ToString();
            if (Modo == ModoForm.Baja)
            {
                this.cmbAlumnos.Enabled = false;
                this.cmbCursos.Enabled = false;
                this.cmbCondiciones.Enabled = false;
                this.txtNota.Enabled = false;
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.cmbAlumnos.Enabled = false;
                this.cmbCursos.Enabled = false;
            }
        }
        public override void MapearADatos() 
        {
            if (Modo == ModoForm.Alta)
            {
                AlumnoInscripcion inscripcion = new AlumnoInscripcion();
                this.InscripcionActual = inscripcion;
                this.InscripcionActual.IDCurso = listcursos[cmbCursos.SelectedIndex].ID;
                this.InscripcionActual.IDAlumno = listalumnos[cmbAlumnos.SelectedIndex].ID;
                this.InscripcionActual.Condicion = "Cursando";
                this.InscripcionActual.Nota = 0;
            }

            if (Modo == ModoForm.Modificacion)
            {
                this.InscripcionActual.ID = int.Parse(this.txtID.Text);
                this.InscripcionActual.IDCurso = listcursos[cmbCursos.SelectedIndex].ID;
                this.InscripcionActual.IDAlumno = listalumnos[cmbAlumnos.SelectedIndex].ID;
                this.InscripcionActual.Condicion = listcondiciones[cmbCondiciones.SelectedIndex];
                this.InscripcionActual.Nota = int.Parse(txtNota.Text);
            }
            
        }
        
        public override void GuardarCambios() 
        {
            MapearADatos();
            AluInscripcionLogic il = new AluInscripcionLogic();
            il.Save(InscripcionActual);
        }

        public override bool Validar()
        {

            if (this.cmbAlumnos.SelectedIndex == -1)
            {
                Notificar("Elija un alumno a inscribir!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.cmbCursos.SelectedIndex == -1)
            {
                Notificar("Elija curso a inscribir!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Modo == ModoForm.Modificacion)
            {
                int result = 0;

                if (!int.TryParse(txtNota.Text, out result) || result <= 0 || result > 10)
                {
                    Notificar("Ingrese una nota entera entre 0 y 10!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (this.cmbCondiciones.SelectedIndex == -1)
            {
                Notificar("Elija la condición del alumno!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private AlumnoInscripcion _inscripcionActual;

        public AlumnoInscripcion InscripcionActual
        {
            get { return _inscripcionActual; }
            set { _inscripcionActual = value; }
        }

        private Persona _AlumnoActual;

        public Persona AlumnoActual
        {
            get { return _AlumnoActual; }
            set { _AlumnoActual = value; }
        }

        private Curso _CursoActual;

        public Curso CursoActual
        {
            get { return _CursoActual; }
            set { _CursoActual = value; }
        }
        
        public InscripcionDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            AluInscripcionLogic aluInscripcion = new AluInscripcionLogic();
            InscripcionActual = aluInscripcion.GetOne(ID);
            PersonaLogic alu = new PersonaLogic();
            AlumnoActual = alu.GetOne(InscripcionActual.IDAlumno, Persona.TiposPersonas.Alumno);
            CursoLogic cur = new CursoLogic();
            CursoActual = cur.GetOne(InscripcionActual.IDCurso);
            if (Modo == ModoForm.Modificacion || Modo == ModoForm.Baja)
                MapearDeDatos();
        }

        public InscripcionDesktop(int ID, ModoForm modo, Persona usu) : this()
        {
            this.Modo = modo;
            UsuarioLogeado = usu;
            AluInscripcionLogic aluInscripcion = new AluInscripcionLogic();
            InscripcionActual = aluInscripcion.GetOne(ID);
            PersonaLogic alu = new PersonaLogic();
            AlumnoActual = alu.GetOne(InscripcionActual.IDAlumno, Persona.TiposPersonas.Alumno);
            CursoLogic cur = new CursoLogic();
            CursoActual = cur.GetOne(InscripcionActual.IDCurso);
            if (Modo == ModoForm.Modificacion || Modo == ModoForm.Baja)
                MapearDeDatos();
        }

        private Persona _usuarioLogeado;

        public Persona UsuarioLogeado
        {
            get { return _usuarioLogeado; }
            set { _usuarioLogeado = value; }
        }

        public void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAceptar.Text == "Guardar")
            {
                if (Validar())
                {
                    GuardarCambios();
                    InscripcionActual.State = Entidad.States.Modificado;
                    this.Close();
                }
            }
            if (btnAceptar.Text == "Eliminar")
            {
                AluInscripcionLogic aluInscripcion = new AluInscripcionLogic();
                aluInscripcion.Delete(InscripcionActual.ID);
                InscripcionActual.State = Entidad.States.Eliminado;
                GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*private void cmbAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                CursoLogic curso = new CursoLogic();
                listcursos = curso.GetCursosAlumno(listalumnos[cmbAlumnos.SelectedIndex].IDPlan);
                if (listcursos.Count >= 1)
                {
                    cmbCursos.DataSource = listcursos;
                    cmbCursos.Enabled = true;
                    btnAceptar.Visible = true;
                    cmbCursos.DisplayMember = "ComMatYear";
                }
                else
                {
                    btnAceptar.Visible = false;
                    cmbCursos.Enabled = false;
                    cmbCursos.Text = "No hay cursos cargados";
                }
            }*/
        }
 }
