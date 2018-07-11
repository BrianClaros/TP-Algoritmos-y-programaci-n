using System;
using System.Collections;

namespace SistemaVentas
{
	public class ServiciosProducto
	{
		private Dibujante dibujante; 
		public ArrayList productosAlmacenados = new ArrayList ();

		public ServiciosProducto()
		{
			this.dibujante = new Dibujante();
			this.productosAlmacenados.Add(new Producto("Remera", "Adidas", "XL", 170));
			this.productosAlmacenados.Add(new Producto("Pantalon", "Adidas", "XL", 320));
			this.productosAlmacenados.Add(new Producto("Bufanda", "Bufanditas", "L", 120));
			this.productosAlmacenados.Add(new Producto("Pantalon", "Adidas", "XL", 320));
		}
      
		public void vistaAgregarProducto()
        {
            string tipo, marca, talle, precioString;
            Console.Clear();
            dibujante.cabezera("Modulo productos - Agregar producto");
            Producto modeloProducto;
            Console.Write("Ingrese el tipo del producto: ");
            tipo = Console.ReadLine();
            Console.Write("Ingrese la marca del producto: ");
            marca = Console.ReadLine();
            Console.Write("Ingrese el talle del producto: ");
            talle = Console.ReadLine();
            Console.Write("Ingrese precio del producto: ");
            precioString = Console.ReadLine();
            //TODO: agregar validacion
            if (tipo == "" || marca == "" || talle == "" || precioString == "")
            {
				throw new FormatException("Alguno de los datos que ingreso no tiene el formato correcto.");
            }
            double precio = Convert.ToDouble(precioString);
            modeloProducto = new Producto(tipo, marca, talle, precio);
            altaProducto(modeloProducto);
			Console.Write("Producto ingresado al registro.");
        }

		private void altaProducto(Producto producto) {
			this.productosAlmacenados.Add (producto);
		}

		public ArrayList ObtenerProductos
        {
            get
            {
                return this.productosAlmacenados;
            }
        }
	}
}

