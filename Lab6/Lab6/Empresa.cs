using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{   
    [Serializable]
    class Empresa
    {
        string nombre;
        string rut;
        List<Division> divisiones = new List<Division>();

        public Empresa(string nombre, string rut)
        {
            this.nombre = nombre;
            this.rut = rut;
        }

        public void GuardarDivisionArea(Area area) { divisiones.Add(area); }
        public void GuardarDivisionDepartamento(Departamento departamento) { divisiones.Add(departamento); }
        public void GuardarDivisionSeccion(Seccion seccion) { divisiones.Add(seccion); }
        public void GuardarDivisionBloque(Bloque bloque) { divisiones.Add(bloque); }


        public string NOMBRE { get { return this.nombre; } }

        public string RUT { get { return this.rut; } }

        public List<Division> DIVISIONES { get { return this.divisiones; } }
    }
}
