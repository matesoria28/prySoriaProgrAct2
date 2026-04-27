using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;//Libreria para trabajar con archivos


namespace prySoriaProgrAct2
{
    public partial class frmClientesDeudores : Form
    {
        public frmClientesDeudores()
        {
            InitializeComponent();
        }
        clsArchivoClientes x = new clsArchivoClientes();
        private void frmClientesDeudores_Load(object sender, EventArgs e)
        {
            x.ListarDeudores(dgvClientes);
            lblCantidad2.Text = x.CantidadClientes().ToString();
            lblTotal2.Text = x.DeudaClientes().ToString();
            lblPromedio2.Text = x.PromedioDeuda().ToString();
        }
    }
}
