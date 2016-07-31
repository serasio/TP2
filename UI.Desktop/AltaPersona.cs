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
    public partial class AltaPersona : ApplicationForm
    {
        public AltaPersona()
        {
            InitializeComponent();
        }

        private void AltaPersona_Load(object sender, EventArgs e)
        {
            comboTipoPersona.Items.Add("1 - Alumno");
            comboTipoPersona.Items.Add("2 - Profesor");
        }


        public new void Notificar(string mensaje, string titulo, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public new void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(mensaje, this.Text, botones, icono);
        }

        public override bool Validar()
        {
            if (comboTipoPersona.SelectedIndex == -1)
            {
                Notificar("Por favor, selecciona un tipo de la lista!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                if (comboTipoPersona.SelectedIndex == (int)Persona.TiposPersonas.Alumno)
                {
                    AlumnoDesktop alu = new AlumnoDesktop(ApplicationForm.ModoForm.Alta);
                    alu.btnAceptar.Text = "Guardar";
                    alu.ShowDialog();
                    this.Close();
                }
                else if (comboTipoPersona.SelectedIndex == (int)Persona.TiposPersonas.Docente)
                {
                    DocenteDesktop doc = new DocenteDesktop(ApplicationForm.ModoForm.Alta);
                    doc.btnAceptar.Text = "Guardar";
                    doc.ShowDialog();
                    this.Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
