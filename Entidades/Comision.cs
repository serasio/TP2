using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Comision : Entidad
    {
        private int _AnioEspecialidad;

        public int AnioEspecialidad
        {
            get { return _AnioEspecialidad; }
            set { _AnioEspecialidad = value; }
        }

        private string _ComisionEspDesc;

        public string ComisionEspDesc
        {
            get { return _ComisionEspDesc; }
            set { _ComisionEspDesc = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private int _IDPlan;

        public int IDPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }


        private string _PlanEspDescripcion;

        public string PlanEspDescripcion
        {
            get { return _PlanEspDescripcion; }
            set { _PlanEspDescripcion = value; }
        }

    }
}
