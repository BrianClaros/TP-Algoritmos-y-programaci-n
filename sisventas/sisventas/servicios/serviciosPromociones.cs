using System;
using System.Collections;

namespace SistemaVentas
{
    public class ServiciosPromociones
    {
		private Dibujante dibujante = new Dibujante(); 

		public void altaPromocion (ArrayList productos, string stringNumeroProducto, string stringDescuento) {
			int intNumeroProducto = Int32.Parse(stringNumeroProducto);
            int intDescuento = Int32.Parse(stringDescuento);
            Producto productoSeleccionado = (Producto)productos[intNumeroProducto - 1];
            productoSeleccionado.Descuento = intDescuento;
		}

		public void mostrarPromociones(ServiciosProducto serviceProducts) {
			ArrayList productos = serviceProducts.ObtenerProductos;
			int i = 1;
            foreach (Producto producto in productos)
            {
				if (producto.Descuento != 0 ) {
					Console.WriteLine(i.ToString() + ") " + producto.InfoProducto);
                    i++;
				}
            }
		}

		public void registrarPromocion (ServiciosProducto serviceProducts) {
			Console.Clear();
            dibujante.cabezera("Modulo productos - Agregar promocion");
			ArrayList productos = serviceProducts.ObtenerProductos;
			int i = 1;
			foreach (Producto producto in productos) {
				Console.WriteLine(i.ToString() + ") " + producto.InfoProducto);
                i++;
			}
			vistaPromocion(productos);
		}

		public void vistaPromocion (ArrayList productos) {
			Console.WriteLine("Ingrese el numero del producto que desea aplicar el descuento");
			string stringNumeroProducto = Console.ReadLine();
			Console.WriteLine("Ingrese el porcentaje de promocion que desea aplicar al producto");
			string stringDescuento = Console.ReadLine();
			altaPromocion(productos, stringNumeroProducto, stringDescuento);
		}
    }
}
