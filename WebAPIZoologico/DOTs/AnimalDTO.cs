

namespace WebAPIZoologico.DOTs
{
	public class AnimalDTO
	{
		public AnimalDTO(string tipo, string especie, double edad, string lugarOrigen, double peso, double cantidadComida, double porcentaje=0, double fijo=0,double dias=0)
		{
			this.tipo = tipo;
			this.especie = especie;
			this.edad = edad;
			this.lugarOrigen = lugarOrigen;
			this.peso = peso;
			this.porcentaje = porcentaje;
			this.fijo = fijo;
			this.dias = dias;
			this.cantidadComida = cantidadComida;

		}
		public string tipo { get; set; }
		public string especie { get; set; }
		public double edad { get; set; }
		public string lugarOrigen { get; set; }
		public double peso { get; set; }
		public double porcentaje { get; set; }
		public double fijo { get; set; }
		public double dias { get; set; }
		public double cantidadComida { get; set; }
	}
}
