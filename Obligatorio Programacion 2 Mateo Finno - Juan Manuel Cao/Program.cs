using dominio;
using System.Security.Cryptography.X509Certificates;

namespace Obligatorio_Programacion_2_Mateo_Finno___Juan_Manuel_Cao
{
    internal class Program
    {
        static Sistema sistema = new Sistema();
        static void Main(string[] args)
        {

            bool salir = false;

            while (!salir)
            {
                Console.Clear();

                Console.WriteLine("======================================");
                Console.WriteLine(" SISTEMA DE INCIDENTES CIBERNETICOS");
                Console.WriteLine("======================================");
                Console.WriteLine("1 - Listar personas y activos");
                Console.WriteLine("2 - Listar incidentes por persona");
                Console.WriteLine("3 - Alta de persona");
                Console.WriteLine("4 - Listar activos sin backup");
                Console.WriteLine("0 - Salir");
                Console.WriteLine("======================================");

                Console.Write("Ingrese una opcion: ");

                string opcion = Console.ReadLine();

                try
                {
                    switch (opcion)
                    {
                        case "1":

                            Console.Clear();

                            ListarPersonasYActivos();
                            Console.ReadLine();

                            break;

                        case "2":

                            Console.Clear();

                            Console.Write("Ingrese cedula de la persona: ");

                            string cedula = Console.ReadLine();

                            ListarIncidentesPorPersona(cedula);

                            Console.ReadLine();

                            break;

                        case "3":
                            Console.Clear();

                            IngresarDatosPersona();

                            Console.ReadLine();

                            break;

                        case "4":

                            Console.Clear();

                            sistema.ListarActivosSinBackup();

                            ListarActivosSinBackup();

                            Console.ReadLine();

                            break;

                        case "0":

                            salir = true;

                            break;

                        default:

                            Console.WriteLine("Opcion invalida");

                            Console.ReadLine();

                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }


        }

        public static void ListarPersonasYActivos()
        {
            Console.WriteLine("LISTA DE PERSONAS CON SUS ACTIVOS");
            foreach (Persona p in sistema.ObtenerPersonas())
            {
                List<Activo> Activos = sistema.ObteneraActivoPorPersona(p);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("==========PERSONA=============");
                Console.WriteLine();
                Console.WriteLine(p);
                Console.WriteLine();
                Console.WriteLine("==========ACTIVOS=============");

                foreach (Activo a in Activos)
                {
                    Console.WriteLine(a.ToString());
                    Console.WriteLine("==========================");
                }
            }
        }

        public static void ListarIncidentesPorPersona(string cedula)
        {
            Console.Clear();
            Persona p = sistema.BuscarPersonaPorCedula(cedula);
            Console.WriteLine("==========PERSONA=============");
            Console.WriteLine(p.Nombre);
            foreach (Incidente i in sistema.ObtenerIncidentePorPersona(p))
            {
                Console.WriteLine(i.ToString());
            }
        }

        public static void ListarActivosSinBackup()
        {
            foreach (Activo a in sistema.ListarActivosSinBackup())
            {
                Console.WriteLine("ACTIVOS SIN BACKUP");
                Console.WriteLine(a.ToString());
                Console.WriteLine("==========================");
                Console.WriteLine();
            }
        }

        public static void IngresarDatosPersona()
        {
            Console.Clear();

            Console.Write("Cedula: ");
            string cedulaNueva = Console.ReadLine();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            int telefono = 0;
            
            Console.Write("Telefono: ");

            bool ok = int.TryParse(Console.ReadLine(), out telefono);
            

            Persona nuevaPersona = new Persona(cedulaNueva, nombre, email, telefono);

            sistema.AltaPersona(nuevaPersona);

            Console.WriteLine("Persona agregada correctamente");
        }


    }
}
