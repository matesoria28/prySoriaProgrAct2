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
            x.Grabar(txtCodigo.Text,txtNombre.Text,txtDeuda.Text,txtLimite.Text);
            MessageBox.Show("Cliente cargado correctamente");

        }
    }
}
