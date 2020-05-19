using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace Lab6
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Empresa> corp;
            Central central = new Central();
            string eleccion;
            bool start = true;
            corp = central.EMPRESAS;


            while(start)
            {
                Console.WriteLine("Desea cargar un archivo para acceder a la informacion de la empresa?");
                Console.WriteLine("[1] SI\n" +
                                  "[2] NO\n" +
                                  "[3] Salir");

                eleccion = Console.ReadLine();

                switch (eleccion)
                {
                    case "1":
                        if (central.EMPRESAS.Count != 0)
                        {
                            CargarEmpresa(central.EMPRESAS);
                            central.MostrarEmpresasGeneradas();
                        }         
                        
                        else if(central.EMPRESAS.Count == 0)
                        {
                            Console.WriteLine("No se ha encontrado el archivo...");
                            central.IngresoEmpresa();
                            GuardarEmpresa(central.EMPRESAS);
                        }
                        break;
                    case "2":
                        central.IngresoEmpresa();
                        try
                        {
                            GuardarEmpresa(corp);
                        }
                        catch(FileNotFoundException)
                        {
                            Console.WriteLine("No se pudo guardar");
                        }
                        break;
                    case "3":
                        start = false;
                        break;
                    default:
                        break;
                }
            }
        }

        static public void GuardarEmpresa(List<Empresa> empresas)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresas.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, empresas);
            stream.Close();
        }

        static public List<Empresa> CargarEmpresa(List<Empresa> empresas)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresas.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            empresas = (List<Empresa>)formatter.Deserialize(stream);
            stream.Close();
            return empresas;
        }
    }
}
