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
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones inner join planes "+
                    " on comisiones.id_plan = planes.id_plan inner join especialidades on "+
                "especialidades.id_especialidad = planes.id_especialidad", SqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision com = new Comision();
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];
                    com.ComisionEspDesc = (string)drComisiones["desc_comision"] + " - " + (string)drComisiones["desc_especialidad"];
                    com.PlanEspDescripcion = (string)drComisiones["desc_plan"] + " - " + (string)drComisiones["desc_especialidad"];
                    comisiones.Add(com);
                }
                drComisiones.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }

        public List<Comision> GetComisionesAnio(int anioEsp, int idPlan)
        {
            List<Comision> comisiones = new List<Comision>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones inner join planes " +
                    " on comisiones.id_plan = planes.id_plan inner join especialidades on " +
                "especialidades.id_especialidad = planes.id_especialidad " +
                "where comisiones.anio_especialidad=@anioEsp and planes.id_plan=@id", SqlConn);

                cmdComisiones.Parameters.Add("@anioEsp", SqlDbType.Int).Value = anioEsp;
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = idPlan;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision com = new Comision();
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];
                    comisiones.Add(com);
                }
                drComisiones.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }



        public Comision GetOne(int ID)
        {
            Comision com = new Comision();

            try
            {
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones where id_comision = @id", SqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                if (drComisiones.Read())
                {
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return com;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE comisiones SET desc_comision=@desc_comision, anio_especialidad=@anio_especialidad, id_plan=@id_plan  " +
                "WHERE id_comision=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "insert into comisiones(desc_comision,id_plan,anio_especialidad) " +
                "values(@desc_comision,@id_plan,@anio_especialidad)" +
                "select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                cmdInsert.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                comision.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            if (comision.State == Entidad.States.Eliminado)
            {
                this.Delete(comision.ID);
            }
            else if (comision.State == Entidad.States.Nuevo)
            {
                this.Insert(comision);
            }
            else if (comision.State == Entidad.States.Modificado)
            {
                this.Update(comision);
            }
            comision.State = Entidad.States.NoModificado;
        }
    }
}
