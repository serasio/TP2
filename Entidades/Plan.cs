using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Plan : Entidad
    {
        string _DescEspecialidad;

        public string DescEspecialidad
        {
            get { return _DescEspecialidad; }
            set { _DescEspecialidad = value; }
        }

        private string _PlanEspecialidadDesc;

        public string PlanEspecialidadDesc
        {
            get { return _PlanEspecialidadDesc; }
            set { _PlanEspecialidadDesc = value; }
        }
        
        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }


        private int _IDEspecialidad;

        public int IDEspecialidad
        {
            get { return _IDEspecialidad; }
            set { _IDEspecialidad = value; }
        }

    }
}
