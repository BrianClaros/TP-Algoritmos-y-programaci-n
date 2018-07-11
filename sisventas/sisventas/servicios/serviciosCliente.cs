using System;
using System.Collections;

namespace SistemaVentas
{
    public class ServiciosCliente
    {
		public ArrayList clientesRegistrados = new ArrayList();

        public ServiciosCliente()
        {
        }

		public Cliente registrarCliente(int dni)
		{
			Console.WriteLine("Ingrese Nombre: ");
			string nombre = Console.ReadLine();
			Console.WriteLine("Ingrese apellido: ");
            string apellido = Console.ReadLine();
			Console.WriteLine("Ingrese fecha de nacimiento: (dia/mes/año)");
            string fecha_de_nacimiento = Console.ReadLine();
			Cliente nuevoCliente = new Cliente(nombre, apellido, fecha_de_nacimiento, dni, 0);
			altaCliente(nuevoCliente);
			return nuevoCliente;
		}

		private void altaCliente(Cliente nuevoCliente)
        {
			this.clientesRegistrados.Add(nuevoCliente);
        }

		public ArrayList ObtenerClientes
        {
            get
            {
				return this.clientesRegistrados;
            }
        }
    }
}
