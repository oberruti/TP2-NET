using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Cursos
    {
        public Cursos()
        {
            this.CursoNegocio = new CursoLogic();
        }


        protected CursoLogic _CursoNegocio;
        public CursoLogic CursoNegocio
        {
            get { return _CursoNegocio; }
            set { _CursoNegocio = value; }
        }


        public void Menu()
        {
            bool continua = true;
            do
            {
                Console.Clear();
                Console.WriteLine(
                    "----------MENU----------\n" +
                    "1 - Listado General.\n" +
                    "2 - Consulta.\n" +
                    "3 - Agregar.\n" +
                    "4 - Modificar.\n" +
                    "5 - Eliminar.\n" +
                    "6 - Salir.\n");
                string op = Console.ReadLine();
                switch (op)
                {
                    case "1": ListadoGeneral(); break;
                    case "2": Consultar(); break;
                    case "3": Agregar(); break;
                    case "4": Modificar(); break;
                    case "5": Eliminar(); break;
                    case "6": continua = false; break;
                    default: break;
                }
                Console.ReadLine();
            } while (continua == true);
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Curso cur in CursoNegocio.GetAll())
            {
                MostrarDatos(cur);
            }
        }

        public void MostrarDatos(Curso cur)
        {
            Console.WriteLine("Curso: {0}", cur.ID);
            Console.WriteLine("\t\tNombre: {0}", cur.Desc_curso);
            Console.WriteLine("\t\tApellido: {0}", cur.Año_calendario);
            Console.WriteLine("\t\tNombre de Curso: {0}", cur.Cupo);

            Console.WriteLine();
        }

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del Curso a consultar: ");
                int id = int.Parse(Console.ReadLine());
                this.MostrarDatos(CursoNegocio.GetOne(id));
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("El ID ingresado debe ser un número entero.");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
            }
        }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del Curso a modificar: ");
                int id = int.Parse(Console.ReadLine());
                Curso cur = CursoNegocio.GetOne(id);
                Console.Write("Ingrese Descripcion: ");
                cur.Desc_curso = Console.ReadLine();
                Console.Write("Ingrese Año: ");
                cur.Año_calendario = Console.ReadLine();
                Console.Write("Ingrese cupo");
                cur.Cupo = Console.ReadLine();
                cur.State = BusinessEntity.States.Modified;
                CursoNegocio.Save(cur);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("El ID ingresado debe ser un número entero.");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
            }
        }

        public void Agregar()
        {
            Curso cur = new Curso();

            Console.Clear();
            Console.Write("Ingrese descripcion: ");
            cur.Desc_curso = Console.ReadLine();
            Console.Write("Ingrese año : ");
            cur.Año_calendario = Console.ReadLine();
            Console.Write("Ingrese cupo");
            cur.Cupo = Console.ReadLine();
            cur.State = BusinessEntity.States.New;
            CursoNegocio.Save(cur);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", cur.ID);
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del Curso a eliminar: ");
                int id = int.Parse(Console.ReadLine());
                CursoNegocio.Delete(id);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("El ID ingresado debe ser un número entero.");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar.");
            }
        }
    }
}
