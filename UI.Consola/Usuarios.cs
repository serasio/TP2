using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Entidades;

namespace UI.Consola
{
    public class Usuarios
    {
        
        UsuarioLogic _UsuarioNegocio;

        public UsuarioLogic UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value; }
        }

        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }

        public void Menu()
        {
            int opc = 0;
            do
            {
                Console.WriteLine("MENU");
                Console.WriteLine("");
                Console.WriteLine("1.- Listado General");
                Console.WriteLine("2.- Consulta");
                Console.WriteLine("3.- Agregar");
                Console.WriteLine("4.- Modificar");
                Console.WriteLine("5.- Eliminar");
                Console.WriteLine("6.- Salir");
                Console.WriteLine();
                Console.Write("Opción: ");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        ListadoGeneral();
                        break;

                    case 2:
                        Consultar();
                        break;

                    case 3:
                        Agregar();
                        break;

                    case 4:
                        Modificar();
                        break;

                    case 5:
                        Eliminar();
                        break;

                    case 6:
                        break;

                    default: Console.WriteLine("Opcion incorrecta!");
                        break;
                }


            } while (opc != 6);
        }

        public void ListadoGeneral ()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        
        public void MostrarDatos (Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine();
        }

        public void Consultar()
        {

            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException ex)
            {
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Modificar ()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                if (usuario != null)
                {
                    Console.Write("Ingrese Nombre: ");
                    usuario.Nombre = Console.ReadLine();
                    Console.Write("Ingrese Apellido: ");
                    usuario.Apellido = Console.ReadLine();
                    Console.Write("Ingrese Nombre de Usuario: ");
                    usuario.NombreUsuario = Console.ReadLine();
                    Console.Write("Ingrese Clave: ");
                    usuario.Clave = Console.ReadLine();
                    Console.Write("Ingrese Email: ");
                    usuario.Email = Console.ReadLine();
                    Console.Write("Ingrese Habilitaciòn de Usuario (1-Si/otro-No): ");
                    usuario.Habilitado = (Console.ReadLine() == "1");
                    usuario.State = Entidad.States.Modified;
                    UsuarioNegocio.Save(usuario);
                }
                else
                {
                    Console.WriteLine("Usuario inexistente.");
                }

            }

            catch (FormatException ex)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un nùmero entero.");
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
            
        }

        public void Agregar()
        {
            Usuario usuario = new Usuario();
            Console.Clear();
            Console.Write("Ingrese Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese Apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese Nombre de Usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese Clave: ");
            usuario.Clave = Console.ReadLine();
            Console.Write("Ingrese Email: ");
            usuario.Email = Console.ReadLine();
            Console.Write("Ingrese Habilitaciòn de Usuario (1-Si/otro-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = Entidad.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

        }

        public void Eliminar()
        { 
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException ex)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un nùmero entero.");
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
