using System;


namespace WebAPIZoologico.Models
{
	public class AnimalCarnivoro : Animal
	{
		public Alimento Alimento;
		public double Porcentaje { get; set; }

		public AnimalCarnivoro(string Especie, double Edad, string LugarOrigen, double Peso, double Porcentaje) : base(Especie, Edad, LugarOrigen, Peso)
		{
			this.Porcentaje = Porcentaje;
			var cantidiad = CalcularAlimento();
			Alimento = new Alimento("Carne", cantidiad);

		}

		public override double CalcularAlimento()
		{
			return (Porcentaje * Peso / 100)*30;
		}
	}
}
