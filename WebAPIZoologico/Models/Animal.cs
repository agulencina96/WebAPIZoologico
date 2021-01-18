using System;

namespace WebAPIZoologico.Models
{
	public abstract class Animal
	{
		public DateTime FechaIngreso { get; set; }
		public string Especie { get; set; }
		public double Edad { get; set; }
		public string LugarOrigen { get; set; }
		public double Peso { get; set; }
		public Animal(string Especie, double Edad, string LugarOrigen, double Peso)
		{
			this.Especie = Especie;
			this.Edad = Edad;
			this.LugarOrigen = LugarOrigen;
			this.Peso = Peso;
			this.FechaIngreso = DateTime.Now;
		}

		public abstract double CalcularAlimento();
	}


}
