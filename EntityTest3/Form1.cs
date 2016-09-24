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

namespace EntityTest3
{
    public partial class frmEstudiantes : Form
    {
        private ESTUDIANTE estudiante = new ESTUDIANTE();
        public frmEstudiantes()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dgvEstudiantes.DataSource = estudiante.GetEstudianteList();
        }

        public void CargarAlumnos() {
            dgvEstudiantes.DataSource = estudiante.GetEstudianteList();
        }

        private void dgvEstudiantes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            
            
        }

        private void dgvEstudiantes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                decimal id = Convert.ToDecimal(dgvEstudiantes.Rows[e.RowIndex].Cells[0].Value);
                Console.WriteLine("id:{0}", id);
                DatosEstudiante de = new DatosEstudiante(id, this);
                de.ShowDialog();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            DatosEstudiante de = new DatosEstudiante(0,this);
            de.ShowDialog();
        }
    }
}
