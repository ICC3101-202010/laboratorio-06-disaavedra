using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    [Serializable]
    class Seccion : Division
    {
        List<Bloque> bloques = new List<Bloque>();
        public Seccion(string nombre) : base(nombre)
        {
            //
        }

        public string NOMBRE { get { return this.nombre; } }

        public void AgregarBloque(Bloque bloque) { bloques.Add(bloque); }

        public void GuardarTipo()
        {
            string tipo = "Seccion";
            this.tipo = tipo;
        }
    }
}
