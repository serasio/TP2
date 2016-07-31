using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;

namespace Negocio
{
    public class AluInscripcionLogic : Negocio
    {
        private AluInscripcionAdapter _AluInscripcionDatos;

        public AluInscripcionAdapter AluInscripcionDatos
        {
            get { return _AluInscripcionDatos; }
            set { _AluInscripcionDatos = value; }
        }


        public AluInscripcionLogic()
        {
            AluInscripcionDatos = new AluInscripcionAdapter();
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return AluInscripcionDatos.GetAll();
        }

        public List<AlumnoInscripcion> GetAllAlumno(int IDAlumno)
        {
            return AluInscripcionDatos.GetAllAlumno(IDAlumno);
        }

        public List<AlumnoInscripcion> GetInscCurso(int IDCurso)
        {
            return AluInscripcionDatos.GetInscCurso(IDCurso);
        }

        public List<AlumnoInscripcion> GetAllProfesor(int IDProfesor)
        {
            return AluInscripcionDatos.GetAllProfesor(IDProfesor);
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            return AluInscripcionDatos.GetOne(ID);
        }

        public void Delete(int ID)
        {
            AluInscripcionDatos.Delete(ID);
        }

        public void Save(AlumnoInscripcion aluInsc)
        {
            AluInscripcionDatos.Save(aluInsc);
        }
    }
}
