using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    [Serializable]
    class Persona
    {
        string nombre;
        string apellido;
        string rut;
        string cargo;

        public Persona(string nombre, string apellido, string rut, string cargo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.rut = rut;
            this.cargo = cargo;
        }

        public string NOMBRE { get { return this.nombre; } }
        public string APELLIDO { get { return this.apellido; } }
        public string RUT { get { return this.rut; } }
    }
}
