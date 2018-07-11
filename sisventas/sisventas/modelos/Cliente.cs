using System;
namespace SistemaVentas
{
    public class Cliente
	{
		private String nombre, apellido, nacimiento;
        private int dni;
        private double TtlGastado;

		public Cliente(String nombre, String apellido, String nacimiento, int dni, double TtlGastado)
        {
			this.nombre = nombre;
			this.apellido = apellido;
			this.nacimiento = nacimiento;
			this.dni = dni;
			this.TtlGastado = TtlGastado;
        }

		public String InfoCliente
        {
            get
            {
				return "[Cliente Nombre=" + this.nombre + ", Apellido=" + this.apellido + ", Nacimiento=" + this.nacimiento + ", DNI=" + this.dni.ToString() + ", TtlGastado=" + this.TtlGastado.ToString() + "]";
            }
        }

		public int DNI {
			get {
				return this.dni;
			}
		}

		public double TotalGastado
        {
            set
            {
				this.TtlGastado = TtlGastado + value;
            }
        }
    }
}
