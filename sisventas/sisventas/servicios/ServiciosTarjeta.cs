using System;
using System.Collections;

namespace SistemaVentas
{
    public class ServiciosTarjeta
    {
		public ArrayList tarjetasAlmacenados = new ArrayList();

		public ServiciosTarjeta()
        {
        }

		public void listarTarjetas(){
			if (this.tarjetasAlmacenados.Count == 0) {
				Console.WriteLine ("No hay tarjetas registradas. Presione una tecla para continuar..");
				return;
			}
			int i = 1;
			foreach (Tarjeta tarjeta in tarjetasAlmacenados)
			{
				Console.WriteLine(i.ToString() + ") " + tarjeta.InfoTarjeta);
				ArrayList formasPago = tarjeta.InfoFormasPago;
				foreach (var formaPago in formasPago)
				{
					Console.WriteLine("          " + formaPago);
				}
				i++;
			}
		}

		public void vistaIngresarBeneficio(){
			if (this.tarjetasAlmacenados.Count == 0) {
				Console.WriteLine ("No hay tarjetas registradas. Presione una tecla para continuar..");
				return;
			}
			listarTarjetas ();
			Console.WriteLine("Seleccione la tarjeta a la que desea agregar el beneficio: ");
			int tarjetaSeleccionada = Int32.Parse(Console.ReadLine());
			Console.WriteLine("Indique cantidad de cuotas:  ");
			int cantCuotas = Int32.Parse(Console.ReadLine());
			Console.WriteLine("Indique interes por cuota:  ");
			int interesCuota = Int32.Parse(Console.ReadLine());
			Tarjeta tarjetaElegida = (Tarjeta)this.tarjetasAlmacenados[tarjetaSeleccionada - 1];
			tarjetaElegida.ingresarBeneficio(cantCuotas, interesCuota);
			Console.WriteLine("Benificio Ingresado");
		}

		public void vistaAgregarTarjeta() {
			Console.WriteLine("Ingresar tarjeta");
			string nombreTarjeta = Console.ReadLine();
			Console.WriteLine("Ingrese banco");
			string bancoTarjeta = Console.ReadLine();
			Console.WriteLine("Ingrese cantidad de formas de pago");
			int cantFPagosTarjeta = Int32.Parse(Console.ReadLine());
			ArrayList formasDePagoTarjeta = new ArrayList();
			for (int a = 0; a < cantFPagosTarjeta; a++)
			{
				ArrayList item = new ArrayList();
				Console.WriteLine("Forma de pago #" + (a + 1).ToString());
				Console.WriteLine("Ingrese # de cuotas");
				int numCuotas = Int32.Parse(Console.ReadLine());
				Console.WriteLine("Ingrese interes por cuota");
				int intCuota = Int32.Parse(Console.ReadLine());
				item.Add(numCuotas);
				item.Add(intCuota);
				formasDePagoTarjeta.Add(item);
			}
			registrarTarjeta(nombreTarjeta, bancoTarjeta, cantFPagosTarjeta, formasDePagoTarjeta);
			Console.WriteLine("Tarjeta registrada correctamente");
		}

		public void registrarTarjeta(string nombre, string banco, int cantidadFormasPago, ArrayList formasPago)
		{
			Tarjeta tarjetaNueva = new Tarjeta(nombre, banco, cantidadFormasPago, 0, formasPago);
			tarjetasAlmacenados.Add(tarjetaNueva);
		}

		public double obtenerInteres(Tarjeta tarjeta, int cuotas)
        {
            double interes = 0;
            foreach (ArrayList formaPago in tarjeta.FormasPago)
            {
                if ((int)formaPago[0] == cuotas)
                {
                    interes = (int)formaPago[1];
                }
            }
            return interes;
        }

		public double calculoIntereses(double total, Tarjeta tarjeta, int cuotas)
		{
			double interesesTotal = 0;
			double interes = obtenerInteres(tarjeta, cuotas);
			interesesTotal = total + (total * (interes / 100));

			return interesesTotal;
		}


		public ArrayList ObtenerTarjetas
		{
			get
			{
				return tarjetasAlmacenados;
			}
		}
    }
}
