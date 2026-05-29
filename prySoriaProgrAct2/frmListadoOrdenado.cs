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
    public partial class frmListadoOrdenado : Form
    {
        public frmListadoOrdenado()
        {
            InitializeComponent();
        }

        clsArchivoClientes x = new clsArchivoClientes();
        private void btnListar_Click(object sender, EventArgs e)
        {
            x.CargarVector();

            switch (cmbCampo.SelectedIndex)
            {
                case 0:
                    if (cmbModo.SelectedIndex == 0)
                        x.OrdenarPorCodigoAscendente();
                    else
                        x.OrdenarPorCodigoDescendente();
                    break;
                case 1:
                    if (cmbModo.SelectedIndex == 0)
                        x.OrdenarPorNombreAscendente();
                    else
                        x.OrdenarPorNombreDescendente();
                    break;
                case 2:
                    if (cmbModo.SelectedIndex == 0)
                        x.OrdenarPorDeudaAscendente();
                    else
                        x.OrdenarPorDeudaDescendente();
                    break;
                case 3:
                    if (cmbModo.SelectedIndex == 0)
                        x.OrdenarPorLimiteAscendente();
                    else
                        x.OrdenarPorLimiteDescendente();
                    break;
            }


            x.ReescribirArchivo();
            x.Listar(dgvListado);
        }

        private void frmListadoOrdenado_Load(object sender, EventArgs e)
        {
            cmbCampo.Items.Add("Código");
            cmbCampo.Items.Add("Nombre");
            cmbCampo.Items.Add("Deuda");
            cmbCampo.Items.Add("Limite Crédito");


            cmbModo.Items.Add("Ascendente");
            cmbModo.Items.Add("Descendente");
        }


       
    }
}
