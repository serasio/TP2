using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;

namespace Negocio
{
    public class ComisionLogic : Negocio
    {
        private ComisionAdapter _ComisionDatos;

        public ComisionAdapter ComisionDatos
        {
            get { return _ComisionDatos; }
            set { _ComisionDatos = value; }
        }

        public ComisionLogic()
        {
            ComisionDatos = new ComisionAdapter();
        }

        public List<Comision> GetAll()
        {
            return ComisionDatos.GetAll();
        }

        public List<Comision> GetComisionesAnio(int anioEsp, int idPlan)
        {
            return ComisionDatos.GetComisionesAnio(anioEsp, idPlan);
        }

        public Comision GetOne(int ID)
        {
            return ComisionDatos.GetOne(ID);
        }

        public void Delete(int ID)
        {
            ComisionDatos.Delete(ID);
        }

        public void Save(Comision com)
        {
            ComisionDatos.Save(com);
        }
    }
}

