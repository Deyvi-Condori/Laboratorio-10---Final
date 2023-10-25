using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tienda
{
    public List<Producto> Productos { get; set; }

    public Tienda()
    {
        Productos = new List<Producto>
        {
            new Producto("mPhone 3000", "mPhones"),
            new Producto("mPad 3500", "mPads"),
            new Producto("MAPBrook 3800", "MAPBrooks"),
            new Producto("mWatch 8000", "mWatches")
        };
    }
    public void MostrarMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("================================\nProductos de mPhone\n================================");
            for (int i = 0; i < Productos.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Ventas de {Productos[i].Nombre}");
            }
            Console.WriteLine($"{Productos.Count + 1}: Salir\n================================");
            int opcion = PedirOpcion();

            if (opcion >= 1 && opcion <= Productos.Count)
            {
                var producto = Productos[opcion - 1];
                Console.Clear();
                Console.WriteLine($"================================\nRegistrar Venta de {producto.Nombre}\n================================");
                Console.WriteLine("1: Registrar Venta\n2: Registrar Devolución\n3: Menu Principal\n================================");
                int subopcion = PedirOpcion();

                if (subopcion == 1)
                {
                    producto.RegistrarVenta();
                }
                else if (subopcion == 2)
                {
                    producto.RegistrarDevolucion();
                }
            }
            else if (opcion == Productos.Count + 1)
            {
                MostrarEstadisticasFinales();
                return;
            }
            else
            {
                Console.WriteLine("Opción inválida. Intente nuevamente.");
            }
        }
    }

    public void MostrarEstadisticasFinales()
    {
        int totalVendido = 0;

        Console.Clear();
        Console.WriteLine("================================\nReporte Final\n================================");
        Console.WriteLine("Productos Vendidos | Cantidad");
        Console.WriteLine("--------------------------------");

        foreach (var producto in Productos)
        {
            Console.WriteLine($"{producto.NombreReporte.PadRight(20)}| {producto.Ventas}");
            totalVendido += producto.Ventas;
        }

        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Total{"".PadRight(15)}| {totalVendido}");
        Console.WriteLine("================================");
        Console.WriteLine("¡Hasta Luego!\n\n\n\n");
        Console.Write("Diseñado Por: ");
        Console.ForegroundColor = ConsoleColor.Red; 
        Console.Write("[Deyvi Condori]");
        Console.ResetColor(); 
        Console.ReadLine();
    }
    public int PedirOpcion()
    {
        Console.Write("Ingrese una opción: ");
        return int.Parse(Console.ReadLine());
    }
}
