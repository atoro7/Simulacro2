using TiendaVideojuegos.Enums;

namespace TiendaVideojuegos.Models
{
    static public class SysVideojuego
    {
        static List<Videojuego> videojuegos = new();
        static string ArchivoVideojuegos = "videojuegos.txt";

        static public void AgregarVideojuego()
        {
            Console.Write("Ingresar nombre: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Sleccionar tipo de plataforma:");
            foreach (var plat in Enum.GetValues(typeof(Plataforma)))
            {
                Console.WriteLine($"{(int)plat}. {plat}");
            }
            int seleccion = int.Parse(Console.ReadLine());
            Plataforma plataformaSeleccion = (Plataforma)seleccion;

            Console.Write("Ingresar el precio: ");
            double precio = double.Parse(Console.ReadLine());

            Console.Write("Ingresar cantidad en Stock: ");
            int cantidadStock = int.Parse(Console.ReadLine());

            Videojuego videojuego = new Videojuego(nombre, plataformaSeleccion, precio, cantidadStock);
            videojuegos.Add(videojuego);
            GuardarVideojuego(videojuego);
        }

        static public void MostrarCatalogo()
        {
            if (videojuegos.Count == 0)
            {
                Console.WriteLine("No hay videojuegos registrados.");
            }
            else
            {
                Console.WriteLine("Catalogo:");
                foreach (var v in videojuegos)
                {
                    Console.WriteLine(v);
                }
            }
            
        }

        static public void ActualizarVideojuego(string nombre)
        {
            var videojuego = videojuegos.Find(v => v.Nombre == nombre);

            if (videojuego == null)
            {
                Console.WriteLine("Videojuego no encontrado.");
            }
            else
            {
                Console.Write("Ingresar el precio: ");
                double precio = double.Parse(Console.ReadLine());

                Console.Write("Ingresar cantidad en Stock: ");
                int cantidadStock = int.Parse(Console.ReadLine());

                videojuego.Precio = precio; 
                videojuego.CantidadStock = cantidadStock;
                GuardarDatos();
            }
        }

        static public void EliminarVideojuego(string nombre)
        {
            var videojuego = videojuegos.Find(v => v.Nombre == nombre);

            if (videojuego == null)
            {
                Console.WriteLine("Videojuego no encontrado.");
            }
            else
            {
                videojuegos.Remove(videojuego);
                GuardarDatos();
                Console.WriteLine("Juego eliminado.");
            }
        }

        static void GuardarVideojuego(Videojuego videojuego)
        {
            using StreamWriter writer = new(ArchivoVideojuegos, true);
            writer.WriteLine(videojuego);
        }

        static void GuardarDatos()
        {
            using StreamWriter writer = new(ArchivoVideojuegos);
            foreach (var v in videojuegos)
            {
                writer.WriteLine(v);
            }
        }

        static public void CargarDatos()
        {
            if (File.Exists(ArchivoVideojuegos))
            {
                foreach (var linea in File.ReadLines(ArchivoVideojuegos))
                {
                    string[] d = linea.Split(", ");

                    string nombre = d[0];
                    Plataforma plataforma = (Plataforma)Enum.Parse(typeof(Plataforma), d[1]);
                    double precio = double.Parse(d[2]);
                    int cantidadAstronautas = int.Parse(d[3]);

                    Videojuego v = new Videojuego(nombre, plataforma, precio, cantidadAstronautas);
                    videojuegos.Add(v);
                }
            }
        }
    }
}
