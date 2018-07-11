using System;
using System.Collections;

namespace SistemaVentas
{
	public class VistaProductos
	{
		private string[] opciones;
		private Dibujante dibujante;
		private ServiciosProducto serviceProducts;
		private ServiciosPromociones servicePromociones;

		public VistaProductos(Dibujante dibujante, ServiciosProducto serviceProducts, ServiciosPromociones servicePromociones) {
			this.dibujante = dibujante;
			this.serviceProducts = serviceProducts;
			this.servicePromociones = servicePromociones;
			this.opciones = new string[] { "1 - Dar de alta productos" ,
				"2 - Dar de alta promociones",
				"3 - Listar Productos",
				"4 - Listar Promociones",
				"5 - Volver"};
		}
			
		public void pantallaPrincipal() {
			Console.Clear ();
			dibujante.cabezera("Modulo productos - Sistema de ventas Online");
			dibujante.cuerpo (opciones);
			dibujante.pie("Hola , que acción desea realizar?", "Teclee el número de opción: ");
			string opcion = Console.ReadLine();
			opcionSeleccionada (opcion);
		}

		public void opcionSeleccionada (string opcionElegida){
			switch (opcionElegida) {
			case "1":
				try {
					serviceProducts.vistaAgregarProducto ();
				} catch (Exception ex) {
					Console.Clear();
					dibujante.warning ("Error. Ocurrio un error al realizar la operación.");
					dibujante.dibujar();
					Console.WriteLine(ex);
					Console.WriteLine(ex.Message);
					Console.WriteLine("Por favor, vuelva a intentarlo e ingrese los datos de forma correcta..");
				}
				Console.ReadKey();
				pantallaPrincipal ();
				break;
			case "2":
				Console.Clear ();
				try {
					servicePromociones.registrarPromocion(serviceProducts);
				} catch (FormatException) {
					Console.Clear();
					dibujante.warning ("Error. Ocurrio un error al realizar la operación.");
					dibujante.dibujar();
					Console.WriteLine ("Alguno de los datos que ingreso no tiene el formato correcto.");
				}
				Console.ReadKey();
				pantallaPrincipal ();
				break;
			case "3":
				Console.Clear ();
				ArrayList productos = serviceProducts.ObtenerProductos;
				dibujante.cabezera ("Lista de productos - Modulo productos");
				if (productos.Count == 0) {
					Console.WriteLine ("No hay productos para mostrar.");
				} else {
					int i = 1;
					foreach (Producto produc in productos) {
						Console.WriteLine(i.ToString() + ") " + produc.InfoProducto);
						i++;
					}
				}
				Console.ReadKey ();
				pantallaPrincipal ();
				break;
			case "4":
				Console.Clear();
				dibujante.cabezera("Lista de promociones - Modulo productos");
                servicePromociones.mostrarPromociones(serviceProducts);
				Console.ReadKey();
                pantallaPrincipal();
                break;
			case "5":
				Console.Clear ();
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

