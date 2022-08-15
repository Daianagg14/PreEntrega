using System;
using System.Collections.Generic;
using PreEntrega.Modelo;
namespace PreEntrega
{
    class Program
    {
        static void Main(string[] args)
        {

            string nombreUsuario = "eperez";
            UsuarioHandler uh = new UsuarioHandler();
            
           
            Console.WriteLine(uh.TraerUsuario(nombreUsuario).Nombre);
            Console.WriteLine(uh.TraerUsuario(nombreUsuario).Apellido);
            Console.WriteLine(uh.TraerUsuario(nombreUsuario).NombreUsuario);
            Console.WriteLine(uh.TraerUsuario(nombreUsuario).Mail);
            Console.WriteLine(uh.TraerUsuario(nombreUsuario).Contraseña);
            Console.WriteLine("--------- Fin prueba: método TraerUsuario -----------\n");


            List<Producto> productosVendidos = new List<Producto>();
            ProductoHandler ph = new ProductoHandler();
            Console.WriteLine("ingresar el id del producto vendido (valor sugerido = 1):");
            //ph.TraerProductoVendido(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine(ph.TraerProductoVendido(Convert.ToInt32(Console.ReadLine())));

            Console.WriteLine("------------Fin prueba: método TraerProductoVendido-----------\n");



            Usuario login = new Usuario();
            login = UsuarioHandler.Login();
            
            Console.WriteLine("\n"+ login.Nombre +" "+ login.Apellido + " " + login.NombreUsuario + " " + login.Mail + " " + login.Contraseña);
            Console.WriteLine("------------Fin prueba: método Login-----------\n");

            List<Venta> ventas = new List<Venta>();
            VentaHandler vh = new VentaHandler();
            Console.WriteLine("ingresar el id del usuario (valor sugerido = 1):");
            //ph.TraerProductoVendido(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine(vh.TraerVenta(Convert.ToInt32(Console.ReadLine())));

            Console.WriteLine("------------Fin prueba: método TraerVenta-----------\n");

        }

        
    }
}
