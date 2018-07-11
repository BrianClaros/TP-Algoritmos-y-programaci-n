using System;
using System.Collections;

namespace SistemaVentas
{
	public class ServiciosCompra
	{
		private Dibujante dibujante = new Dibujante();
		private ArrayList carroDeCompras = new ArrayList();
		private double TotalComprado = 0;
		private ServiciosTarjeta serviceTarjeta;

		public ServiciosCompra(ServiciosTarjeta serviceTarjeta)
        {
			this.serviceTarjeta = serviceTarjeta;
        }

		public void agregarProductoAlCarro (ServiciosProducto serviceProducts) {
			Console.Clear();
            dibujante.cabezera("Sistema de ventas Online - Agregar productos al carro");
			ArrayList productos = serviceProducts.ObtenerProductos;
            int i = 1;
            foreach (Producto producto in productos)
            {
                Console.WriteLine(i.ToString() + ") " + producto.InfoProducto);
                i++;
            }
            Console.WriteLine("Ingrese que producto desea añadir al carro de compras");
            string stringProductoSeleccionado = Console.ReadLine();
			Console.WriteLine("Ingrese la cantidad que desea comprar");
			int cantidadAComprar = Int32.Parse(Console.ReadLine());
            int intProductoSeleccionado = Int32.Parse(stringProductoSeleccionado);
            Producto productoSeleccionado = (Producto)productos[intProductoSeleccionado - 1];
			ArrayList itemNuevo = new ArrayList();
			itemNuevo.Add(productoSeleccionado);
			itemNuevo.Add(cantidadAComprar);
			carroDeCompras.Add(itemNuevo);
			Console.WriteLine("Producto añadido al carro de compras");
		}

		public void eliminarProductoDelCarro () {
			Console.Clear();
            dibujante.cabezera("Sistema de ventas Online - Eliminar productos del carro");
			if (this.carroDeCompras.Count == 0) {
				dibujante.dibujar ();
				Console.WriteLine ("No tiene productos en el carro. Presione una tecla para continuar..");
				return;
			}
            int i = 1;
			foreach (ArrayList item in this.carroDeCompras)
            {
				Producto productoo = (Producto)item[0];
				int cantidadProductoo = (int)item[1];
				Console.WriteLine(i.ToString() + ") " + "Cantidad:" + cantidadProductoo.ToString() + productoo.InfoProducto);
                i++;
            }
            Console.WriteLine("Ingrese que producto desea quitar del carro de compras");
			int numeroItemSeleccionado = Int32.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese la cantidad de productos que desea eliminar:");
            int cantidadAEliminar = Int32.Parse(Console.ReadLine());

			ArrayList itemSeleccionado = (ArrayList)this.carroDeCompras[numeroItemSeleccionado - 1];

			Producto producto = (Producto)itemSeleccionado[0];
			int cantidadProducto = (int)itemSeleccionado[1];

			if (cantidadProducto == cantidadAEliminar){
				carroDeCompras.RemoveAt(numeroItemSeleccionado - 1);
			} else {
				cantidadProducto = cantidadProducto - cantidadAEliminar;
				ArrayList nuevoItem = new ArrayList();
				nuevoItem.Add(producto);
				nuevoItem.Add(cantidadProducto);
				carroDeCompras.RemoveAt(numeroItemSeleccionado - 1);
				carroDeCompras.Add(nuevoItem);
			}
		}

		public double calcularTotalCarro()
		{ 
			double totalCarro = 0;
            foreach (ArrayList item in carroDeCompras)
            {
                Producto itemProducto = (Producto)item[0];
                int cantidadProducto = (int)item[1];
				double precioProductoDescuento = itemProducto.Precio - (itemProducto.Precio * (itemProducto.Descuento/100));
				totalCarro = totalCarro + (precioProductoDescuento * cantidadProducto);
            }
			return totalCarro;
		}

