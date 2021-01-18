using System;

namespace WebAPIZoologico.Models
{
	public class AnimalReptil : Animal {
		public Alimento Carnes { get; set; }
		public Alimento Hierbas { get; set; }
		public double DiasCambioPiel { get; set; }
		public double Porcentaje { get; set; }

		public AnimalReptil(string Especie, double Edad, string LugarOrigen, double Peso, double DiasCambioPiel, double Porcentaje) : base(Especie, Edad, LugarOrigen, Peso)
		{
			this.Porcentaje = Porcentaje;
			this.DiasCambioPiel = DiasCambioPiel;
			var cantidadTotal = CalcularAlimento();
			var cantidadCarnes = cantidadTotal / 2;
			var cantidadHierbas = cantidadTotal / 2;
			Carnes = new Alimento("Carnes", cantidadCarnes);
			Hierbas = new Alimento("Hierbas", cantidadHierbas);
			//Como no se especifica una dieta para los reptiles decidi hacer que del total
			//que comen, la mitad es carne y la otra mitad es hierbas
		}

		public override double CalcularAlimento()
		{
			var FragmentosMes = Math.Truncate(30 / (DiasCambioPiel + 3));
			var DiasRestantes = (DiasCambioPiel + 3) * FragmentosMes;
			var CantidadDiasQueCome = FragmentosMes * DiasCambioPiel + DiasRestantes;

			var ComidaTotalComidaDia = (Porcentaje * Peso / 100)/7;

			var CantidadComidaTotalAlMes = CantidadDiasQueCome * ComidaTotalComidaDia;

			return Math.Round(CantidadComidaTotalAlMes,2);
		}

	}
}
