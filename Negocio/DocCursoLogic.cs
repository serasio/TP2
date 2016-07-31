using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;

namespace Negocio
{
    public class DocCursoLogic : Negocio
    {

        private DocCursoAdapter _DocCursoDatos;

        public DocCursoAdapter DocCursoDatos
        {
            get { return _DocCursoDatos; }
            set { _DocCursoDatos = value; }
        }


        public DocCursoLogic()
        {
            DocCursoDatos = new DocCursoAdapter();
        }

        public List<DocenteCurso> GetAll()
        {
            return DocCursoDatos.GetAll();
        }

        public List<DocenteCurso> GetAll(int IDDocente)
        {
            return DocCursoDatos.GetAll(IDDocente);
        }

        public DocenteCurso GetOne(int ID)
        {
            return DocCursoDatos.GetOne(ID);
        }

        public void Delete(int ID)
        {
            DocCursoDatos.Delete(ID);
        }

        public void Save(DocenteCurso docCurso)
        {
            DocCursoDatos.Save(docCurso);
        }
    }
}

