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
    public class AluInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> alumnosInsc = new List<AlumnoInscripcion>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumnoInsc = new SqlCommand("select * from alumnos_inscripciones inner join cursos "+
                    "on cursos.id_curso = alumnos_inscripciones.id_curso inner join personas on "+
                    "personas.id_persona = alumnos_inscripciones.id_alumno inner join materias on "+
                    "materias.id_materia = cursos.id_materia inner join comisiones on "+
                    "comisiones.id_comision = cursos.id_comision", SqlConn);

                SqlDataReader drAlumnoInsc = cmdAlumnoInsc.ExecuteReader();

                while (drAlumnoInsc.Read())
                {
                    AlumnoInscripcion aluInsc = new AlumnoInscripcion();

                    aluInsc.ID = (int)drAlumnoInsc["id_inscripcion"];
                    aluInsc.IDAlumno = (int)drAlumnoInsc["id_alumno"];
                    aluInsc.IDCurso = (int)drAlumnoInsc["id_curso"];
                    aluInsc.Nota = (int)drAlumnoInsc["nota"];
                    aluInsc.Condicion = (string)drAlumnoInsc["condicion"];
                    aluInsc.AluNomYApe = (string)drAlumnoInsc["nombre"] + " " + (string)drAlumnoInsc["apellido"];
                    aluInsc.ComisionMateriaAnio = (string)drAlumnoInsc["desc_comision"]+" - "+(string)drAlumnoInsc["desc_materia"]+" - "+(int)drAlumnoInsc["anio_calendario"];
                    alumnosInsc.Add(aluInsc);
                }
                drAlumnoInsc.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return alumnosInsc;
        }

        public List<AlumnoInscripcion> GetAllAlumno(int IDAlumno)
        {
            List<AlumnoInscripcion> alumnosInsc = new List<AlumnoInscripcion>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumnoInsc = new SqlCommand("select * from alumnos_inscripciones inner join cursos " +
                    "on cursos.id_curso = alumnos_inscripciones.id_curso inner join personas on " +
                    "personas.id_persona = alumnos_inscripciones.id_alumno inner join materias on " +
                    "materias.id_materia = cursos.id_materia inner join comisiones on " +
                    "comisiones.id_comision = cursos.id_comision where personas.id_persona = @id_alumno", SqlConn);

                cmdAlumnoInsc.Parameters.Add("@id_alumno", SqlDbType.Int).Value = IDAlumno;
                SqlDataReader drAlumnoInsc = cmdAlumnoInsc.ExecuteReader();

                while (drAlumnoInsc.Read())
                {
                    AlumnoInscripcion aluInsc = new AlumnoInscripcion();

                    aluInsc.ID = (int)drAlumnoInsc["id_inscripcion"];
                    aluInsc.IDAlumno = (int)drAlumnoInsc["id_alumno"];
                    aluInsc.IDCurso = (int)drAlumnoInsc["id_curso"];
                    aluInsc.Nota = (int)drAlumnoInsc["nota"];
                    aluInsc.Condicion = (string)drAlumnoInsc["condicion"];
                    aluInsc.AluNomYApe = (string)drAlumnoInsc["nombre"] + " " + (string)drAlumnoInsc["apellido"];
                    aluInsc.ComisionMateriaAnio = (string)drAlumnoInsc["desc_comision"] + " - " + (string)drAlumnoInsc["desc_materia"] + " - " + (int)drAlumnoInsc["anio_calendario"];
                    alumnosInsc.Add(aluInsc);
                }
                drAlumnoInsc.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return alumnosInsc;
        }


        public List<AlumnoInscripcion> GetInscCurso(int IDCurso)
        {
            List<AlumnoInscripcion> alumnosInsc = new List<AlumnoInscripcion>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumnoInsc = new SqlCommand("select * from alumnos_inscripciones inner join cursos " +
                    "on cursos.id_curso = alumnos_inscripciones.id_curso inner join personas on " +
                    "personas.id_persona = alumnos_inscripciones.id_alumno inner join materias on " +
                    "materias.id_materia = cursos.id_materia inner join comisiones on " +
                    "comisiones.id_comision = cursos.id_comision inner join docentes_cursos on "+
                    "docentes_cursos.id_curso = cursos.id_curso "+
                    "where cursos.id_curso = @id", SqlConn);

                cmdAlumnoInsc.Parameters.Add("@id", SqlDbType.Int).Value = IDCurso;
                SqlDataReader drAlumnoInsc = cmdAlumnoInsc.ExecuteReader();

                while (drAlumnoInsc.Read())
                {
                    AlumnoInscripcion aluInsc = new AlumnoInscripcion();

                    aluInsc.ID = (int)drAlumnoInsc["id_inscripcion"];
                    aluInsc.IDCurso = (int)drAlumnoInsc["id_curso"];
                    aluInsc.Nota = (int)drAlumnoInsc["nota"];
                    aluInsc.Condicion = (string)drAlumnoInsc["condicion"];
                    aluInsc.AluNomYApe = (string)drAlumnoInsc["nombre"] + " " + (string)drAlumnoInsc["apellido"];
                    aluInsc.ComisionMateriaAnio = (string)drAlumnoInsc["desc_comision"] + " - " + (string)drAlumnoInsc["desc_materia"] + " - " + (int)drAlumnoInsc["anio_calendario"];
                    alumnosInsc.Add(aluInsc);
                }
                drAlumnoInsc.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return alumnosInsc;
        }

        public List<AlumnoInscripcion> GetAllProfesor(int IDProfesor)
        {
            List<AlumnoInscripcion> alumnosInsc = new List<AlumnoInscripcion>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumnoInsc = new SqlCommand("select * from alumnos_inscripciones inner join cursos " +
                    "on cursos.id_curso = alumnos_inscripciones.id_curso inner join personas on " +
                    "personas.id_persona = alumnos_inscripciones.id_alumno inner join materias on " +
                    "materias.id_materia = cursos.id_materia inner join comisiones on " +
                    "comisiones.id_comision = cursos.id_comision inner join docentes_cursos on " +
                    "docentes_cursos.id_curso = cursos.id_curso " +
                    "where docentes_cursos.id_docente = @id_profesor", SqlConn);

                cmdAlumnoInsc.Parameters.Add("@id_profesor", SqlDbType.Int).Value = IDProfesor;
                SqlDataReader drAlumnoInsc = cmdAlumnoInsc.ExecuteReader();

                while (drAlumnoInsc.Read())
                {
                    AlumnoInscripcion aluInsc = new AlumnoInscripcion();

                    aluInsc.ID = (int)drAlumnoInsc["id_inscripcion"];
                    aluInsc.IDAlumno = (int)drAlumnoInsc["id_alumno"];
                    aluInsc.IDCurso = (int)drAlumnoInsc["id_curso"];
                    aluInsc.Nota = (int)drAlumnoInsc["nota"];
                    aluInsc.Condicion = (string)drAlumnoInsc["condicion"];
                    aluInsc.AluNomYApe = (string)drAlumnoInsc["nombre"] + " " + (string)drAlumnoInsc["apellido"];
                    aluInsc.ComisionMateriaAnio = (string)drAlumnoInsc["desc_comision"] + " - " + (string)drAlumnoInsc["desc_materia"] + " - " + (int)drAlumnoInsc["anio_calendario"];
                    alumnosInsc.Add(aluInsc);
                }
                drAlumnoInsc.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return alumnosInsc;
        }



        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion aluInsc = new AlumnoInscripcion();

            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumnoInsc = new SqlCommand("select * from alumnos_inscripciones inner join cursos " +
                    "on cursos.id_curso = alumnos_inscripciones.id_curso inner join personas on " +
                    "personas.id_persona = alumnos_inscripciones.id_alumno inner join materias on " +
                    "materias.id_materia = cursos.id_materia inner join comisiones on " +
                    "comisiones.id_comision = cursos.id_comision where id_inscripcion = @id", SqlConn);

                cmdAlumnoInsc.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnoInsc = cmdAlumnoInsc.ExecuteReader();
                if (drAlumnoInsc.Read())
                {
                    aluInsc.ID = (int)drAlumnoInsc["id_inscripcion"];
                    aluInsc.IDAlumno = (int)drAlumnoInsc["id_alumno"];
                    aluInsc.IDCurso = (int)drAlumnoInsc["id_curso"];
                    aluInsc.Nota = (int)drAlumnoInsc["nota"];
                    aluInsc.Condicion = (string)drAlumnoInsc["condicion"];
                    aluInsc.AluNomYApe = (string)drAlumnoInsc["nombre"] + " " + (string)drAlumnoInsc["apellido"];
                    aluInsc.ComisionMateriaAnio = (string)drAlumnoInsc["desc_comision"] + " - " + (string)drAlumnoInsc["desc_materia"] + " - " + (int)drAlumnoInsc["anio_calendario"];
                }
                drAlumnoInsc.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de inscripción", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return aluInsc;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_inscripcion=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar inscripción", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(AlumnoInscripcion aluInsc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE alumnos_inscripciones SET nota=@nota, condicion=@condicion " +
                "WHERE id_inscripcion=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = aluInsc.ID;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = aluInsc.Nota;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = aluInsc.Condicion;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de inscripción", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripcion aluInsc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "insert into alumnos_inscripciones(id_alumno, id_curso, nota, condicion) " +
                "values(@id_alumno, @id_curso, @nota, @condicion)" +
                "select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@id_alumno", SqlDbType.Int).Value = aluInsc.IDAlumno;
                cmdInsert.Parameters.Add("@id_curso", SqlDbType.Int).Value = aluInsc.IDCurso;
                cmdInsert.Parameters.Add("@nota", SqlDbType.Int).Value = aluInsc.Nota;
                cmdInsert.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = aluInsc.Condicion;
                aluInsc.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear inscripcìón", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion aluInsc)
        {
            if (aluInsc.State == Entidad.States.Eliminado)
            {
                this.Delete(aluInsc.ID);
            }
            else if (aluInsc.State == Entidad.States.Nuevo)
            {
                this.Insert(aluInsc);
            }
            else if (aluInsc.State == Entidad.States.Modificado)
            {
                this.Update(aluInsc);
            }
            aluInsc.State = Entidad.States.NoModificado;
        }
    }
}
