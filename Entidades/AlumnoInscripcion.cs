using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class AlumnoInscripcion : Entidad
    {
        private string _Condicion;

        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }

        private string _comisionMateriaAnio;

        public string ComisionMateriaAnio
        {
            get { return _comisionMateriaAnio; }
            set { _comisionMateriaAnio = value; }
        }

        private string _aluNomYApe;

        public string AluNomYApe
        {
            get { return _aluNomYApe; }
            set { _aluNomYApe = value; }
        }

        private int _IDCurso;

        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }

        private int _IDAlumno;

        public int IDAlumno
        {
            get { return _IDAlumno; }
            set { _IDAlumno = value; }
        }

        private int _Nota;

        public int Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }
    }
}
