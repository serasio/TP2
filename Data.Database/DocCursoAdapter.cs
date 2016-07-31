using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class DocCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docentesCursos = new List<DocenteCurso>();
            List<Curso> cursos = new List<Curso>();
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocCursos = new SqlCommand("select * from docentes_cursos inner join personas "
                    + " on docentes_cursos.id_docente = personas.id_persona inner join cursos " +
                    "on cursos.id_curso = docentes_cursos.id_curso inner join materias " +
                "on materias.id_materia = cursos.id_materia inner join comisiones on " +
                "comisiones.id_comision = cursos.id_comision", SqlConn);
                SqlDataReader drDocCursos = cmdDocCursos.ExecuteReader();
                while (drDocCursos.Read())
                {
                    DocenteCurso docCurso = new DocenteCurso();
                    docCurso.ID = (int)drDocCursos["id_dictado"];
                    docCurso.IDDocente = (int)drDocCursos["id_docente"];
                    docCurso.IDCurso = (int)drDocCursos["id_curso"];
                    docCurso.Cargo = (DocenteCurso.TiposCargos)drDocCursos["cargo"];
                    docCurso.NombreYApellido = (string)drDocCursos["nombre"] + " " + (string)drDocCursos["apellido"];
                    docCurso.MateriaComision = (string)drDocCursos["desc_materia"] + " - " + (string)drDocCursos["desc_comision"];
                    docentesCursos.Add(docCurso);
                }
                drDocCursos.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de docentes de los cursos", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return docentesCursos;
        }

        public List<DocenteCurso> GetAll(int IDDocente)
        {
            List<DocenteCurso> docentesCursos = new List<DocenteCurso>();
            List<Curso> cursos = new List<Curso>();
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocCursos = new SqlCommand("select * from docentes_cursos inner join personas "
                    + "on docentes_cursos.id_docente = personas.id_persona inner join cursos " +
                    "on cursos.id_curso = docentes_cursos.id_curso inner join materias " +
                "on materias.id_materia = cursos.id_materia inner join comisiones " +
                "on comisiones.id_comision = cursos.id_comision " +
                "where docentes_cursos.id_docente = @id_doc", SqlConn);

                cmdDocCursos.Parameters.Add("@id_doc", SqlDbType.Int).Value = IDDocente;

                SqlDataReader drDocCursos = cmdDocCursos.ExecuteReader();
                while (drDocCursos.Read())
                {
                    DocenteCurso docCurso = new DocenteCurso();
                    docCurso.ID = (int)drDocCursos["id_dictado"];
                    docCurso.IDDocente = (int)drDocCursos["id_docente"];
                    docCurso.IDCurso = (int)drDocCursos["id_curso"];
                    docCurso.Cargo = (DocenteCurso.TiposCargos)drDocCursos["cargo"];
                    docCurso.NombreYApellido = (string)drDocCursos["nombre"] + " " + (string)drDocCursos["apellido"];
                    docCurso.MateriaComision = (string)drDocCursos["desc_materia"] + " - " + (string)drDocCursos["desc_comision"];
                    docentesCursos.Add(docCurso);
                }
                drDocCursos.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de docentes de los cursos", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return docentesCursos;
        }

        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso docCurso = new DocenteCurso();

            try
            {
                this.OpenConnection();

                SqlCommand cmdDocCursos = new SqlCommand("select * from docentes_cursos WHERE id_dictado = @id", SqlConn);
                cmdDocCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocCursos = cmdDocCursos.ExecuteReader();
                if (drDocCursos.Read())
                {
                    docCurso.ID = (int)drDocCursos["id_dictado"];
                    docCurso.IDDocente = (int)drDocCursos["id_docente"];
                    docCurso.IDCurso = (int)drDocCursos["id_curso"];
                    docCurso.Cargo = (DocenteCurso.TiposCargos)drDocCursos["cargo"];
                }
                drDocCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return docCurso;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete docentes_cursos where id_dictado=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(DocenteCurso docCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE docentes_cursos SET id_curso=@id_curso, id_docente=@id_docente, cargo=@cargo  " +
                "WHERE id_dictado=@id", SqlConn);

                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docCurso.IDDocente;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docCurso.IDCurso;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = (int)docCurso.Cargo;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso docCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "insert into docentes_cursos(id_curso,id_docente,cargo) " +
                "values(@id_curso,@id_docente,@cargo)" +
                "select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@id_curso", SqlDbType.VarChar, 50).Value = docCurso.IDCurso;
                cmdInsert.Parameters.Add("@id_docente", SqlDbType.Int).Value = docCurso.IDDocente;
                cmdInsert.Parameters.Add("@cargo", SqlDbType.Int).Value = (int)docCurso.Cargo;
                docCurso.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear docente del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso docCurso)
        {
            if (docCurso.State == Entidad.States.Eliminado)
            {
                this.Delete(docCurso.ID);
            }
            else if (docCurso.State == Entidad.States.Nuevo)
            {
                this.Insert(docCurso);
            }
            else if (docCurso.State == Entidad.States.Modificado)
            {
                this.Update(docCurso);
            }
            docCurso.State = Entidad.States.NoModificado;
        }
    }
}
