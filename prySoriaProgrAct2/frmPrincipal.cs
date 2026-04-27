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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void agregarNuevosClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Formulario=new frmCargarClientes();//La palabra formulario puede ser cualquier nombre
            //Formulario.MdiParent = this;//opcional
            Formulario.Show();
        }

        private void listadoDeTodosLosClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Formulario = new frmListadoClientes();//La palabra formulario puede ser cualquier nombre
            //Formulario.MdiParent = this;//opcional
            Formulario.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void listadoDeClientesDeudoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formulario=new frmClientesDeudores();
            formulario.Show();
        }
    }
}
