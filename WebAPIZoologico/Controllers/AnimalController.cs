using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPIZoologico.DOTs;
using WebAPIZoologico.Models;
using WebAPIZoologico.Repositorio;

namespace WebAPIZoologico.Controllers
{
	[ApiController]
	public class AnimalController : ControllerBase
	{
		public Mocks mocks;
		public AnimalController()
		{
			mocks =Mocks.ObtenerInstancia();
			//Esto lo hice con la finalidad de mantener en memoria la lista de animales una sola vez
		}


		[HttpGet]
		[Route("animales")]
		public List<AnimalDTO> ObtenerAnimales()
		{
			return mocks.ObtenerAnimales();
		}

		[HttpGet]
		[Route("animales/carnes")]
		public double ObtenerTotalDeCarnes()
		{
			var carnesTotales = 0D;
			var animales = mocks.ObtenerAnimales();
			foreach (var animal in animales)
			{
				if (animal.tipo == "Carnivoro")
				{
					carnesTotales += animal.cantidadComida;
				}
				if (animal.tipo == "Reptil")
				{
					carnesTotales += animal.cantidadComida / 2;
				}
			}
			return carnesTotales;
		}

		[HttpGet]
		[Route("animales/hierbas")]
		public double ObtenerTotalDeHierbas()
		{
			var hierbasTotales = 0D;
			var animales = mocks.ObtenerAnimales();
			foreach (var animal in animales)
			{
				if (animal.tipo == "Herbivoro")
				{
					hierbasTotales += animal.cantidadComida;
				}
				if (animal.tipo == "Reptil")
				{
					hierbasTotales += animal.cantidadComida/2;
				}
			}
			return hierbasTotales;
		}


		[HttpPost]
		[Route("animal")]
		public List<AnimalDTO> CrearAnimal(AnimalDTO animal)
		{
			if (animal.tipo == "Herbivoro")
			{
				var nuevoAnimal = new AnimalHerbivoro(animal.fijo, animal.especie, animal.edad, animal.lugarOrigen, animal.peso);
				mocks.AgregarAnimalHerbivoro(nuevoAnimal);
			}
			if (animal.tipo == "Carnivoro")
			{
				var nuevoAnimal = new AnimalCarnivoro(animal.especie, animal.edad, animal.lugarOrigen, animal.peso, animal.porcentaje);
				mocks.AgregarAnimalCarnivoro(nuevoAnimal);
			}
			if (animal.tipo == "Reptil")
			{
				var nuevoAnimal = new AnimalReptil(animal.especie, animal.edad, animal.lugarOrigen, animal.peso, animal.dias, animal.porcentaje);
				mocks.AgregarAnimalReptil(nuevoAnimal);
			}
			return mocks.ObtenerAnimales();
		}
	}
}
