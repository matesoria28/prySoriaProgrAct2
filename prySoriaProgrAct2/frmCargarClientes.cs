using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySoriaProgrAct2
{
    public partial class frmCargarClientes : Form
    {
        public frmCargarClientes()
        {
            InitializeComponent();
        }


        clsArchivoClientes x = new clsArchivoClientes();


        private void btnCargar_Click(object sender, EventArgs e)
        {
           
            if (x.ExisteCodigo(txtCodigo.Text))
            {
                MessageBox.Show("El código ingresado ya existe", "Código Duplicado",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtCodigo.Focus(); // marca el error en el cursor
                txtCodigo.SelectAll();
            }
            else
            {
                x.Grabar(txtCodigo.Text, txtNombre.Text, txtDeuda.Text, txtLimite.Text);
                MessageBox.Show("Los datos se grabaron correctamente", "Datos cargados",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDeuda.Text = "";
            txtLimite.Text = "";

        }
        private void Comprobar()
        {
            if (txtCodigo.Text != "" && txtNombre.Text != "" && txtDeuda.Text != "" && txtLimite.Text != "")
            {
                btnCargar.Enabled = true;
            }
            else
            {
                btnCargar.Enabled = false;
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            Comprobar();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            Comprobar();
        }

        private void txtDeuda_TextChanged(object sender, EventArgs e)
        {
            Comprobar();
        }

        private void txtLimite_TextChanged(object sender, EventArgs e)
        {
            Comprobar();
        }

        private void frmCargarClientes_Load(object sender, EventArgs e)
        {

        }
    }
}
