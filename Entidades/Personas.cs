using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Personas : Entidad
    {
        private string _Nombre;
        private string _Apellido;
        private string _Direccion;
        private string _Email;
        private DateTime _FechaNacimiento;
        private int _IDPlan;
        private int _Legajo;
        private string _Telefono;
        private TiposPersonas _TipoPersona;

        public string Apellido
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Direccion
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Email
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DateTime FechaNacimiento
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int IDPlan
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Legajo
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Nombre
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Telefono
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public TiposPersonas TipoPersona
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        
        public enum TiposPersonas
        {

        }
    }
}
