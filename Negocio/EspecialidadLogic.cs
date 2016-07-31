using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;

namespace Negocio
{
    public class EspecialidadLogic : Negocio
    {
        private EspecialidadAdapter _EspecialidadDatos;

        public EspecialidadAdapter EspecialidadDatos
        {
            get { return _EspecialidadDatos; }
            set { _EspecialidadDatos = value; }
        }


        public EspecialidadLogic()
        {
            EspecialidadDatos = new EspecialidadAdapter();
        }

        public List<Especialidad> GetAll()
        {
            return EspecialidadDatos.GetAll();
        }

        public Especialidad GetOne(int ID)
        {
            return EspecialidadDatos.GetOne(ID);
        }

        public void Delete(int ID)
        {
            EspecialidadDatos.Delete(ID);
        }
        public void Save(Especialidad esp)
        {
            EspecialidadDatos.Save(esp);
        }
    }
}