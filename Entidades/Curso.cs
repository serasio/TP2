using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Curso : Entidad
    {
        private int _AnioCalendario;

        public int AnioCalendario
        {
            get { return _AnioCalendario; }
            set { _AnioCalendario = value; }
        }

        private string _MateriaComision;

        public string MateriaComision
        {
            get { return _MateriaComision; }
            set { _MateriaComision = value; }
        }

        private int _Cupo;

        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
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

        private string _DescMateria;

        public string DescMateria
        {
            get { return _DescMateria; }
            set { _DescMateria = value; }
        }

        private string _DescComision;

        public string DescComision
        {
            get { return _DescComision; }
            set { _DescComision = value; }
        }

        private string _comMatYear;

        public string ComMatYear
        {
            get { return _comMatYear; }
            set { _comMatYear = value; }
        }
    }
}
