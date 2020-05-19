using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace Lab6
{
    class Central
    {
        List<Empresa> empresas = new List<Empresa>();

        public Central()
        {
            //
        }
         

        public List<Empresa> EMPRESAS { get { return this.empresas; } }

        public void IngresoEmpresa()
        {
            string nombre, rut;
            Console.WriteLine("Ingrese nombre de la empresa: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese rut de la empresa");
            rut = Console.ReadLine();
            Empresa empresa = new Empresa(nombre, rut);
            GeneradorEmpresa(empresa);
            empresas.Add(empresa);
        }

        public void MostrarEmpresa()
        {
            foreach(var i in empresas)
            {
                Console.WriteLine($"Nombre de la Empresa: {i.NOMBRE}");
                Console.WriteLine($"Rut de la Empresa: {i.RUT}");
            }
        }

        public void CrearDivisiones() //Metodo Para crear la empresa de forma Manual. Se modifico el Main para la Parte 4 
        {
            bool start = true;
            string eleccion, eleccion2;
            int numero1 = 1, numero2 = 1, numero3 = 1, numero4 = 1;

            while (start)
            {
                Console.WriteLine("Desea agregar una Division?");
                Console.WriteLine("[1] SI\n" +
                                  "[2] NO\n");
                eleccion = Console.ReadLine();
                switch (eleccion)
                {
                    case "1":
                        Console.WriteLine("Que Division desea crear?");
                        Console.WriteLine("[1] Area\n" +
                                          "[2] Departamento\n" +
                                          "[3] Seccion\n" +
                                          "[4] Bloque\n" );

                        eleccion2 = Console.ReadLine();

                        switch(eleccion2)
                        {
                            case "1":
                                Area area;
                                area = ConstruccionArea(numero1);
                                CantidadDepartamentos(area);
                                foreach(var i in area.DEPARTAMENTOS)
                                {
                                    CantidadSecciones(i);
                                    foreach (var e in i.SECCIONES)
                                    {
                                        CantidadBloques(e);
                                    }
                                }
                                numero1++;
                                break;
                            case "2":
                                Departamento departamento;
                                departamento = ConstruccionDepartamento(numero2);
                                CantidadSecciones(departamento);
                                foreach (var i in departamento.SECCIONES)
                                {
                                    CantidadBloques(i);
                                }
                                numero2++;
                                break;
                            case "3":
                                Seccion seccion;
                                seccion = ConstruccionSeccion(numero3);
                                CantidadBloques(seccion);
                                numero3++;
                                break;
                            case "4":
                                Bloque bloque;
                                bloque = ConstruccionBloque(numero4);
                                numero4++;
                                break;
                            default:
                                break;
                        }
                        break;
                    case "2":
                        start = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public Persona CreacionPersonas(string division)
        {
            string nombre, apellido, rut;
            Console.WriteLine($"Ingrese nombre del encargado de {division} : ");
            nombre = Console.ReadLine();
            Console.WriteLine($"Ingrese apellido del encargado de {division} : ");
            apellido = Console.ReadLine();
            Console.WriteLine($"Ingrese rut del encargado de {division} : ");
            rut = Console.ReadLine();
            Persona persona = new Persona(nombre, apellido, rut, $"Encargado de {division}");
            return persona;
 
        }

        public Persona CreacionPersonalGeneral(int numero, string nombreBloque)
        {
            string nombre, apellido, rut;
            Console.WriteLine($"Ingrese nombre de personal general {numero} de Bloque {nombreBloque} : ");
            nombre = Console.ReadLine();
            Console.WriteLine($"Ingrese apellido de personal general {numero} de Bloque {nombreBloque} : ");
            apellido = Console.ReadLine();
            Console.WriteLine($"Ingrese rut de personal general {numero} de Bloque {nombreBloque} : ");
            rut = Console.ReadLine();
            Persona persona = new Persona(nombre, apellido, rut, $"Personal General Bloque {nombre}");
            return persona;

        }
        public Area ConstruccionArea(int numero)
        {
            string nombre;
            Console.WriteLine($"Ingrese nombre Area {numero} : ");
            nombre = Console.ReadLine();
            Area area = new Area(nombre);
            area.GuardarEncargado(CreacionPersonas($"Area {area.NOMBRE}"));
            return area;
        }
        public Departamento ConstruccionDepartamento(int numero)
        {
            string nombre;
            Console.WriteLine($"Ingrese nombre Departamento {numero} : ");
            nombre = Console.ReadLine();
            Departamento departamento = new Departamento(nombre);
            departamento.GuardarEncargado(CreacionPersonas($"Departamento {departamento.NOMBRE}"));
            return departamento;
        }

        public Seccion ConstruccionSeccion(int numero)
        {
            string nombre;
            Console.WriteLine($"Ingrese nombre de la Seccion {numero} :");
            nombre = Console.ReadLine();
            Seccion seccion = new Seccion(nombre);
            seccion.GuardarEncargado(CreacionPersonas($"Seccion {seccion.NOMBRE}"));
            return seccion;
        }

        public Bloque ConstruccionBloque(int numero)
        {
            string nombre;
            Console.WriteLine($"Ingrese nombre del Bloque {numero} :");
            nombre = Console.ReadLine();
            Bloque bloque = new Bloque(nombre);
            bloque.GuardarEncargado(CreacionPersonas($"Bloque {bloque.NOMBRE}"));
            CreacionPersonal(bloque);
            return bloque;
        }

        public void CantidadDepartamentos(Area area)
        {
            int numero = 1;
            int cantidad;
            Console.WriteLine("Cuantos Departamentos desea crear para el Area?");
            cantidad = Convert.ToInt32(Console.ReadLine());
            while (cantidad > 0)
            {
                Departamento departamento;
                departamento = ConstruccionDepartamento(numero);
                area.AgregarDepartamento(departamento);
                cantidad--;
                numero++;
            }
        }

        public void CantidadSecciones(Departamento departamento)
        {
                int numero = 1;
                int cantidad;
                Console.WriteLine($"Cuantas Secciones deseas crear en el Departamento {departamento.NOMBRE}");
                cantidad = Convert.ToInt32(Console.ReadLine());
                while (cantidad > 0)
                {
                    Seccion seccion;
                    seccion = ConstruccionSeccion(numero);
                    departamento.AgregarSeccion(seccion);
                    cantidad--;
                    numero++;
                }
        }

        public void CantidadBloques(Seccion seccion)
        {
            int numero = 1;
            int cantidad;
            Console.WriteLine($"Cuantos Bloques deseas crear en la Seccion {seccion.NOMBRE}");
            cantidad = Convert.ToInt32(Console.ReadLine());
            while (cantidad > 0)
            {
                Bloque bloque;
                bloque = ConstruccionBloque(numero);
                seccion.AgregarBloque(bloque);
                cantidad--;
                numero++;
            }
        }

        public void CreacionPersonal(Bloque bloque)
        {
            int cantidad;
            int numero = 1;
            Persona persona;
            Console.WriteLine($"Cuanto personal general deseas agregar al bloque {bloque.NOMBRE}");
            cantidad = Convert.ToInt32(Console.ReadLine());
            while (cantidad > 0)
            {
                persona = CreacionPersonalGeneral(numero, bloque.NOMBRE);
                bloque.GuardarPersonalGeneral(persona);
                cantidad--;
                numero++;
            }
        }

        public void GeneradorEmpresa(Empresa empresa)
        {
            Departamento departamento = new Departamento("Finanzas");
            Persona persona = new Persona("Daniel", "Saavedra", "20075160-4", "Encargado de Departamento de Fianzas");
            departamento.GuardarEncargado(persona);
            empresa.GuardarDivisionDepartamento(departamento);

            Seccion seccion = new Seccion("Gastos");
            Persona persona1 = new Persona("Ignacia", "Gallego", "12345678-9", "Encargado de Seccion de Gastos");
            seccion.GuardarEncargado(persona1);
            empresa.GuardarDivisionSeccion(seccion);

            Bloque bloque = new Bloque("Servicio al cliente");
            Persona persona2 = new Persona("Juab", "Gonzalez", "98765432-1", "Encargado de Bloque de Servicio al cliente");
            bloque.GuardarEncargado(persona2);
            Persona general1 = new Persona("JJ", "Martinex", "98723432-k", "Personal General de Servicio al cliente");
            Persona general2 = new Persona("DJ", "Cuba", "13653432-2", "Personal General de Servicio al cliente");
            bloque.GuardarPersonalGeneral(general1);
            bloque.GuardarPersonalGeneral(general2);
            empresa.GuardarDivisionBloque(bloque);

            Bloque bloque1 = new Bloque("Caridad");
            Persona persona3 = new Persona("Checho", " Panza", "54274598-4", "Encargado de Bloque de Caridad");
            bloque1.GuardarEncargado(persona3);
            Persona general3 = new Persona("walala", "Fracis", "27364528-k", "Personal General de Caridad");
            Persona general4 = new Persona("Cosmo", "Cano", "13651234-6", "Personal General de Caridad");
            bloque1.GuardarPersonalGeneral(general3);
            bloque1.GuardarPersonalGeneral(general4);
            empresa.GuardarDivisionBloque(bloque1);

        }

        public void MostrarEmpresasGeneradas()
        {
            foreach(var i in empresas)
            {
                Console.WriteLine($"Nombre Empresa: {i.NOMBRE}");
                Console.WriteLine($"RUT Empresa: {i.RUT}");

                foreach(var e in i.DIVISIONES)
                {
                    Console.WriteLine($"Nombre {e.TIPO}: {e.NOMBRE}");
                    Console.WriteLine($"Encargado {e.TIPO} {e.NOMBRE}: {e.encargado.NOMBRE} {e.encargado.APELLIDO} {e.encargado.RUT}");
                }
            }
        }

    }
}
