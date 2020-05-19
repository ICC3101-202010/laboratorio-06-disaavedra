using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    class Division
    {
        protected string nombre;
        public Persona encargado;
        protected string tipo;
        public Division(string nombre)
        {
            this.nombre = nombre;
        }

        public void GuardarEncargado(Persona encargado)
        {
            this.encargado = encargado;
        }

        public string TIPO { get { return this.tipo; } }

        public string NOMBRE { get { return this.nombre; } }
    }
}