		public void listarProductosDelCarro () {
			Console.Clear();
            dibujante.cabezera("Sistema de ventas Online - Listar productos del carro");
			if (this.carroDeCompras.Count == 0) {
				dibujante.dibujar ();
				Console.WriteLine ("No tiene productos en el carro. Presione una tecla para continuar..");
				return;
			}
			double totalCarro = calcularTotalCarro();
			foreach (ArrayList item in carroDeCompras)
			{
				Producto itemProducto = (Producto)item[0];
				int cantidadProducto = (int)item[1];
				Console.WriteLine("Cantidad:" + cantidadProducto.ToString() + itemProducto.InfoProducto);
			}
			Console.WriteLine("Total de compra : $" + totalCarro.ToString());
		}

		public double ComprasTotales {
			get
			{
				return this.TotalComprado;
			}
		}

		public void identificarCliente(ServiciosCliente serviceCliente) {
			Console.WriteLine("Ingrese su numero de dni: ");
            string stringDni = Console.ReadLine();
			int intDni = Int32.Parse(stringDni);
			ArrayList Clientes = serviceCliente.ObtenerClientes;
			Cliente clienteExistente = null;
			bool clienteExiste = false;
			foreach (Cliente cliente in Clientes)
			{
				if (cliente.DNI == intDni)
				{
					clienteExiste = true;
					clienteExistente = cliente;
				}
			}

			if (clienteExiste && clienteExistente != null) {
				Console.WriteLine("Cliente existe");
				Console.WriteLine(clienteExistente.InfoCliente);
				Comprar(clienteExistente);
			} else {
				Console.WriteLine("Nuevo cliente, ingrese sus datos: ");
				Cliente clienteNuevo = serviceCliente.registrarCliente(intDni);
				Console.WriteLine("Cliente registrado. Presione una tecla para seguir..");
				Console.ReadKey ();
				Comprar(clienteNuevo);
			}
		}

		private void Comprar(Cliente cliente)
		{
            // selecccionarTarjeta
            ArrayList tarjetas = serviceTarjeta.ObtenerTarjetas;
			if (tarjetas.Count == 0) {
				Console.Clear();
				Console.WriteLine("No hay tarjetas registradas para poder abonar. Espere que seran cargadas.");
				Console.ReadKey ();
				return;
			}
            int i = 1;
            foreach (Tarjeta tarjetaa in tarjetas)
            {
                Console.WriteLine(i.ToString() + ") " + tarjetaa.InfoTarjeta);
				ArrayList formasPago = tarjetaa.InfoFormasPago;
                foreach (var formaPago in formasPago)
                {
                    Console.WriteLine("          " + formaPago);
                }
                i++;
            }
			Console.WriteLine("Seleccione la tarjeta para abonar: ");
            int tarjetaSeleccionada = Int32.Parse(Console.ReadLine());
			Tarjeta tarjetaSeleccionadaPago = (Tarjeta)tarjetas[tarjetaSeleccionada - 1];
			// seleccionarCuotas
            Console.WriteLine("Indique cantidad de cuotas:  ");
            int cantCuotas = Int32.Parse(Console.ReadLine());
			// confirmacion
			double TotalEnCarro = calcularTotalCarro();
			double interes = serviceTarjeta.obtenerInteres(tarjetaSeleccionadaPago, cantCuotas);
			Console.WriteLine("En " + cantCuotas.ToString() + " cuotas tiene un interes de " + interes.ToString() + "%");
			Console.WriteLine("En el carro hay un total de " + TotalEnCarro.ToString());
			double TotalFinanciado = serviceTarjeta.calculoIntereses(TotalEnCarro ,tarjetaSeleccionadaPago, cantCuotas);
			Console.WriteLine("Precio total financiado:" + TotalFinanciado.ToString() + "  en " + cantCuotas.ToString() + " cuotas de " + (TotalFinanciado/cantCuotas));
			Console.WriteLine("Confirma la compra? (S/N)");
			string confirmacion = Console.ReadLine();
			if(confirmacion == "n" || confirmacion == "N"){
				Console.WriteLine("Compra cancelada");
				return;
			}
			// actualizarGastosCliente
			cliente.TotalGastado = TotalFinanciado;
			// actualizarTotalComprado
			this.TotalComprado = this.TotalComprado + TotalFinanciado;
			// actualizar Compra con tarjeta
			tarjetaSeleccionadaPago.TotalCompras = TotalFinanciado;
			// vaciarCarrito
			carroDeCompras = new ArrayList();
			Console.WriteLine("Felicidades por su compra, carro vacio!");
		}
    }
}
