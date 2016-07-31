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
    public class CursoAdapter:Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select cursos.id_curso, cursos.id_materia, "+
                    "comisiones.id_comision, comisiones.desc_comision, materias.desc_materia, "+
                    "cursos.anio_calendario, cursos.cupo from cursos inner join materias "+
                    "on cursos.id_materia = materias.id_materia inner join comisiones "+
                    "on comisiones.id_comision = cursos.id_comision", SqlConn);

                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cu = new Curso();
                    cu.ID = (int)drCursos["id_curso"];
                    cu.IDMateria = (int)drCursos["id_materia"];
                    cu.IDComision = (int)drCursos["id_comision"];
                    cu.DescComision = (string)drCursos["desc_comision"];
                    cu.DescMateria = (string)drCursos["desc_materia"];
                    cu.AnioCalendario = (int)drCursos["anio_calendario"];
                    cu.Cupo = (int)drCursos["cupo"];
                    cu.MateriaComision = cu.DescMateria + " - " + cu.DescComision;
                    cursos.Add(cu);
                }
                drCursos.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public List<Curso> GetCursosComision(int idCom)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos inner join " +
                    "materias on materias.id_materia = cursos.id_materia inner join " +
                "comisiones on comisiones.id_comision = cursos.id_comision " +
                "where comisiones.id_comision=@id and cursos.anio_calendario=@anioCal", SqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = idCom;
                cmdCursos.Parameters.Add("@anioCal", SqlDbType.Int).Value= DateTime.Today.Year;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cu = new Curso();
                    cu.ID = (int)drCursos["id_curso"];
                    cu.DescMateria = (string)drCursos["desc_materia"];
                    cu.IDMateria = (int)drCursos["id_materia"];
                    cu.IDComision = (int)drCursos["id_comision"];
                    cu.DescComision = (string)drCursos["desc_comision"];
                    cursos.Add(cu);
                }
                drCursos.Close();
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al recuperar Cursos", ex);
                throw e;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }


        public List<Curso> GetCursos()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCursosInscripciones = new SqlCommand("select * from cursos inner join "+
                    "materias on materias.id_materia = cursos.id_materia inner join " +
                "comisiones on comisiones.id_comision = cursos.id_comision ", SqlConn);

                //cmdCursosInscripciones.Parameters.Add("@anio", SqlDbType.Int).Value = DateTime.Now.Year;

                SqlDataReader drCursos = cmdCursosInscripciones.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cu = new Curso();
                    cu.ID = (int)drCursos["id_curso"];
                    cu.ComMatYear = (string)drCursos["desc_comision"] + " - " + (string)drCursos["desc_materia"] + " - " + (int)drCursos["anio_calendario"];
                    cursos.Add(cu);
                }
                drCursos.Close();
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al recuperar Cursos para inscripcion", ex);
                throw e;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public List<Curso> GetCursosAlumno(int IDPlanAlumno)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCursosInscripciones = new SqlCommand("select * from cursos inner join " +
                    "materias on materias.id_materia = cursos.id_materia inner join " +
                "comisiones on comisiones.id_comision = cursos.id_comision where materias.id_plan = @id_plan", SqlConn);

                cmdCursosInscripciones.Parameters.Add("@id_plan", SqlDbType.Int).Value = IDPlanAlumno;

                SqlDataReader drCursos = cmdCursosInscripciones.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cu = new Curso();
                    cu.ID = (int)drCursos["id_curso"];
                    cu.ComMatYear = (string)drCursos["desc_comision"] + " - " + (string)drCursos["desc_materia"] + " - " + (int)drCursos["anio_calendario"];
                    cu.MateriaComision = (string)drCursos["desc_materia"] + " - " + (string)drCursos["desc_comision"];
                    cu.IDMateria = (int)drCursos["id_materia"];
                    cu.IDComision = (int)drCursos["id_comision"];
                    cursos.Add(cu);
                }
                drCursos.Close();
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al recuperar Cursos para inscripcion", ex);
                throw e;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public Curso GetOne(int ID)
        {
            Curso cu = new Curso();

            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos where id_curso = @id", SqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    cu.ID = (int)drCursos["id_curso"];
                    cu.IDMateria = (int)drCursos["id_materia"];
                    cu.IDComision = (int)drCursos["id_comision"];
                    cu.AnioCalendario = (int)drCursos["anio_calendario"];
                    cu.Cupo = (int)drCursos["cupo"];
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return cu;
        }


        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Update(Curso cu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE cursos SET id_materia=@id_materia, id_comision=@id_comision, anio_calendario=@anio_calendario, cupo=@cupo " +
                "WHERE id_curso=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = cu.ID;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = cu.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = cu.IDComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = cu.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = cu.Cupo;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Curso cu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "insert into cursos(id_materia,id_comision,anio_calendario,cupo) " +
                "values(@id_materia,@id_comision,@anio_calendario,@cupo)" +
                "select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@id_materia", SqlDbType.Int).Value = cu.IDMateria;
                cmdInsert.Parameters.Add("@id_comision", SqlDbType.Int).Value = cu.IDComision;
                cmdInsert.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = cu.AnioCalendario;
                cmdInsert.Parameters.Add("@cupo", SqlDbType.Int).Value = cu.Cupo;
                cu.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso cu)
        {
            if (cu.State == Entidad.States.Eliminado)
            {
                this.Delete(cu.ID);
            }
            else if (cu.State == Entidad.States.Nuevo)
            {
                this.Insert(cu);
            }
            else if (cu.State == Entidad.States.Modificado)
            {
                this.Update(cu);
            }
            cu.State = Entidad.States.NoModificado;
        }
    }
}
