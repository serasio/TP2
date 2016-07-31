using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll(Persona.TiposPersonas tipo)
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas inner join planes "+
                "on planes.id_plan = personas.id_plan inner join especialidades on "+
                "especialidades.id_especialidad = planes.id_especialidad where tipo_persona=@tipo", SqlConn);
                cmdPersonas.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (tipo == Persona.TiposPersonas.Alumno)
                {
                    while (drPersonas.Read())
                    {

                        Persona per = new Persona();
                        per.ID = (int)drPersonas["id_persona"];
                        per.Nombre = (string)drPersonas["nombre"];
                        per.Apellido = (string)drPersonas["apellido"];
                        per.Direccion = (string)drPersonas["direccion"];
                        //per.Email = (string)drPersonas["email"];
                        per.Telefono = (string)drPersonas["telefono"];
                        per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                        per.TipoPersona = (Persona.TiposPersonas)drPersonas["tipo_persona"];
                        per.Legajo = (int)drPersonas["legajo"];
                        per.IDPlan = (int)drPersonas["id_plan"];
                        per.PlanEspecialidadDesc = (string)drPersonas["desc_plan"]+" - "+(string)drPersonas["desc_especialidad"];
                        personas.Add(per);
                    }
                }
                else
                {
                    while (drPersonas.Read())
                    {

                        Persona per = new Persona();
                        per.ID = (int)drPersonas["id_persona"];
                        per.Nombre = (string)drPersonas["nombre"];
                        per.Apellido = (string)drPersonas["apellido"];
                        per.Direccion = (string)drPersonas["direccion"];
                        //per.Email = (string)drPersonas["email"];
                        per.Telefono = (string)drPersonas["telefono"];
                        per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                        per.TipoPersona = (Persona.TiposPersonas)drPersonas["tipo_persona"];
                        per.Legajo = (int)drPersonas["legajo"];
                        personas.Add(per);
                    }
                }
                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                string str = null;
                Exception ExcepcionManejada = new Exception(str , Ex);
                if (tipo == Persona.TiposPersonas.Alumno)
                
                    str = "Error al recuperar lista de alumnos";

                if (tipo == Persona.TiposPersonas.Docente)

                    str = "Error al recuperar lista de profesores";

                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return personas;
        }

        public List<Persona> GetNom()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select id_persona, nombre, apellido from personas", SqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {

                    Persona per = new Persona();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.NombreYApellido = per.Nombre + " " + per.Apellido;
                    personas.Add(per);

                }
                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar personas",Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return personas;
        }

        public List<Persona> GetNom(Persona.TiposPersonas tipo)
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas;
                if (tipo == Persona.TiposPersonas.Alumno)
                   cmdPersonas = new SqlCommand("select id_persona, nombre, apellido, id_plan from personas where" +
                        " tipo_persona = @tipo", SqlConn);
                
                else
                {
                    cmdPersonas = new SqlCommand("select id_persona, nombre, apellido from personas where" +
                        " tipo_persona = @tipo", SqlConn);
                }
                cmdPersonas.Parameters.Add("@tipo", SqlDbType.Int).Value = (int)tipo;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {

                    Persona per = new Persona();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.NombreYApellido = per.Nombre + " " + per.Apellido;
                    if (tipo == Persona.TiposPersonas.Alumno)
                    per.IDPlan = (int)drPersonas["id_plan"];
                    personas.Add(per);

                }
                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar personas", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return personas;
        }

        public Persona GetOne(int ID, Persona.TiposPersonas tipo)
        {
            Persona per = new Persona();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas "+
                    "where id_persona = @id and tipo_persona=@tipo", SqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdPersonas.Parameters.Add("@tipo", SqlDbType.Int).Value = (int)tipo;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                if (tipo == Persona.TiposPersonas.Alumno)
                {
                    if (drPersonas.Read())
                    {
                        per.ID = (int)drPersonas["id_persona"];
                        per.Nombre = (string)drPersonas["nombre"];
                        per.Apellido = (string)drPersonas["apellido"];
                        per.Direccion = (string)drPersonas["direccion"];
                        //per.Email = (string)drPersonas["email"];
                        per.Telefono = (string)drPersonas["telefono"];
                        per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                        per.Legajo = (int)drPersonas["legajo"];
                        per.TipoPersona = (Persona.TiposPersonas)drPersonas["tipo_persona"];
                        //per.PlanEspecialidadDesc = 
                        per.IDPlan = (int)drPersonas["id_plan"];
                    }
                }
                else
                {
                    if (drPersonas.Read())
                    {
                        per.ID = (int)drPersonas["id_persona"];
                        per.Nombre = (string)drPersonas["nombre"];
                        per.Apellido = (string)drPersonas["apellido"];
                        per.Direccion = (string)drPersonas["direccion"];
                        //per.Email = (string)drPersonas["email"];
                        per.Telefono = (string)drPersonas["telefono"];
                        per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                        per.Legajo = (int)drPersonas["legajo"];
                        per.TipoPersona = (Persona.TiposPersonas)drPersonas["tipo_persona"];
                    }
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                string str = null;
                Exception ExcepcionManejada = new Exception(str, Ex);
                if (tipo == Persona.TiposPersonas.Alumno)

                    str = "Error al recuperar lista de alumnos";

                if (tipo == Persona.TiposPersonas.Docente)

                    str = "Error al recuperar lista de profesores";

                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return per;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Persona persona)
        {
            try
            {
                if (persona.TipoPersona == Persona.TiposPersonas.Alumno)
                {
                    this.OpenConnection();
                    SqlCommand cmdSave = new SqlCommand(
                        "UPDATE personas SET nombre=@nombre, apellido=@apellido, direccion=@direccion, email=null," +
                    " telefono=@telefono, fecha_nac=@fecha_nac, legajo=@legajo, tipo_persona=@tipo_persona, id_plan=@id_plan " +
                    "WHERE id_persona=@id", SqlConn);

                    cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                    cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                    cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                    cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                    //cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                    cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                    cmdSave.Parameters.Add("@fecha_nac", SqlDbType.VarChar, 50).Value = persona.FechaNacimiento;
                    cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                    cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int)persona.TipoPersona;
                    cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                    cmdSave.ExecuteNonQuery();
                }
                else
                {
                    this.OpenConnection();
                    SqlCommand cmdSave = new SqlCommand(
                        "UPDATE personas SET nombre=@nombre, apellido=@apellido, direccion=@direccion, email=null," +
                    " telefono=@telefono, fecha_nac=@fecha_nac, legajo=@legajo, tipo_persona=@tipo_persona, id_plan=null " +
                    "WHERE id_persona=@id", SqlConn);

                    cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                    cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                    cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                    cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                    //cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                    cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                    cmdSave.Parameters.Add("@fecha_nac", SqlDbType.VarChar, 50).Value = persona.FechaNacimiento;
                    cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                    cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int)persona.TipoPersona;
                    cmdSave.ExecuteNonQuery();
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Persona persona)
        {
            try
            {
                if (persona.TipoPersona == Persona.TiposPersonas.Alumno)
                {
                    this.OpenConnection();
                    SqlCommand cmdInsert = new SqlCommand(
                        "insert into personas (nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan) " +
                    "values(@nombre,@apellido,@direccion,null,@telefono,@fecha_nac,@legajo,@tipo_persona,@id_plan)" +
                    "select @@identity", SqlConn);

                    cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                    cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                    cmdInsert.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                    //cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                    cmdInsert.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                    cmdInsert.Parameters.Add("@fecha_nac", SqlDbType.VarChar, 50).Value = persona.FechaNacimiento;
                    cmdInsert.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                    cmdInsert.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int)persona.TipoPersona;
                    cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                    persona.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
                }
                else
                {
                    this.OpenConnection();
                    SqlCommand cmdInsert = new SqlCommand(
                        "insert into personas (nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan) " +
                    "values(@nombre,@apellido,@direccion,null,@telefono,@fecha_nac,@legajo,@tipo_persona,null)" +
                    "select @@identity", SqlConn);

                    cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                    cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                    cmdInsert.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                    //cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                    cmdInsert.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                    cmdInsert.Parameters.Add("@fecha_nac", SqlDbType.VarChar, 50).Value = persona.FechaNacimiento;
                    cmdInsert.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                    cmdInsert.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int)persona.TipoPersona;
                    persona.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
                }
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Persona persona)
        {
            if (persona.State == Entidad.States.Eliminado)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == Entidad.States.Nuevo)
            {
                this.Insert(persona);
            }
            else if (persona.State == Entidad.States.Modificado)
            {
                this.Update(persona);
            }
            persona.State = Entidad.States.NoModificado;
        }
    }
}

