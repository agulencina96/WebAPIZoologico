using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIZoologico.DOTs;
using WebAPIZoologico.Models;

namespace WebAPIZoologico.Repositorio
{
	public class Mocks
	{
		public static Mocks instancia;
		public List<AnimalDTO> Animales = new List<AnimalDTO>();
		public Mocks()
		{
			Animales.Add(new AnimalDTO("Carnivoro","Lobo", 5, "Tucuman", 80,240, 10));
			Animales.Add(new AnimalDTO("Carnivoro","Lobo", 2, "Tucuman", 40, 120, 10));
			Animales.Add(new AnimalDTO("Carnivoro", "Lobo", 1, "Tucuman", 30, 90, 10));
			Animales.Add(new AnimalDTO("Herbivoro", "Tortuga", 5, "Tucuman", 80, 5700, fijo: 30));
			Animales.Add(new AnimalDTO("Herbivoro",  "Tortuga", 2, "Tucuman", 40, 3000, fijo: 20));
			Animales.Add(new AnimalDTO("Herbivoro", "Tortuga", 1, "Tucuman", 30, 3000, fijo: 40));
			Animales.Add(new AnimalDTO("Reptil","Lagarto", 5, "Tucuman", 100, 64.29, 10, dias:6));
			Animales.Add(new AnimalDTO("Reptil", "Lagarto", 5, "Tucuman", 120, 65.14, 10, dias: 8));
			Animales.Add(new AnimalDTO("Reptil", "Lagarto", 5, "Tucuman", 90, 59.14, 10, dias: 10));
		}
		public static Mocks ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new Mocks();
			}
			return instancia;
		}

		public List<AnimalDTO> ObtenerAnimales()
		{
			return Animales;
		}

		public void AgregarAnimalHerbivoro(AnimalHerbivoro animal)
		{
			AnimalDTO animalDTO = new AnimalDTO("Herbivoro",animal.Especie,animal.Edad,animal.LugarOrigen,animal.Peso,animal.CalcularAlimento(),fijo:animal.Fijo);
			Animales.Add(animalDTO);
			ObtenerAnimales();
		}

		public void AgregarAnimalCarnivoro(AnimalCarnivoro animal)
		{
			AnimalDTO animalDTO = new AnimalDTO("Carnivoro", animal.Especie, animal.Edad, animal.LugarOrigen, animal.Peso, animal.CalcularAlimento(), animal.Porcentaje);
			Animales.Add(animalDTO);
			ObtenerAnimales();
		}

		public void AgregarAnimalReptil(AnimalReptil animal)
		{
			AnimalDTO animalDTO = new AnimalDTO("Reptil", animal.Especie, animal.Edad, animal.LugarOrigen, animal.Peso, animal.CalcularAlimento(), animal.Porcentaje, animal.DiasCambioPiel);
			Animales.Add(animalDTO);
			ObtenerAnimales();
		}

	}

}
