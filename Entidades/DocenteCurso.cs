using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class DocenteCurso : Entidad
    {
        private TiposCargos _Cargo;

        public TiposCargos Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        private int _IDCurso;

        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }

        private int _IDDocente;

        public int IDDocente
        {
            get { return _IDDocente; }
            set { _IDDocente = value; }
        }

        private string _NombreYApellido;

        public string NombreYApellido
        {
            get { return _NombreYApellido; }
            set { _NombreYApellido = value; }
        }

        private string _MateriaComision;

        public string MateriaComision
        {
            get { return _MateriaComision; }
            set { _MateriaComision = value; }
        }

        public enum TiposCargos
        {
            Titular,
            Auxiliar,
            Suplente
        }
    }
}
