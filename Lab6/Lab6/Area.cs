using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    [Serializable]
    class Area : Division
    {
        List<Departamento> departamentos = new List<Departamento>();
        
        public Area(string nombre) : base(nombre)
        {
            //
        }

        public void AgregarDepartamento(Departamento departamento) { departamentos.Add(departamento); }

        public List<Departamento> DEPARTAMENTOS { get { return this.departamentos; } }

        public string NOMBRE { get { return this.nombre; } }
        public void GuardarTipo()
        {
            string tipo = "Area";
            this.tipo = tipo;
        }
        
    }
}
