using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;

namespace Negocio
{
    public class MateriaLogic : Negocio
    {
        private MateriaAdapter _MateriaDatos;

        public MateriaAdapter MateriaDatos
        {
            get { return _MateriaDatos; }
            set { _MateriaDatos = value; }
        }


        public MateriaLogic()
        {
            MateriaDatos = new MateriaAdapter();
        }

        public List<Materia> GetAll()
        {
            return MateriaDatos.GetAll();
        }

        public List<Materia> GetAll(int IDPlan)
        {
            return MateriaDatos.GetAll(IDPlan);
        }

        public List<Materia> GetAllAlumno(int IDPlan)
        {
            return MateriaDatos.GetAllAlumno(IDPlan);
        }

        public Materia GetOne(int ID)
        {
            return MateriaDatos.GetOne(ID);
        }

        public void Delete(int ID)
        {
            MateriaDatos.Delete(ID);
        }

        public void Save(Materia mat)
        {
            MateriaDatos.Save(mat);
        }
    }
}

