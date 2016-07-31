using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Entidades;

namespace Negocio
{
    public class CursoLogic:Negocio
    {
        private CursoAdapter _CursoDatos;

        public CursoAdapter CursoDatos
        {
          get { return _CursoDatos; }
          set { _CursoDatos = value; }
        }

        public CursoLogic()
        {
            CursoDatos = new CursoAdapter();
        }

        public List<Curso> GetCursosComision(int idCom)
        {
            return CursoDatos.GetCursosComision(idCom);
        }

        public List<Curso> GetAll()
        {
            return CursoDatos.GetAll();
        }

        public List<Curso> GetCursos()
        {
            return CursoDatos.GetCursos();
        }

        public List<Curso> GetCursosAlumno(int IDPlanAlumno)
        {
            return CursoDatos.GetCursosAlumno(IDPlanAlumno);
        }

        public Curso GetOne(int ID)
        {
            return CursoDatos.GetOne(ID);
        }

        public void Delete(int ID)
        {
            CursoDatos.Delete(ID);
        }

        public void Save(Curso cu)
        {
            CursoDatos.Save(cu);
        }
    }
}
