using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminEmpl.DAL;
using AdminEmpl.BLL;


namespace AdminEmpl.PL
{
    public partial class FrmDepartamentos : Form
    {
        DepartamentosDAL oDepartamentosDAL;

        public FrmDepartamentos()
        {
            oDepartamentosDAL = new DepartamentosDAL(); 
            InitializeComponent();
            LlegarGrid();
            LimpiarEntradas();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {

            oDepartamentosDAL.Agregar(RecuperarInformacion());
            LlegarGrid();
            LimpiarEntradas();

        }

        private DepartamentoBLL RecuperarInformacion ()
        {
            DepartamentoBLL oDepartamentoBLL = new DepartamentoBLL(); 
            
            int ID = 0; int.TryParse(txtID.Text, out ID);

            oDepartamentoBLL.ID = ID;

            oDepartamentoBLL.Departamento = txtNombre.Text;

            return oDepartamentoBLL;


        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int Indice = e.RowIndex;
            dgvDepartamentos.ClearSelection();

            if (Indice>=0)

            txtID.Text = dgvDepartamentos.Rows[Indice].Cells[0].Value.ToString();
            txtNombre.Text = dgvDepartamentos.Rows[Indice].Cells[1].Value.ToString();

            txtID.Text = "";
            txtNombre.Text = "";
            btnAgregar.Enabled = false;
            btnBorrar.Enabled = true;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;

        }
        
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oDepartamentosDAL.Eliminar(RecuperarInformacion());
            LlegarGrid();
            LimpiarEntradas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oDepartamentosDAL.Modificar(RecuperarInformacion());
            LlegarGrid();
            LimpiarEntradas();
        }
        public void LlegarGrid()
        {
            dgvDepartamentos.DataSource = oDepartamentosDAL.MostrarDepartamentos().Tables[0];
            dgvDepartamentos.Columns[0].HeaderText = "ID";
            dgvDepartamentos.Columns[0].HeaderText = "Nombre Departamento";
        }

        public void LimpiarEntradas()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            btnAgregar.Enabled = true;
            btnBorrar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }
    }
}
