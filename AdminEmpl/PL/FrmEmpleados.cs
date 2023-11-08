using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminEmpl.DAL;
using AdminEmpl.BLL;

namespace AdminEmpl.PL
{
    public partial class FrmEmpleados : Form
    {
        byte[] imagenByte;
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            DepartamentosDAL objDeppartamentos = new DepartamentosDAL();
            cbxDepartamento.DataSource = objDeppartamentos.MostrarDepartamentos().Tables[0];
            cbxDepartamento.DisplayMember = "departamento";
            cbxDepartamento.ValueMember = "ID";

        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectorImagen = new OpenFileDialog();
            selectorImagen.Title = "Seleccionar imagen";
            if (selectorImagen.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image = Image.FromStream(selectorImagen.OpenFile());
                MemoryStream memoria = new MemoryStream();
                picFoto.Image.Save(memoria,System.Drawing.Imaging.ImageFormat.Png);
                imagenByte = memoria.ToArray();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            RecolectarDatos();
        }
        private void RecolectarDatos()
        {

            EmpleadosBLL objEmpleados = new EmpleadosBLL();
            int codigoEmpleado = 1;

            int.TryParse(txtID.Text, out codigoEmpleado);

            objEmpleados.ID = codigoEmpleado;
            objEmpleados.NombreEmpleado = txtNombre.Text;
            objEmpleados.PrimerApellidp = txtPrimerApellido.Text;
            objEmpleados.SegundoApellido = txtSegundoApellido.Text;
            objEmpleados.Correo = txtCorreo.Text;
            int IDDepartamento = 0; 
            int.TryParse(cbxDepartamento.SelectedValue.ToString(), out IDDepartamento);

            objEmpleados.Departamento = IDDepartamento;

            objEmpleados.FotoEmpleado = imagenByte;












        }
    }
}
