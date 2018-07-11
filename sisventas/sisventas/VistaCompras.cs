using System;
using System.Collections;

namespace SistemaVentas
{
	public class VistaCompras
	{
		private string[] opciones;
        private Dibujante dibujante;
		private VistaGestionCarro vistaGestionCarro;
		private ServiciosCompra serviceCompra;
		private ServiciosCliente serviceCliente;

		public VistaCompras(Dibujante dibujante, VistaGestionCarro vistaGestionCarro, ServiciosCompra serviceCompra, ServiciosCliente serviceCliente) {
			this.vistaGestionCarro = vistaGestionCarro;
			this.serviceCompra = serviceCompra;
			this.serviceCliente = serviceCliente;
			this.dibujante = dibujante;
			this.opciones = new string[] { "1 - Agregar productos al carro" ,
				"2 - Identificar cliente",
				"3 - Volver"};
		}
			
		public void pantallaPrincipal() {
			Console.Clear();
            dibujante.cabezera("Modulo compŕas - Sistema de ventas Online");
            dibujante.cuerpo(opciones);
            dibujante.pie("Hola , que acción desea realizar?", "Teclee el número de opción: ");
            string opcion = Console.ReadLine();
            opcionSeleccionada(opcion);
		}

		public void opcionSeleccionada (string opcionElegida){
			switch (opcionElegida) {
			case "1":
				vistaGestionCarro.pantallaPrincipal();
                pantallaPrincipal();
                break;
			case "2":
				try {
					serviceCompra.identificarCliente(serviceCliente);
				} catch (Exception ex) {
					Console.Clear();
					dibujante.warning ("Error. Ocurrio un error al realizar la operación.");
					dibujante.dibujar();
					Console.WriteLine(ex.Message);
					Console.WriteLine("Por favor, vuelva a intentarlo e ingrese los datos de forma correcta..");
				}
				Console.ReadKey();
                pantallaPrincipal();
                break;
			case "3":
				Console.Clear ();
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

