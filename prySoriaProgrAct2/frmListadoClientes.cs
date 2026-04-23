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
    public partial class frmListadoClientes : Form
    {
        public frmListadoClientes()
        {
            InitializeComponent();
        }
        clsArchivoClientes x = new clsArchivoClientes();
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmListadoClientes_Load(object sender, EventArgs e)
        {
            x.Listar(dgvClientes);
        }
    }
}
