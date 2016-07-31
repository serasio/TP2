using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace UI.Web
{
    public partial class MenuPpal : System.Web.UI.Page
    {
        protected Persona UsuarioLogueado
        {
            get { return (Persona)Session["Usuario"]; }
            set { UsuarioLogueado = (Persona)Session["Usuario"]; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            QuitarItems(Menu1.Items);
            
        }

        private void QuitarItems(MenuItemCollection items)
        {
            MenuItem[] itemsToRemove = new MenuItem[items.Count];
            int i = 0;
            if (UsuarioLogueado.TipoPersona == Persona.TiposPersonas.Alumno)
            {
                foreach (MenuItem item in items)
                {
                    if((item.Value=="Alumno") || (item.Value=="Ambos"))
                    {
                        if (item.ChildItems.Count > 0) QuitarItems(item.ChildItems);
                    }
                    else
                    {
                        itemsToRemove[i] = item;
                        i++; 
                    }
                }
                for (int j = 0; j < i; j++)
                {
                    items.Remove(itemsToRemove[j]);
                }
            }   

            if (UsuarioLogueado.TipoPersona == Persona.TiposPersonas.Docente)
            {
                foreach (MenuItem item in items)
                {
                    if ((item.Value == "Profesor") || (item.Value == "Ambos"))
                    {
                        if (item.ChildItems.Count > 0) QuitarItems(item.ChildItems);
                    }
                    else
                    {
                        itemsToRemove[i] = item;
                        i++; 
                    }
                }
                for (int j = 0; j < i; j++)
                {
                    items.Remove(itemsToRemove[j]);
                }
            }  
        }
    }
}