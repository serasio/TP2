using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Reporte : Entidad
    {
        private int _IDDocente;

        public int IDDocente
        {
            get { return _IDDocente; }
            set { _IDDocente = value; }
        }

        private int _IDPlan;

        public int IDPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }

        private int _CursoIDMateria;

        public int CursoIDMateria
        {
            get { return _CursoIDMateria; }
            set { _CursoIDMateria = value; }
        }

        private int _IDComision;

        public int IDComision
        {
            get { return _IDComision; }
            set { _IDComision = value; }
        }

        private int _IDMateria;

        public int IDMateria
        {
            get { return _IDMateria; }
            set { _IDMateria = value; }
        }

        private int _IDCurso;

        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }

        private int _IDEspecialidad;

        public int IDEspecialidad
        {
            get { return _IDEspecialidad; }
            set { _IDEspecialidad = value; }
        }

    }
}
