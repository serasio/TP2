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
    public partial class CursoDesktop : ApplicationForm
    {
        List<Comision> listcom = new List<Comision>();
        List<Materia> listmat = new List<Materia>();
        public CursoDesktop()
        {
            InitializeComponent();
        }

        public CursoDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
        }

        public CursoDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            CursoLogic curso = new CursoLogic();
            CursoActual = curso.GetOne(ID);
            MapearDeDatos();
        }

        private Curso _cursoActual;

        public Curso CursoActual
        {
            get { return _cursoActual; }
            set { _cursoActual = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            this.comboIDComision.SelectedText = this.CursoActual.IDComision.ToString();
            this.comboIDMateria.SelectedText = this.CursoActual.IDMateria.ToString();
            if (Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }

            if (Modo == ModoForm.Consulta)
            {
                txtID.ReadOnly = true;
                txtAnioCalendario.ReadOnly = true;
                txtCupo.ReadOnly = true;
                comboIDComision.Enabled = false;
                comboIDMateria.Enabled = false;
                btnAceptar.Text = "Aceptar";
            }

            if (Modo == ModoForm.Baja)
            {
                txtAnioCalendario.ReadOnly = true;
                txtCupo.ReadOnly = true;
                comboIDComision.Enabled = false;
                comboIDMateria.Enabled = false;
                btnAceptar.Text = "Eliminar";
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Curso curso = new Curso();
                CursoActual = curso;
                CursoActual.AnioCalendario = int.Parse(txtAnioCalendario.Text);
                CursoActual.Cupo = int.Parse(txtCupo.Text);
                CursoActual.IDComision = listcom[comboIDComision.SelectedIndex].ID;
                CursoActual.IDMateria = listmat[comboIDMateria.SelectedIndex].ID;
                CursoActual.State = Entidad.States.Nuevo;
            }

            if (Modo == ModoForm.Modificacion)
            {
                this.CursoActual.AnioCalendario = int.Parse(this.txtAnioCalendario.Text);
                this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                CursoActual.IDComision = listcom[comboIDComision.SelectedIndex].ID;
                CursoActual.IDMateria = listmat[comboIDMateria.SelectedIndex].ID;
                CursoActual.State = Entidad.States.Modificado;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            CursoLogic curso = new CursoLogic();
            curso.Save(CursoActual);
        }

        public override bool Validar()
        {
            if (this.txtAnioCalendario.Text.Length < 1)
            {
                Notificar("No puedes dejar el año sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.txtCupo.Text.Length < 1)
            {
                Notificar("No puedes dejar el cupo sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.comboIDComision.SelectedIndex == -1)
            {
                Notificar("Debes seleccionar la comision a la que corresponde el curso", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.comboIDMateria.SelectedIndex == -1)
            {
                Notificar("Debes seleccionar la materia a la que corresponde el curso", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int result = 0;
            if (!int.TryParse(txtAnioCalendario.Text, out result) || result <= 0)
            {
                Notificar("Debes ingresar un entero positivo mayor a cero en el año calendario!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (int.Parse(txtAnioCalendario.Text) < (int)DateTime.Now.Year)
            {
                Notificar("Debes ingresar un año mayor o igual al año actual!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if ((!int.TryParse(txtCupo.Text, out result)) || result <= 0)
            {
                Notificar("Debes ingresar un entero positivo mayor a cero en el cupo!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CursoDesktop_Load(object sender, EventArgs e)
        {
            ComisionLogic comision = new ComisionLogic();
            MateriaLogic materia = new MateriaLogic();
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                listcom = comision.GetAll();
                listmat = materia.GetAll();
                if (listcom.Count >= 1)
                {
                    comboIDComision.DataSource = listcom;
                    comboIDComision.DisplayMember = "ComisionEspDesc";
                }

                else
                {
                    comboIDComision.Text = "No hay comisiones cargadas";
                    comboIDComision.Enabled = false;
                    comboIDMateria.Enabled = false;
                    btnAceptar.Visible = false;
                }

                if (listmat.Count >= 1)
                {
                    comboIDMateria.DataSource = listmat;
                    comboIDMateria.DisplayMember = "Descripcion";
                }

                else
                {
                    comboIDMateria.Text = "No hay materias cargadas";
                    comboIDComision.Enabled = false;
                    comboIDMateria.Enabled = false;
                    btnAceptar.Visible = false;
                }
            }
            if (Modo == ModoForm.Baja)
            {
                listmat.Clear();
                listmat.TrimExcess();
                listcom.Clear();
                listcom.TrimExcess();
                listcom.Add(comision.GetOne(CursoActual.IDComision));
                listmat.Add(materia.GetOne(CursoActual.IDMateria));
                comboIDComision.DataSource = listcom;
                comboIDComision.DisplayMember = "Descripcion";
                comboIDMateria.DataSource = listmat;
                //en el combo no aparece la materia correspondiente a la entidad seleccionada a ser eliminada
                comboIDMateria.DisplayMember = "Descripcion";

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAceptar.Text == "Guardar")
            {
                if (Validar())
                {
                    Comision comSelec = listcom[comboIDComision.SelectedIndex];
                    Materia matSelec = listmat[comboIDMateria.SelectedIndex];
                    GuardarCambios();
                    CursoActual.State = Entidad.States.Modificado;
                    this.Close();
                }
            }

            if (btnAceptar.Text == "Eliminar")
            {
                CursoLogic cur = new CursoLogic();
                cur.Delete(CursoActual.ID);
                CursoActual.State = Entidad.States.Eliminado;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboIDComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                MateriaLogic mat = new MateriaLogic();
                listmat = mat.GetAll(listcom[comboIDComision.SelectedIndex].IDPlan);
                if (listmat.Count >= 1)
                {
                    comboIDMateria.DataSource = listmat;
                    comboIDMateria.Enabled = true;
                    btnAceptar.Visible = true;
                    comboIDMateria.DisplayMember = "Descripcion";
                }
                else
                {
                    btnAceptar.Visible = false;
                    comboIDMateria.Enabled = false;
                    comboIDComision.Text = "No hay planes cargados";
                }
            }

        }
    }
}
