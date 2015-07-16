using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;

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

        public Entidades.Usuario GetOne(int ID)
        {
            return UsuarioDatos.GetOne(ID);
        }

        public void Delete(int ID)
        {
            UsuarioDatos.Delete(ID);
        }
        public void Save (Entidades.Usuario usu)
        {
            UsuarioDatos.Save(usu);
        }
    }
}
 
