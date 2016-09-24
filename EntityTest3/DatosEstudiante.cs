using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityTest3.Model;
using EntityTest3;

namespace EntityTest3
{
    public partial class DatosEstudiante : Form
    {
        private ESTUDIANTE estudianteModel = new ESTUDIANTE();
        private frmEstudiantes f1;
        private decimal id;

        public DatosEstudiante()
        {
            InitializeComponent();                        
        }

        public DatosEstudiante(decimal id, frmEstudiantes f1)
        {

            InitializeComponent();

            this.id = id;
            this.f1 = f1;

            if (this.id > 0) {
                ESTUDIANTE e = estudianteModel.GetEstudiante((int)id);
                txtID.Text = e.ID.ToString();
                txtNombre.Text = e.NOMBRE;
                txtApellidos.Text = e.APELLIDO;
                txtEmail.Text = e.EMAIL;
                txtEdad.Text = e.EDAD.ToString();
                dtpFechaNacimiento.Value = e.FECHA_NACIMIENTO;
                if (e.SEXO == 1)
                {
                    rbtnMasculino.Checked = true;
                    rbtnFemenino.Checked = false;
                }
                else
                {
                    rbtnMasculino.Checked = false;
                    rbtnFemenino.Checked = true;
                }
            }
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMasculino.Checked) {
                rbtnFemenino.Checked = false;
            }
        }

        private void rbtnFemenino_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMasculino.Checked)
            {
                rbtnMasculino.Checked = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            estudianteModel.ID = (string.IsNullOrEmpty(txtID.Text)? 0 : Convert.ToDecimal(txtID.Text));
            estudianteModel.NOMBRE = txtNombre.Text;
            estudianteModel.APELLIDO = txtApellidos.Text;
            estudianteModel.EMAIL = txtEmail.Text;
            estudianteModel.EDAD = Convert.ToDecimal(txtEdad.Text);
            estudianteModel.SEXO = (rbtnMasculino.Checked ? 1 : 0);
            estudianteModel.FECHA_NACIMIENTO = dtpFechaNacimiento.Value;
            estudianteModel.SaveEstudiante(estudianteModel);

            this.f1.CargarAlumnos();
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {            
            estudianteModel.DeleteEstudiante(Convert.ToInt32(txtID.Text));
            this.f1.CargarAlumnos();
            this.Close();
        }
    }
}
