using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Materias
    {
        public Materias()
        {
            this.MateriaNegocio = new MateriaLogic();
        }


        protected MateriaLogic _MateriaNegocio;
        public MateriaLogic MateriaNegocio
        {
            get { return _MateriaNegocio; }
            set { _MateriaNegocio = value; }
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
            foreach (Materia mate in  MateriaNegocio.GetAll())
            {
                MostrarDatos(mate);
            }
        }

        public void MostrarDatos(Materia mate)
        {
            Console.WriteLine("Materia: {0}", mate.ID);
            Console.WriteLine("\t\tDescripcion: {0}", mate.Desc_materia);
            Console.WriteLine("\t\tHoras semanales: {0}", mate.Hs_semanales);
            Console.WriteLine("\t\tHoras totales: {0}", mate.Hs_totales);
            Console.WriteLine();
        }

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int id = int.Parse(Console.ReadLine());
                this.MostrarDatos(MateriaNegocio.GetOne(id));
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
                Console.Write("Ingrese el ID de la materia a modificar: ");
                int id = int.Parse(Console.ReadLine());
                Materia mate = MateriaNegocio.GetOne(id);
                Console.Write("Ingrese descripcion: ");
                mate.Desc_materia = Console.ReadLine();
                Console.Write("Ingrese horas semanales: ");
                mate.Hs_semanales = int.Parse(Console.ReadLine());
                Console.Write("Ingrese horas totales: ");
                mate.Hs_totales = int.Parse(Console.ReadLine());
                mate.State = BusinessEntity.States.Modified;
                MateriaNegocio.Save(mate);
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
            Materia mate = new Materia();

            Console.Clear();
            Console.Write("Ingrese descripcion: ");
            mate.Desc_materia = Console.ReadLine();
            Console.Write("Ingrese horas semanales: ");
            mate.Hs_semanales = int.Parse(Console.ReadLine());
            Console.Write("Ingrese horas totales: ");
            mate.Hs_totales = int.Parse(Console.ReadLine());
            mate.State = BusinessEntity.States.New;
            MateriaNegocio.Save(mate);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", mate.ID);
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID de la materia a eliminar: ");
                int id = int.Parse(Console.ReadLine());
                MateriaNegocio.Delete(id);
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
