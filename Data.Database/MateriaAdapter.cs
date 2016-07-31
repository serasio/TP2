using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias inner join planes "+
                    "on materias.id_plan = planes.id_plan inner join especialidades "+
                    "on planes.id_especialidad = especialidades.id_especialidad", SqlConn);

                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();

                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];
                    mat.DescripcionPlan = (string)drMaterias["desc_plan"];
                    mat.DescripcionEspecialidad = (string)drMaterias["desc_especialidad"];
                    mat.DescripcionPlanCarrera = mat.DescripcionPlan + " - " + mat.DescripcionEspecialidad;
                    mat.IDEspecialidad = (int)drMaterias["id_especialidad"];
                    materias.Add(mat);
                }
                drMaterias.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public List<Materia> GetAll(int IDPlan)
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias inner join planes " +
                    "on materias.id_plan = planes.id_plan inner join especialidades " +
                    "on planes.id_especialidad = especialidades.id_especialidad where materias.id_plan = @id_plan", SqlConn);

                cmdMaterias.Parameters.Add("@id_plan", SqlDbType.Int).Value = IDPlan;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();

                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];
                    mat.DescripcionPlan = (string)drMaterias["desc_plan"];
                    mat.DescripcionEspecialidad = (string)drMaterias["desc_especialidad"];
                    mat.DescripcionPlanCarrera = mat.DescripcionPlan + " - " + mat.DescripcionEspecialidad;
                    mat.IDEspecialidad = (int)drMaterias["id_especialidad"];
                    materias.Add(mat);
                }
                drMaterias.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public List<Materia> GetAllAlumno(int IDPlan)
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias inner join planes " +
                    "on materias.id_plan = planes.id_plan inner join especialidades " +
                    "on planes.id_especialidad = especialidades.id_especialidad where materias.id_plan = @id_plan", SqlConn);

                cmdMaterias.Parameters.Add("@id_plan", SqlDbType.Int).Value = IDPlan;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];
                    mat.DescripcionPlan = (string)drMaterias["desc_plan"];
                    mat.DescripcionEspecialidad = (string)drMaterias["desc_especialidad"];
                    mat.IDEspecialidad = (int)drMaterias["id_especialidad"];
                    mat.DescripcionPlanCarrera = mat.DescripcionPlan + " - " + mat.DescripcionEspecialidad;
                    materias.Add(mat);
                }
                drMaterias.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public Materia GetOne(int ID)
        {
            Materia mat = new Materia();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("select * from materias where id_materia = @id", SqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                if (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return mat;
        }


        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE materias SET desc_materia=@desc_materia, hs_semanales=@hs_semanales, hs_totales=@hs_totales, id_plan=@id_plan " +
                "WHERE id_materia=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = mat.ID;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = mat.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = mat.HSTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.IDPlan;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "insert into materias(desc_materia,hs_semanales,hs_totales,id_plan) " +
                "values(@desc_materia,@hs_semanales,@hs_totales,@id_plan)" +
                "select @@identity", SqlConn); 

                cmdInsert.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.Descripcion;
                cmdInsert.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = mat.HSSemanales;
                cmdInsert.Parameters.Add("@hs_totales", SqlDbType.Int).Value = mat.HSTotales;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.IDPlan;
                mat.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Materia mat)
        {
            if (mat.State == Entidad.States.Eliminado)
            {
                this.Delete(mat.ID);
            }
            else if (mat.State == Entidad.States.Nuevo)
            {
                this.Insert(mat);
            }
            else if (mat.State == Entidad.States.Modificado)
            {
                this.Update(mat);
            }
            mat.State = Entidad.States.NoModificado;
        }
    }
}

