using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;

namespace Negocio
{
    public class PlanLogic : Negocio
    {
        private PlanAdapter _PlanDatos;

        public PlanAdapter PlanDatos
        {
            get { return _PlanDatos; }
            set { _PlanDatos = value; }
        }


        public PlanLogic()
        {
            PlanDatos = new PlanAdapter();
        }

        public List<Plan> GetAll()
        {
            return PlanDatos.GetAll();
        }

        public List<Plan> GetAll(int idEsp)
        {
            return PlanDatos.GetAll(idEsp);
        }

        public Plan GetOne(int ID)
        {
            return PlanDatos.GetOne(ID);
        }

        public void Delete(int ID)
        {
            PlanDatos.Delete(ID);
        }

        public void Save(Plan plan)
        {
            PlanDatos.Save(plan);
        }
    }
}
