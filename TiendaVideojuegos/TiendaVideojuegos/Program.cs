using TiendaVideojuegos.Models;

namespace TiendaVideojuegos
{
    public class Program
    {
        static void Main()
        {
            SysVideojuego.CargarDatos();
            int opcion;
          
            do
            {
                Console.WriteLine("\n     --- Menu ---");
                Console.WriteLine("1. Agregar videojuego.");
                Console.WriteLine("2. Mostrar catalogo.");
                Console.WriteLine("3. Actualizar videojuego.");
                Console.WriteLine("4. Eliminar videojuego.");
                Console.WriteLine("5. Guardar y Salir.");

                Console.Write("Opcion: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\n");
                        SysVideojuego.AgregarVideojuego();
                        break;

                    case 2:
                        Console.WriteLine("\n");
                        SysVideojuego.MostrarCatalogo();
                        break;

                    case 3:
                        Console.WriteLine("\n");
                        Console.Write("Ingresar nombre del videojuego a actualizar: ");
                        string nombre1 = Console.ReadLine();
                        SysVideojuego.ActualizarVideojuego(nombre1);
                        break;

                    case 4:
                        Console.WriteLine("\n");
                        Console.WriteLine("Ingresar nombre del videojuego a eliminar: ");
                        string nombre2 = Console.ReadLine();
                        SysVideojuego.EliminarVideojuego(nombre2);
                        break;
                }
            } while (opcion != 5);
        }
    }
}