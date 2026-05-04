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
       

        private void frmListadoClientes_Load(object sender, EventArgs e)
        {
            x.Listar(dgvClientes);
            lblCantidad2.Text=x.CantidadClientes().ToString();
            lblTotal2.Text=x.DeudaClientes().ToString();
            lblPromedio2.Text=x.PromedioDeuda().ToString();

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            x.GenerarReporte();
            MessageBox.Show("Reporte generado con exito");
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            x.OrdenarArchivo();
            MessageBox.Show("Archivo ordenado con exito");  
            x.Listar(dgvClientes);
        }
    }
}
