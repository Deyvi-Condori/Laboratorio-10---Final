using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Producto
{
    public string Nombre { get; set; }
    public string NombreReporte { get; set; }
    public int Ventas { get; set; }

    public Producto(string nombre, string nombreReporte)
    {
        Nombre = nombre;
        NombreReporte = nombreReporte;
        Ventas = 0;
    }

    public void RegistrarVenta()
    {
        Console.Clear();
        Console.WriteLine($"================================\nRegistrar venta de:\n================================");
        Console.WriteLine($"Se va a registrar la venta de un {Nombre} ¿Desea Continuar?");
        Console.WriteLine("1: Sí\n2: No\n================================");
        int opcion = PedirOpcion();

        if (opcion == 1)
        {
            Console.Write($"Ingrese unidades vendidas de {Nombre}: ");
            int ventas = int.Parse(Console.ReadLine());
            Ventas += ventas;
            Console.WriteLine($"Se han registrado {ventas} ventas para {Nombre}.");
        }
        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }

    public void RegistrarDevolucion()
    {
        Console.Clear();
        Console.WriteLine($"================================\nRegistrar devolución de:\n================================");
        Console.WriteLine($"Se va a registrar la devolución de {Nombre} ¿Desea Continuar?");
        Console.WriteLine("1: Sí\n2: No\n================================");
        int opcion = PedirOpcion();

        if (opcion == 1 && Ventas > 0)
        {
            Console.Clear();
            Console.Write($"¿Cuántas unidades de {Nombre} desea devolver? \n (Actualmente ha vendido {Ventas} unidades): ");
            int devoluciones = int.Parse(Console.ReadLine());

            if (devoluciones <= Ventas)
            {
                Ventas -= devoluciones;
                Console.WriteLine($"Se ha registrado la devolución de {devoluciones} unidades de {Nombre}.");
            }
            else
            {
                Console.WriteLine("No puede devolver más unidades de las que ha vendido.");
            }
        }
        else if (Ventas <= 0)
        {
            Console.WriteLine($"No hay ventas registradas de {Nombre} para devolver.");
        }

        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }

    private int PedirOpcion()
    {
        Console.Write("Ingrese una opción: ");
        return int.Parse(Console.ReadLine());
    }
}

