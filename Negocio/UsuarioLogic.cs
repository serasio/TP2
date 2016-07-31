using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using System.Windows.Forms;


namespace Negocio
{
    public class UsuarioLogic : Negocio
    {
        private UsuarioAdapter _UsuarioDatos;

        public UsuarioAdapter UsuarioDatos
        {
            get { return _UsuarioDatos; }
            set { _UsuarioDatos = value; }
        }
        public UsuarioLogic()
        {
            UsuarioDatos = new UsuarioAdapter();
        }

        public List<Usuario> GetAll()
        {
            return UsuarioDatos.GetAll();
        }

        public Usuario GetOne(int ID)
        {
            return UsuarioDatos.GetOne(ID);
        }

        public List<Usuario> GetOneAlumno(int ID)
        {
            return UsuarioDatos.GetOneAlumno(ID);
        }

        public Persona GetOnePersona(string usuario, string pass)
        {
            return UsuarioDatos.GetOnePersona(usuario, pass);
        }

        public void Delete(int ID)
        {
            UsuarioDatos.Delete(ID);
        }
        public void Save(Usuario usu)
        {
            UsuarioDatos.Save(usu);
        }

        public bool Buscar(string usuario, string pass)
        {
            return UsuarioDatos.Buscar(usuario, pass);
        }

        public string RecuperarPass(string usuario, string mail)
        {
            return UsuarioDatos.RecuperarPass(usuario,mail);
        }
        public void EnviarCorreo(string mail, string pass)
        {
            UsuarioDatos.EnviarCorreo(mail,pass);
        }
    }
}