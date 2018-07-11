using System;
using System.Collections;

namespace SistemaVentas
{
    public class VistaGestionCarro
    {
		private string[] opciones;
        private Dibujante dibujante;
        private ServiciosProducto serviceProducts;
        private ServiciosCompra serviceCompra;

		public VistaGestionCarro(Dibujante dibujante, ServiciosProducto serviceProducts, ServiciosCompra serviceCompra)
        {
			this.serviceProducts = serviceProducts;
            this.serviceCompra = serviceCompra;
            this.dibujante = dibujante;
			this.opciones = new string[] { "1 - Agregar item al carro" ,
                "2 - Quitar item del carro",
                "3 - Listar items del carro",
                "4 - Volver"};
        }

		public void pantallaPrincipal()
        {
            Console.Clear();
            dibujante.cabezera("Modulo compras- Agregar Productos al carro - Sistema de ventas Online");
            dibujante.cuerpo(opciones);
            dibujante.pie("Hola , que acción desea realizar?", "Teclee el número de opción: ");
            string opcion = Console.ReadLine();
			opcionSeleccionada(opcion);
        }

		public void opcionSeleccionada(string opcionElegida)
        {
			switch (opcionElegida)
            {
				case "1":
					try {
						serviceCompra.agregarProductoAlCarro(serviceProducts);
					} catch (FormatException) {
						Console.Clear();
						dibujante.warning ("Error. Ocurrio un error al realizar la operación.");
						dibujante.dibujar();
						Console.WriteLine("Alguno de los datos que ingreso no tiene el formato correcto.");
						Console.WriteLine("Por favor, vuelva a intentarlo e ingrese los datos de forma correcta..");
					}
					Console.ReadKey();
					pantallaPrincipal();
					break;
                case "2":
					try {
						serviceCompra.eliminarProductoDelCarro();
					} catch (FormatException) {
						Console.Clear();
						dibujante.warning ("Error. Ocurrio un error al realizar la operación.");
						dibujante.dibujar();
						Console.WriteLine("Alguno de los datos que ingreso no tiene el formato correcto.");
						Console.WriteLine("Por favor, vuelva a intentarlo e ingrese los datos de forma correcta..");
					}
                    Console.ReadKey();
                    pantallaPrincipal();
                    break;
                case "3":
					try {
						serviceCompra.listarProductosDelCarro();
					} catch (FormatException) {
						Console.Clear();
						dibujante.warning ("Error. Ocurrio un error al realizar la operación.");
						dibujante.dibujar();
						Console.WriteLine("Alguno de los datos que ingreso no tiene el formato correcto.");
						Console.WriteLine("Por favor, vuelva a intentarlo e ingrese los datos de forma correcta..");
					}
                    Console.ReadKey();
                    pantallaPrincipal();
                    break;
                case "4":
                    Console.Clear();
                    return;
                default:
                    Console.Clear();
                    dibujante.warning("Opcion erronea, vuelva a elejir una opcion...");
                    Console.ReadKey();
                    Console.Clear();
                    pantallaPrincipal();
                    break;
            }
        }
    }
}
