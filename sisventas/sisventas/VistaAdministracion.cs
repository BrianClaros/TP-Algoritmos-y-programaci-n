using System;
using System.Collections;

namespace SistemaVentas
{
	public class VistaAdministracion
	{
		private string[] opciones;
		private Dibujante dibujante;
		private ServiciosCompra serviceCompra;
		private ServiciosCliente serviceCliente;
		private ServiciosTarjeta serviceTarjeta;

		public VistaAdministracion(ServiciosCompra serviceCompra, ServiciosCliente serviceCliente, ServiciosTarjeta serviceTarjeta)
		{
			this.serviceCliente = serviceCliente;
			this.serviceCompra = serviceCompra;
			this.serviceTarjeta = serviceTarjeta;
			this.dibujante = new Dibujante();
			this.opciones = new string[] { "1 - Total vendido en la tienda On-line" ,
				"2 - Total vendido por cliente",
				"3 - Total vendido por tarjeta",
				"4 - Volver"};
		}

		public void pantallaPrincipal()
		{
			Console.Clear();
			dibujante.cabezera("Pantalla principal");
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
				Console.Clear();
				dibujante.cabezera("Administracion - Total vendido en la tienda On-line");
				double totalCompras = serviceCompra.ComprasTotales;
				Console.WriteLine("Total vendido en la tienda es de: $" + totalCompras.ToString());
				Console.ReadKey();
                pantallaPrincipal();
				break;
			case "2":
				Console.Clear ();
				dibujante.cabezera ("Administracion - Total vendido por cliente");
				ArrayList Clientes = serviceCliente.ObtenerClientes;
				if (Clientes.Count == 0) {
					Console.WriteLine ("No hay clientes registrados. Presione una tecla para continuar..");
				} else {
					foreach (Cliente Cliente in Clientes)
					{
						Console.WriteLine(Cliente.InfoCliente);
					}
				}
				Console.ReadKey();
                pantallaPrincipal();
				break;
			case "3":
				Console.Clear ();
				dibujante.cabezera ("Administracion - Total vendido por tarjeta");
				ArrayList registroTarjetas = serviceTarjeta.ObtenerTarjetas;
				if (registroTarjetas.Count == 0) {
					Console.WriteLine ("No hay tarjetas registradas. Presione una tecla para continuar..");
				} else {
					foreach (Tarjeta tarjeta in registroTarjetas)
					{
						Console.WriteLine(tarjeta.InfoTarjeta);
					}
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

