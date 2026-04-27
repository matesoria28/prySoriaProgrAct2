using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//Libreria para trabajar con archivos
using System.Windows.Forms;
using System.Linq.Expressions;//Libreria para trabajar con formularios
namespace prySoriaProgrAct2
{
    internal class clsArchivoClientes
    {

        public string NombreArchivo = "Clientes.csv";

        public void Grabar(string cod,string nom,string deu,string lim)
        {
            //Abrir
            StreamWriter AD = new StreamWriter(NombreArchivo,true);
            //Cargar o Leer
            AD.Write(cod);
            AD.Write(";"); //separador de campos
            AD.Write(nom);
            AD.Write(";");
            AD.Write(deu);
            AD.Write(";");
            AD.WriteLine(lim);
            //Cerrar
            AD.Close();
            AD.Dispose();
        }

        public void Listar(DataGridView Grilla)
        {
            string DatosLeidos;
            string[] vecDatos= new string[4];

            //Abrir
            StreamReader AD = new StreamReader(NombreArchivo);
            //leer
            DatosLeidos= AD.ReadLine();
            Grilla.Rows.Clear();
            while (DatosLeidos != null)
            {
                vecDatos = DatosLeidos.Split(';');
                Grilla.Rows.Add(vecDatos[0], vecDatos[1], vecDatos[2], vecDatos[3]);
                DatosLeidos = AD.ReadLine();
            }
            //Cerrar
            AD.Close();
            AD.Dispose();
        }
        public Int32 CantidadClientes()
        {
            string DatosLeidos;
            Int32 C = 0;
            //Abrir
            StreamReader AD=new StreamReader(NombreArchivo);
            //Leer
            DatosLeidos = AD.ReadLine();
            while (DatosLeidos != null)
            {
                C++;
                DatosLeidos = AD.ReadLine();
            }
            //Cerrar
            AD.Close();
            AD.Dispose();
            return C;
        }

        public Decimal DeudaClientes()
        {
            string DatosLeidos;
            string[] vecDatos = new string[4];
            Decimal Total = 0;
            //Abrir
            StreamReader AD = new StreamReader(NombreArchivo);
            //Leer
            DatosLeidos = AD.ReadLine();
            while (DatosLeidos != null)
            {
                vecDatos = DatosLeidos.Split(';');
                Total=Total +Convert.ToDecimal(vecDatos[2]);
                DatosLeidos = AD.ReadLine();
            }
            //Cerrar
            AD.Close();
            AD.Dispose();
            return Total;
        }

        public Decimal PromedioDeuda()
        {
            string DatosLeidos;
            string[] vecDatos = new string[4];
            Decimal Total = 0;
            Int32 C = 0;
            //Abrir
            StreamReader AD = new StreamReader(NombreArchivo);
            //Leer
            DatosLeidos = AD.ReadLine();
            while (DatosLeidos != null)
            {
                C++;
                vecDatos = DatosLeidos.Split(';');
                Total = Total + Convert.ToDecimal(vecDatos[2]);
                DatosLeidos = AD.ReadLine();
            }
            //Cerrar
            AD.Close();
            AD.Dispose();
            return Total/C;
        }

        public void ListarDeudores(DataGridView Grilla)
        {
            string DatosLeidos;
            string[] vecDatos = new string[4];

            //Abrir
            StreamReader AD = new StreamReader(NombreArchivo);
            //leer
            DatosLeidos = AD.ReadLine();
            Grilla.Rows.Clear();
            while (DatosLeidos != null)
            {
                vecDatos = DatosLeidos.Split(';');

                if (Convert.ToDecimal(vecDatos[2]) > 0)
                {

                    Grilla.Rows.Add(vecDatos[0], vecDatos[1], vecDatos[2], vecDatos[3]);
                }
                    
                DatosLeidos = AD.ReadLine();
            }
            //Cerrar
            AD.Close();
            AD.Dispose();
        }

       

    }
}
