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
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("select * from planes inner join especialidades"+
                    " on especialidades.id_especialidad = planes.id_especialidad", SqlConn);

                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                while (drPlanes.Read())
                {
                    Plan plan = new Plan();

                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    plan.DescEspecialidad = (string)drPlanes["desc_especialidad"];
                    plan.PlanEspecialidadDesc = plan.Descripcion + " - " + plan.DescEspecialidad;
                    planes.Add(plan);
                }
                drPlanes.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return planes;
        }


        //Este getall recupera los planes de una especialidad seleccionada en el otro combo del form
        public List<Plan> GetAll(int idEsp)
        {
            List<Plan> planes = new List<Plan>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("select * from planes inner join especialidades" +
                    " on especialidades.id_especialidad = planes.id_especialidad"+
                    " where planes.id_especialidad = @id", SqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = idEsp;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                while (drPlanes.Read())
                {
                    Plan plan = new Plan();

                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    plan.DescEspecialidad = (string)drPlanes["desc_especialidad"];
                    planes.Add(plan);
                }
                drPlanes.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return planes;
        }

        public Plan GetOne(int ID)
        {
            Plan plan = new Plan();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("select * from planes inner join especialidades"+
                    " on planes.id_especialidad = especialidades.id_especialidad where id_plan = @id", SqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                if (drPlanes.Read())
                {
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    plan.DescEspecialidad = (string)drPlanes["desc_especialidad"];
                    plan.PlanEspecialidadDesc = plan.Descripcion + " - " + plan.DescEspecialidad;
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return plan;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete planes where id_plan=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE planes SET desc_plan=@desc_plan, id_especialidad=@id_especialidad  " +
                "WHERE id_plan=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "insert into planes(desc_plan,id_especialidad) " +
                "values(@desc_plan,@id_especialidad)" +
                "select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdInsert.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                plan.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            if (plan.State == Entidad.States.Eliminado)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == Entidad.States.Nuevo)
            {
                this.Insert(plan);
            }
            else if (plan.State == Entidad.States.Modificado)
            {
                this.Update(plan);
            }
            plan.State = Entidad.States.NoModificado;
        }
    }
}
