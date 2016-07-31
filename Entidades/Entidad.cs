using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Entidad
    {
        public Entidad ()
        {
            this.State = States.Nuevo;
        }
        int _ID;
        public int ID
        {
            get { return _ID;}
            set { _ID = value; }
        }
        States _State;
        public States State
        {
            get { return _State; }
            set { _State = value; }
        }
        public enum States
        {
            Eliminado,
            Nuevo,
            Modificado,
            NoModificado
        }
    }
}
