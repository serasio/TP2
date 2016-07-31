using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Materia : Entidad
    {
        private int _IDEspecialidad;

        public int IDEspecialidad
        {
            get { return _IDEspecialidad; }
            set { _IDEspecialidad = value; }
        }

        private string _DescripcionPlanCarrera;

        public string DescripcionPlanCarrera
        {
            get { return _DescripcionPlanCarrera; }
            set { _DescripcionPlanCarrera = value; }
        }

        private string _DescripcionEspecialidad;

        public string DescripcionEspecialidad
        {
            get { return _DescripcionEspecialidad; }
            set { _DescripcionEspecialidad = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private int _HSSemanales;

        public int HSSemanales
        {
            get { return _HSSemanales; }
            set { _HSSemanales = value; }
        }

        private int _IDPlan;

        public int IDPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }

        private int _HSTotales;

        public int HSTotales
        {
            get { return _HSTotales; }
            set { _HSTotales = value; }
        }

        private string _DescripcionPlan;

        public string DescripcionPlan
        {
            get { return _DescripcionPlan; }
            set { _DescripcionPlan = value; }
        }
    }
}
