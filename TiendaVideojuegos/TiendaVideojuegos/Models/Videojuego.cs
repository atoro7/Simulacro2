using TiendaVideojuegos.Enums;

namespace TiendaVideojuegos.Models
{
    public class Videojuego
    {
        public string Nombre { get; private set; }
        public Plataforma Plataforma { get; private set; }
        public double Precio { get; set; }
        public int CantidadStock { get; set; }

        public Videojuego(string nombre, Plataforma plataforma, double precio, int cantidadStock)
        {
            Nombre = nombre;
            Plataforma = plataforma;
            Precio = precio;
            CantidadStock = cantidadStock;
        }

        public override string ToString()
        {
            return $"{Nombre}, {Plataforma}, {Precio}, {CantidadStock}";
        }
    }
}
