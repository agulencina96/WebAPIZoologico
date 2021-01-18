using System;

namespace WebAPIZoologico.Models
{
	public class AnimalHerbivoro : Animal
	{
		public Alimento Alimento { get; set; }
		public double Fijo { get; set; }
		public AnimalHerbivoro(double Fijo, string Especie, double Edad, string LugarOrigen, double Peso) : base(Especie, Edad, LugarOrigen, Peso)
		{
			this.Fijo = Fijo;
			var cantidad = 2 * Peso + Fijo;
			Alimento = new Alimento("Hierbas", cantidad);
		}

		public override double CalcularAlimento()
		{
			return ((2 * Peso )+ Fijo)*30;
		}
	}
}
