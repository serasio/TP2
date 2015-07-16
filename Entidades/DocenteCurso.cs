using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class DocenteCurso : Entidad
    {
        private TiposCargos _Cargo;
        private int _IDCurso;
        private int _IDDocente;

        public TiposCargos Cargo
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int IDCurso
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int IDDocente
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public enum TiposCargos
        {

        }
    }
}
