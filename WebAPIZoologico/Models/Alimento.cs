using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIZoologico.Models
{
	public class Alimento
	{
		public string Nombre { get; set; }
		public double Cantidad { get; set; }

		public Alimento(string Nombre, double Cantidad)
		{
			this.Nombre = Nombre;
			this.Cantidad = Cantidad;
		}
	}
}
