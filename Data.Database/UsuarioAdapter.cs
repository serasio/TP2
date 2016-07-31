using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;


namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {

        static List<Usuario> _Usuarios;

        #region Datos hardcodeados
        private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Usuario>();
                    Usuario usr = new Usuario();
                    usr.ID = 1;
                    usr.State = Entidad.States.NoModificado;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "miro";
                    usr.Email = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Usuario();
                    usr.ID = 2;
                    usr.State = Entidad.States.NoModificado;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.Email = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Usuario();
                    usr.ID = 3;
                    usr.State = Entidad.States.NoModificado;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.Email = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion

        public List<Usuario> GetAll()
        {
            //instanciamos el objeto lista a retornar
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                //abrimos la conexion a la base de datos
                this.OpenConnection();

                /*creamos un objeto SqlCommand que sera la sentencia SQL
                 que vamos a ejecutar contra la base de datos*/

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", SqlConn);

                /*instanciamos un objeto DataReader que sera
                 el que recuperara los datos de la DB*/

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                /*carga los datos en drUsuarios para poder accederlos*/

                while (drUsuarios.Read())
                {

                    /*creamos un objeto Usuario de la capa de entidades para copiar los datos
                     de la fila del DataReader al objeto de entidades*/

                    Usuario usr = new Usuario();

                    //ahora copiamos los datos de la fila al objeto
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];
                    //agregamos el objeto con datos a la lista que devolveremos
                    usuarios.Add(usr);
                }
                //cerramos el DataReader y la conexion a la DB
                drUsuarios.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            //devolvemos el objeto
            return usuarios;
        }

        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();

            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario = @id", SqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public List<Usuario> GetOneAlumno(int ID)
        {
            List<Usuario> listusr = new List<Usuario>();

            try
            {
                this.OpenConnection();
                Usuario usr = new Usuario();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario = @id", SqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];
                    listusr.Add(usr);
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return listusr;
        }

        public Persona GetOnePersona(string usuario, string pass)
        {
            Persona per = new Persona();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas inner join usuarios on " +
                    "personas.id_persona = usuarios.id_persona where usuarios.nombre_usuario = @usuario "+
                    "and usuarios.clave = @pass", SqlConn);
                cmdPersonas.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                cmdPersonas.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                    
                if (drPersonas.Read())
                    {
                        per.ID = (int)drPersonas["id_persona"];
                        per.IDUsuario = (int)drPersonas["id_usuario"];
                        per.TipoPersona = (Persona.TiposPersonas)drPersonas["tipo_persona"];
                        if (per.TipoPersona == Persona.TiposPersonas.Alumno)    
                            per.IDPlan = (int)drPersonas["id_plan"];
                    }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar persona", Ex);
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

                //crea sentencia sql y asigna valor al parametro
                SqlCommand cmdDelete = new SqlCommand("delete usuarios where id_usuario=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE usuarios SET nombre_usuario=@nombre_usuario, clave=@clave, " +
                "habilitado=@habilitado, nombre=@nombre, apellido=@apellido, email=@email, cambia_clave=null," +
                " id_persona=@id_persona" +
                " WHERE id_usuario=@id", SqlConn);

                SqlCommand cmdUpdatePer = new SqlCommand("UPDATE personas SET email=@emailper WHERE id_persona=@id_persona", SqlConn);
                cmdUpdatePer.Parameters.Add("@emailper", SqlDbType.VarChar).Value = usuario.Email;
                cmdUpdatePer.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;

                cmdSave.ExecuteNonQuery();
                cmdUpdatePer.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "insert into usuarios(nombre_usuario,clave,habilitado,nombre,apellido,email,"
                + "cambia_clave,id_persona) " +
                "values(@nombre_usuario,@clave,@habilitado,@nombre,@apellido,@email,null,@id_persona)" +
                "select @@identity", SqlConn); //para recuperar el ID q asigno el sql automaticamente

                SqlCommand cmdUpdatePer = new SqlCommand("update personas set email=@emailper WHERE id_persona=@id_persona", SqlConn);
                cmdUpdatePer.Parameters.Add("@emailper", SqlDbType.VarChar).Value = usuario.Email;
                cmdUpdatePer.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;
                cmdInsert.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdInsert.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdInsert.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdInsert.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;
                usuario.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
                cmdUpdatePer.ExecuteNonQuery();
                //asi se obtiene ID q se asigno automaticamente
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {
            if (usuario.State == Entidad.States.Eliminado)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == Entidad.States.Nuevo)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == Entidad.States.Modificado)
            {
                this.Update(usuario);
            }
            usuario.State = Entidad.States.NoModificado;
        }

        public bool Buscar(string usuario, string pass)
        {
            bool res = false;
            try
            {
                this.OpenConnection();
                SqlCommand cmdBuscar = new SqlCommand("select id_usuario from usuarios " +
                    "where nombre_usuario=@usuario and clave=@pass and habilitado=1", SqlConn);
                cmdBuscar.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                cmdBuscar.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                SqlDataReader drBuscar = cmdBuscar.ExecuteReader();
                if (drBuscar.Read())
                {
                    res = true;
                }
                drBuscar.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return res;
        }
        public string RecuperarPass(string usuario, string mail)
        {
            string res = null;
            try
            {
                this.OpenConnection();
                SqlCommand cmdBuscar = new SqlCommand("select clave from usuarios " +
                    "where nombre_usuario=@usuario and email=@mail and habilitado = 1", SqlConn);
                cmdBuscar.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                cmdBuscar.Parameters.Add("@mail", SqlDbType.VarChar).Value = mail;
                SqlDataReader drBuscar = cmdBuscar.ExecuteReader();
                if (drBuscar.Read())
                {
                    res = (string)drBuscar["clave"];
                }
                drBuscar.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return res;
        }
        public void EnviarCorreo(string mail, string pass)
        {
            MailMessage ms = new MailMessage("aplicacion_net@hotmail.com", mail);
            ms.Subject = "Recuperación de contraseña";
            ms.Body = "Su contraseña es: " + pass;
            ms.IsBodyHtml = false;
            ms.Priority = MailPriority.Normal;
            SmtpClient sc = new SmtpClient("smtp.live.com", 587);
            sc.UseDefaultCredentials = false;
            sc.Credentials = new NetworkCredential("aplicacion_net@hotmail.com","Passnet2015");
            sc.EnableSsl = true;
            try
            {
                sc.Send(ms);
                ms.Dispose();
            }
            catch (Exception ex)
            {
                Exception excepcion = new Exception("Error al enviar mail", ex);
                throw excepcion;
            }
        }
    }
}
