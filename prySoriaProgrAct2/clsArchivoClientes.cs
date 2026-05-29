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
            String datoLeido;
            string[] vecDatos = new string[4];

            StreamReader AD = new StreamReader(NombreArchivo);
            datoLeido = AD.ReadLine();
            Grilla.Rows.Clear();

            while (datoLeido != null)
            {
                vecDatos = datoLeido.Split(';');

                Grilla.Rows.Add(vecDatos[0], vecDatos[1], vecDatos[2], vecDatos[3]);
                datoLeido = AD.ReadLine();
            }
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

        public void CargarVector()
        {
            String datoLeido;
            string[] vecDatos = new string[4];
            IND = 0;

            StreamReader AD = new StreamReader(NombreArchivo);
            datoLeido = AD.ReadLine();

            while (datoLeido != null)
            {
                vecDatos = datoLeido.Split(';');
                vecClientes[IND].Codigo = Convert.ToInt32(vecDatos[0]);
                vecClientes[IND].Nombre = vecDatos[1];
                vecClientes[IND].Deuda = Convert.ToDecimal(vecDatos[2]);
                vecClientes[IND].Limite = Convert.ToDecimal(vecDatos[3]);
                IND++;
                datoLeido = AD.ReadLine();

            }
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

        public void ReescribirArchivo()
        {
            StreamWriter AD = new StreamWriter(NombreArchivo, false); //borra datos cargados y graba los nuevos pero de forma ordenada

            for (int i = 0; i < IND; i++)
            {
                AD.Write(vecClientes[i].Codigo);
                AD.Write(";");
                AD.Write(vecClientes[i].Nombre);
                AD.Write(";");
                AD.Write(vecClientes[i].Deuda);
                AD.Write(";");
                AD.WriteLine(vecClientes[i].Limite);
            }

            //CERRAR
            AD.Close();
            AD.Dispose();
        }

        public void OrdenarArchivo()
        {
            CargarVector();
            OrdenarVector();
            ReescribirArchivo();

        }


        public void OrdenarPorCodigoAscendente()
        {
            Int32 C = 0;
            while (C < IND - 1)
            {
                Int32 i = 0;
                RegClientes Aux;
                while (i < IND - 1)
                {
                    if (vecClientes[i].Codigo > vecClientes[i + 1].Codigo)
                    {
                        Aux = vecClientes[i];
                        vecClientes[i] = vecClientes[i + 1];
                        vecClientes[i + 1] = Aux;
                    }
                    i++;
                }
                C++;
            }
        }

        public void OrdenarPorCodigoDescendente()
        {
            Int32 C = 0;
            while (C < IND - 1)
            {
                Int32 i = 0;
                RegClientes Aux;
                while (i < IND - 1)
                {
                    if (vecClientes[i].Codigo < vecClientes[i + 1].Codigo)
                    {
                        Aux = vecClientes[i];
                        vecClientes[i] = vecClientes[i + 1];
                        vecClientes[i + 1] = Aux;
                    }
                    i++;
                }
                C++;
            }
        }
        public void OrdenarPorNombreAscendente()
        {
            Int32 C = 0;
            while (C < IND - 1)
            {
                Int32 i = 0;
                RegClientes Aux;
                while (i < IND - 1)
                {
                    if (vecClientes[i].Nombre.CompareTo(vecClientes[i + 1].Nombre) > 0)
                    {
                        Aux = vecClientes[i];
                        vecClientes[i] = vecClientes[i + 1];
                        vecClientes[i + 1] = Aux;
                    }
                    i++;
                }
                C++;
            }
        }

        public void OrdenarPorNombreDescendente()
        {
            Int32 C = 0;
            while (C < IND - 1)
            {
                Int32 i = 0;
                RegClientes Aux;
                while (i < IND - 1)
                {
                    if (vecClientes[i].Nombre.CompareTo(vecClientes[i + 1].Nombre) < 0)
                    {
                        Aux = vecClientes[i];
                        vecClientes[i] = vecClientes[i + 1];
                        vecClientes[i + 1] = Aux;
                    }
                    i++;
                }
                C++;
            }
        }
        public void OrdenarPorLimiteAscendente()
        {
            Int32 C = 0;
            while (C < IND - 1)
            {
                Int32 i = 0;
                RegClientes Aux;
                while (i < IND - 1)
                {
                    if (vecClientes[i].Limite > vecClientes[i + 1].Limite)
                    {
                        Aux = vecClientes[i];
                        vecClientes[i] = vecClientes[i + 1];
                        vecClientes[i + 1] = Aux;
                    }
                    i++;
                }
                C++;
            }
        }
        public void OrdenarPorLimiteDescendente()
        {
            Int32 C = 0;
            while (C < IND - 1)
            {
                Int32 i = 0;
                RegClientes Aux;
                while (i < IND - 1)
                {
                    if (vecClientes[i].Limite < vecClientes[i + 1].Limite)
                    {
                        Aux = vecClientes[i];
                        vecClientes[i] = vecClientes[i + 1];
                        vecClientes[i + 1] = Aux;
                    }
                    i++;
                }
                C++;
            }
        }
        public void OrdenarPorDeudaAscendente()
        {
            Int32 C = 0;
            while (C < IND - 1)
            {
                Int32 i = 0;
                RegClientes Aux;
                while (i < IND - 1)
                {
                    if (vecClientes[i].Deuda > vecClientes[i + 1].Deuda)
                    {
                        Aux = vecClientes[i];
                        vecClientes[i] = vecClientes[i + 1];
                        vecClientes[i + 1] = Aux;
                    }
                    i++;
                }
                C++;
            }
        }
        public void OrdenarPorDeudaDescendente()
        {
            Int32 C = 0;
            while (C < IND - 1)
            {
                Int32 i = 0;
                RegClientes Aux;
                while (i < IND - 1)
                {
                    if (vecClientes[i].Deuda < vecClientes[i + 1].Deuda)
                    {
                        Aux = vecClientes[i];
                        vecClientes[i] = vecClientes[i + 1];
                        vecClientes[i + 1] = Aux;
                    }
                    i++;
                }
                C++;
            }
        }

        public bool ExisteCodigo(string cod)
        {
            string datoLeido;
            string[] vecDatos;
            bool encontrado = false;

            // Verificamos si el archivo existe antes de intentar leerlo
            if (File.Exists(NombreArchivo))
            {
                StreamReader AD = new StreamReader(NombreArchivo);
                datoLeido = AD.ReadLine();

                while (datoLeido != null)
                {
                    vecDatos = datoLeido.Split(';');
                    // Comparamos el código del archivo con el que queremos ingresar
                    if (vecDatos[0] == cod)
                    {
                        encontrado = true;
                        break; // Si lo encuentra, sale del bucle
                    }
                    datoLeido = AD.ReadLine();
                }
                AD.Close();
                AD.Dispose();
            }
            return encontrado;
        }

    }

}
