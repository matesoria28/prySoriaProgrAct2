using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//Libreria para trabajar con archivos
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters;//Libreria para trabajar con formularios
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

        public void GenerarReporte()
        {
           Int32 Cantidad = 0;
           Decimal total = 0;
            string DatosLeidos;
            string[] vecDatos = new string[4];
            StreamWriter Reporte = new StreamWriter("Reporte.csv",false,Encoding.UTF8);

            Reporte.WriteLine("Listado de Clientes");
            Reporte.WriteLine("");
            Reporte.WriteLine("Código;Nombre;Deuda;Límite");


            //Abrir
            StreamReader AD = new StreamReader(NombreArchivo);
            //leer
            DatosLeidos = AD.ReadLine();

            while (DatosLeidos != null)
            {
                vecDatos = DatosLeidos.Split(';');

                Reporte.Write(vecDatos[0]);
                Reporte.Write(";");
                Reporte.Write(vecDatos[1]);
                Reporte.Write(";");
                Reporte.Write(vecDatos[2]);
                Reporte.Write(";");
                Reporte.WriteLine(vecDatos[3]);

                DatosLeidos = AD.ReadLine();
                Cantidad++; //contador
                total = total + Convert.ToDecimal(vecDatos[2]);//Acumulador
            }

            //Cerrar
            AD.Close();
            AD.Dispose();

            Reporte.WriteLine(""); ;
            Reporte.Write("Total de Deuda:;;");
            Reporte.WriteLine(total);

            Reporte.Write("Cantidad de Clientes:;;");
            Reporte.WriteLine(Cantidad);

            Reporte.Write("Promedio de Deuda:;;");
            Reporte.WriteLine(total/Cantidad);

            Reporte.Close();
            Reporte.Dispose();
        }

        private struct RegClientes
        {
            public Int32 Codigo;
            public String Nombre;
            public Decimal Deuda;
            public Decimal Limite;
        }

        private RegClientes[] vecClientes = new RegClientes[1500];
        private Int32 IND = 0;

        private void CargarVector()
        {
            string DatosLeidos;
            string[] VecDatos = new string[4];
            IND = 0;
            //ABRIR
            StreamReader AD = new StreamReader(NombreArchivo);
            //LEER
            DatosLeidos = AD.ReadLine();

            while (DatosLeidos != null)
            {
                VecDatos = DatosLeidos.Split(';');
                vecClientes[IND].Codigo = Convert.ToInt32(VecDatos[0]);
                vecClientes[IND].Nombre = Convert.ToString(VecDatos[1]);
                vecClientes[IND].Deuda = Convert.ToDecimal(VecDatos[2]);
                vecClientes[IND].Limite = Convert.ToDecimal(VecDatos[3]);
                IND++;
                DatosLeidos = AD.ReadLine();
            }
            //CERRAR
            AD.Close();
            AD.Dispose();
        }

        private void OrdenarVector()
        {
            
            RegClientes aux;
            for(Int32 c=0; c<IND-1; c++)//Contador de vueltas
            {
                for(Int32 i=0; i<IND-1; i++)
                if (vecClientes[i].Codigo > vecClientes[i+1].Codigo)
                {
                    aux = vecClientes[i];
                    vecClientes[i] = vecClientes[i + 1];
                    vecClientes[i + 1] = aux;
                }
            }
        }

        private void ReescribirArchivo()
        {
            StreamWriter AD = new StreamWriter(NombreArchivo, false);
            for(Int32 i=0; i<IND; i++)
            {
                AD.Write(vecClientes[i].Codigo);
                AD.Write(';');
                AD.Write(vecClientes[i].Nombre);
                AD.Write(';');
                AD.Write(vecClientes[i].Deuda);
                AD.Write(';');
                AD.WriteLine(vecClientes[i].Limite);
            }
            AD.Close();
            AD.Dispose();

        }

        public void OrdenarArchivo()
        {
            CargarVector();
            OrdenarVector();
            ReescribirArchivo();

        }





    }

}
