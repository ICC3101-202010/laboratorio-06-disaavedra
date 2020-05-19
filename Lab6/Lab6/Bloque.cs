using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    [Serializable]
    class Bloque : Division
    {
        List<Persona> personal = new List<Persona>();
        public Bloque(string nombre) : base(nombre)
        {
            //
        }

        public string NOMBRE { get { return this.nombre; } }

        public void GuardarPersonalGeneral(Persona persona) { personal.Add(persona); }

        public void GuardarTipo()
        {
            string tipo = "Bloque";
            this.tipo = tipo;
        }
    }
}
