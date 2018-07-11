using System;
using System.Collections;

namespace SistemaVentas
{
	public class VistaTarjetas
	{
		private string[] opciones;
		private Dibujante dibujante;
		private ServiciosTarjeta serviceTarjeta;

		public VistaTarjetas(ServiciosTarjeta serviceTarjeta)
		{
			this.dibujante = new Dibujante();
			this.serviceTarjeta = serviceTarjeta;
			this.opciones = new string[] { "1 - Agregar tarjeta" ,
				"2 - Agregar beneficio",
				"3 - Listar tarjetas",
				"4 - Listar tarjetas con beneficio",
				"5 - Volver"};
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
				Console.Clear ();
				dibujante.cabezera ("Modulo tarjetas - Ingresar tarjeta");
				try {
					serviceTarjeta.vistaAgregarTarjeta();
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
				Console.Clear();
				dibujante.cabezera("Modulo tarjetas - Ingresar beneficio");
				try {
					serviceTarjeta.vistaIngresarBeneficio();
				} catch (FormatException) {
					Console.Clear();
					dibujante.warning ("Error. Ocurrio un error al realizar la operación.");
					dibujante.dibujar();
					Console.WriteLine("Por favor, vuelva a intentarlo e ingrese los datos de forma correcta..");
				}
				Console.ReadKey();
                pantallaPrincipal();
				break;
			case "3":
				Console.Clear ();
				dibujante.cabezera ("Modulo tarjetas - Listado de tarjetas");
				serviceTarjeta.listarTarjetas ();
				Console.ReadKey();
                pantallaPrincipal();
                break;
			case "4":
				Console.Clear();
                dibujante.cabezera("Modulo tarjetas - Listado de tarjetas con beneficios");
                ArrayList tarjetas = serviceTarjeta.ObtenerTarjetas;
				if (tarjetas.Count == 0) {
					dibujante.dibujar ();
					Console.WriteLine ("No hay tarjetas registradas. Presione una tecla para continuar..");
				}
                int i = 1;
				foreach (Tarjeta tarjeta in tarjetas)
                {
					if (tarjeta.tarjetaConBeneficio == true) {
						Console.WriteLine(i.ToString() + ") " + tarjeta.InfoTarjeta);
						ArrayList formasPago = tarjeta.InfoFormasPago;
						foreach (var formaPago in formasPago)
						{
							Console.WriteLine("          " + formaPago);
						}
						i++;
					}
                }
				if(i == 1) {
					Console.WriteLine("No hay tarjetas con beneficios.");
				}
                Console.ReadKey();
                pantallaPrincipal();
                break;
			case "5":
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

