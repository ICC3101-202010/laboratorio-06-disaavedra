using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    [Serializable]
    class Departamento : Division
    {
        List<Seccion> secciones = new List<Seccion>();
        public Departamento(string nombre) : base(nombre)
        {
            //
        }

        public string NOMBRE { get { return this.nombre; } }

        public void AgregarSeccion(Seccion seccion) { secciones.Add(seccion); }

        public List<Seccion> SECCIONES { get { return this.secciones; } }
        public void GuardarTipo()
        {
            string tipo = "Departamento";
            this.tipo = tipo;
        }
    }
}
