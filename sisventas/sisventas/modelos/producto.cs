using System;

namespace SistemaVentas
{
	public class Producto
	{
		private String tipo, marca, talle;
		private int descuento;
		private double precio;

		public Producto (string tipo, string marca, string talle, double precio)
		{
			this.tipo = tipo;
			this.marca = marca;
			this.talle = talle;
			this.precio = precio;
			this.descuento = 0;
		}
      
		public String InfoProducto {
			get {
				return "[Producto Tipo=" + this.tipo + ", Marca=" + this.marca + ", Talle=" + this.talle + ", Precio=" + this.precio.ToString() + ", Descuento=" + this.descuento +"%]";	
			}
		}

		public double Precio
        {
            get
            {
				return this.precio;
            }
        }

		public int Descuento {
			get
            {
				return this.descuento;
            }
			set {
				this.descuento = value;
			}
		}
 	}
}

