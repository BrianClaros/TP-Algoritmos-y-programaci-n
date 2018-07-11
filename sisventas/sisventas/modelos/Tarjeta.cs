using System;
using System.Collections;

namespace SistemaVentas
{
    public class Tarjeta
    {
		private String nombre, banco;
		private int cantidadFormasPago;
		private double totalCompras;

		// formato [[cuota,interes],[cuota,interes]]
		private ArrayList formasPago = new ArrayList();
		public bool tarjetaConBeneficio = false;

		public Tarjeta(string nombre, string banco, int cantidadFormasPago, double totalCompras, ArrayList formasPago)
        {
			this.nombre = nombre;
			this.banco = banco;
			this.cantidadFormasPago = cantidadFormasPago;
			this.totalCompras = totalCompras;
			this.formasPago = formasPago;
        }

		public void ingresarBeneficio(int cuota, int interes)
		{
			foreach (ArrayList formaPago in formasPago)
			{
				if((int)formaPago[0] == cuota)
				{
					formaPago[1] = interes;
					this.tarjetaConBeneficio = true;
				}
			}
		}

		private ArrayList armarInfoFormaPago()
		{
			ArrayList arrayFormaPago = new ArrayList();
			foreach (ArrayList formaPago in formasPago)
			{
				arrayFormaPago.Add(formaPago[0] + " cuotas con " + formaPago[1] + "% de interes");
			}
			return arrayFormaPago;
		}

		public ArrayList InfoFormasPago
		{
			get
			{
				return armarInfoFormaPago();
			}
		}

		public ArrayList FormasPago
        {
            get
            {
				return this.formasPago;
            }
        }

		public double TotalCompras
        {
            set
            {
				this.totalCompras = this.totalCompras + value;
            }
        }

		public String InfoTarjeta
        {
            get
			{
				return "[Tarjeta Nombre=" + this.nombre + " , Banco=" + this.banco + " , Formas de pago=" + this.cantidadFormasPago.ToString() + ", Total Compras=" + this.totalCompras + "]";
            }
        }
    }
}
