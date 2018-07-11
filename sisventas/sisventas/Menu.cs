using System;
using System.Collections;

namespace SistemaVentas
{
	public class Menu
	{
		private string[] opciones;
		private static Dibujante dibujante = new Dibujante();
		private static ServiciosProducto serviceProducts = new ServiciosProducto();
		private static ServiciosPromociones servicePromociones = new ServiciosPromociones();
		private static ServiciosTarjeta serviceTarjeta = new ServiciosTarjeta();
		private static ServiciosCompra serviceCompra = new ServiciosCompra(serviceTarjeta);
		private static ServiciosCliente serviceCliente = new ServiciosCliente();
		private VistaProductos vistaProductos = new VistaProductos (dibujante, serviceProducts, servicePromociones);
		private static VistaGestionCarro vistaGestionCarro = new VistaGestionCarro(dibujante, serviceProducts, serviceCompra);
		private VistaCompras vistaCompras = new VistaCompras(dibujante, vistaGestionCarro, serviceCompra, serviceCliente);
		private VistaTarjetas vistaTarjetas = new VistaTarjetas(serviceTarjeta);
		private VistaAdministracion vistaAdministracion = new VistaAdministracion(serviceCompra, serviceCliente, serviceTarjeta);

		public Menu() {
			this.opciones = new string[] { "1 - Productos y promociones" ,
				"2 - Compras",
				"3 - Tarjetas de credito",
				"4 - Administración",
				"5 - Salir del sistema"};
		}
			
		public void pantallaPrincipal() {
			Console.Clear ();
			dibujante.cabezera("Sistema de ventas Online");
			dibujante.cuerpo (opciones);
			dibujante.pie("Hola , que acción desea realizar?", "Teclee el número de opción: ");
			string opcion = Console.ReadLine();
			opcionSeleccionada (opcion);
		}

		public void opcionSeleccionada (string opcionElegida){
			switch (opcionElegida) {
			case "1":
				vistaProductos.pantallaPrincipal ();
				pantallaPrincipal ();
				break;
			case "2":
				Console.Clear ();
				vistaCompras.pantallaPrincipal ();
				pantallaPrincipal();
				break;
			case "3":
				Console.Clear ();
				vistaTarjetas.pantallaPrincipal ();
				pantallaPrincipal();
				break;
			case "4":
				Console.Clear ();
				vistaAdministracion.pantallaPrincipal ();
				pantallaPrincipal();
				break;
			case "5":
				Console.WriteLine ("Presione una tecla para finalizar el programa");
				return;
			default:
				Console.Clear ();
				dibujante.warning ("Opcion erronea, vuelva a elejir una opcion...");
				Console.ReadKey ();
				Console.Clear ();
				pantallaPrincipal ();
				break;
			}
		}
	}
}

