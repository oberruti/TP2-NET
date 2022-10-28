using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    class Comisiones
    {
        public Comisiones()
        {
            this.ComisionNegocio = new ComisionLogic();
        }


        protected ComisionLogic _ComisionNegocio;
        public ComisionLogic ComisionNegocio
        {
            get { return _ComisionNegocio; }
            set { _ComisionNegocio = value; }
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
            foreach (Comision com in ComisionNegocio.GetAll())
            {
                MostrarDatos(com);
            }
        }

        public void MostrarDatos(Comision com)
        {
            Console.WriteLine("Comision: {0}", com.ID);
            Console.WriteLine("\t\tDescripcion: {0}", com.Desc_comision);
            Console.WriteLine("\t\tAño especialidad: {0}", com.Anio_especialidad);
            Console.WriteLine();
        }

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID de la comision a consultar: ");
                int id = int.Parse(Console.ReadLine());
                this.MostrarDatos(ComisionNegocio.GetOne(id));
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
                Console.Write("Ingrese el ID de la comision a modificar: ");
                int id = int.Parse(Console.ReadLine());
                Comision com = ComisionNegocio.GetOne(id);
                Console.Write("Ingrese descripcion: ");
                com.Desc_comision = Console.ReadLine();
                Console.Write("Ingrese año especialidad: ");
                com.Anio_especialidad = Console.ReadLine();
                com.State = BusinessEntity.States.Modified;
                ComisionNegocio.Save(com);
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
            Comision com = new Comision();

            Console.Clear();
            Console.Write("Ingrese descripcion: ");
            com.Desc_comision = Console.ReadLine();
            Console.Write("Ingrese año especialidad: ");
            com.Anio_especialidad = Console.ReadLine();
            com.State = BusinessEntity.States.New;
            ComisionNegocio.Save(com);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", com.ID);
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID de la comision a eliminar: ");
                int id = int.Parse(Console.ReadLine());
                ComisionNegocio.Delete(id);
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
