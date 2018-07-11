using System;
using System.Collections;

namespace SistemaVentas
{
	public class Dibujante
	{
		public Dibujante ()
		{
			Console.Title = "Sistema de ventas";
		}

		public void warning(string mensaje) {
			Console.BackgroundColor = ConsoleColor.Red;
			Console.ForegroundColor = ConsoleColor.White;
			dibujar ();
			dibujar (mensaje, 1);
			dibujar ();
			Console.ResetColor();
		}

		public void cabezera(string titulo) {
			dibujar ();
			dibujar (titulo, 1);
			dibujar ();
		}

		public void cuerpo(IEnumerable opciones) {
			dibujar (" ", 1);
			dibujar (" ", 1);
			dibujaritemmenu (opciones, 1);
			dibujar (" ", 1);
			dibujar (" ", 1);
			dibujar (" ", 1);
			dibujar (" ", 1);
			dibujar (" ", 1);
			dibujar ();
		}
		public void pie(string titulo, string mensaje){
			dibujar (" ", 0);
			dibujar ();
			dibujar (titulo, 1);
			dibujar ();
			Console.Write (mensaje);
		}

		public void dibujar(){
			int origWidth = Console.WindowWidth;
			string cadena = "";
			for (int i = 0; i < origWidth; i++) {
				cadena = cadena + "*";
			}
			Console.WriteLine (cadena);
		}

		public void dibujar(string texto, int asteriscos){
			/*asteriscos en cada lado*/
			int origWidth = Console.WindowWidth;
			string cadena = "";
			int queda = ((origWidth - (asteriscos * 2)) - texto.Length);
			int centro = queda / 2;

			for (int i = 0; i < asteriscos; i++) {
				cadena = cadena + "*";
			}

			for (int i = 0; i < queda; i++) {
				cadena = cadena + " ";
				if (i == centro) {
					cadena = cadena + texto;
				}
			}

			for (int i = 0; i < asteriscos; i++) {
				cadena = cadena + "*";
			}
			Console.WriteLine (cadena);
		}

		public void dibujaritemmenu(IEnumerable opciones, int asteriscos){
			int origWidth = Console.WindowWidth;

			string cadena = "";
			int ancho = origWidth - (asteriscos * 2);
			foreach (string item in opciones) {
				cadena = "";
				for (int i = 0; i < asteriscos; i++) {
					cadena = cadena + "*";
				}
				int queda = ancho - item.Length - 4;

				cadena = cadena + "    ";
				cadena = cadena + item;

				for (int i = 0; i < queda; i++) {
					cadena = cadena + " ";
				}

				for (int i = 0; i < asteriscos; i++) {
					cadena = cadena + "*";
				}
				Console.WriteLine (cadena);
			}
		}
	}
}

