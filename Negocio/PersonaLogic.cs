using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;

namespace Negocio
{
    public class PersonaLogic : Negocio
    {
        private PersonaAdapter _PersonaDatos;

        public PersonaAdapter PersonaDatos
        {
            get { return _PersonaDatos; }
            set { _PersonaDatos = value; }
        }


        public PersonaLogic()
        {
            PersonaDatos = new PersonaAdapter();
        }

        public List<Persona> GetAll(Persona.TiposPersonas tipo)
        {
            return PersonaDatos.GetAll(tipo);
        }

        public List<Persona> GetNom(Persona.TiposPersonas tipo)
        {
            return PersonaDatos.GetNom(tipo);
        }

        public List<Persona> GetNom()
        {
            return PersonaDatos.GetNom();
        }

        public Persona GetOne(int ID, Persona.TiposPersonas tipo)
        {
            return PersonaDatos.GetOne(ID, tipo);
        }

        public void Delete(int ID)
        {
            PersonaDatos.Delete(ID);
        }

        public void Save(Persona per)
        {
            PersonaDatos.Save(per);
        }
    }
}
