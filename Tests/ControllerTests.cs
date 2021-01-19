using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIZoologico.Controllers;
using WebAPIZoologico.DOTs;

namespace Tests
{
	public class ControllerTests
	{
		AnimalController controller;
		List<AnimalDTO> Animales;
		[SetUp]
		public void Setup()
		{
			Animales = new List<AnimalDTO>();
			controller = new AnimalController();
			if(Animales.Count !=0)Animales.Clear();
			Animales.AddRange(GenerarListaAnimales());
		}

		[Test]
		public void ObtenerAnimales()
		{
			var testAnimales = GenerarListaAnimales();
			var result = controller.ObtenerAnimales();
			Assert.AreEqual(result.Count, testAnimales.Count);
		}

		[Test]
		public void CalcularCantidadTotalCarne()
		{
			var carnesTotales = 0D;
			foreach (var animal in Animales)
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
			var result = controller.ObtenerTotalDeCarnes();
			Assert.AreEqual(result, carnesTotales);

		}

		[Test]
		public void CalcularCantidadTotalHierbas()
		{
			var hierbasTotales = 0D;
			foreach (var animal in Animales)
			{
				if (animal.tipo == "Herbivoro")
				{
					hierbasTotales += animal.cantidadComida;
				}
				if (animal.tipo == "Reptil")
				{
					hierbasTotales += animal.cantidadComida / 2;
				}
			}
			var result = controller.ObtenerTotalDeHierbas();
			Assert.AreEqual(result, hierbasTotales);

		}

		[Test]
		public void AgregarNuevoAnimal()
		{
			Animales.Add(new AnimalDTO("Carnivoro", "Lobo", 15, "Tucuman", 180, 1080, 20));
			var result = controller.CrearAnimal(new AnimalDTO("Carnivoro", "Lobo", 15, "Tucuman", 180, 1080, 20));
			Assert.AreEqual(result.Count, Animales.Count);
			controller.mocks.Animales.RemoveAt(controller.mocks.Animales.Count - 1);
		}

		public List<AnimalDTO> GenerarListaAnimales()
		{
			Animales = new List<AnimalDTO>();
			Animales.Add(new AnimalDTO("Carnivoro", "Lobo", 5, "Tucuman", 80, 240, 10));
			Animales.Add(new AnimalDTO("Carnivoro", "Lobo", 2, "Tucuman", 40, 120, 10));
			Animales.Add(new AnimalDTO("Carnivoro", "Lobo", 1, "Tucuman", 30, 90, 10));
			Animales.Add(new AnimalDTO("Herbivoro", "Tortuga", 5, "Tucuman", 80, 5700, fijo: 30));
			Animales.Add(new AnimalDTO("Herbivoro", "Tortuga", 2, "Tucuman", 40, 3000, fijo: 20));
			Animales.Add(new AnimalDTO("Herbivoro", "Tortuga", 1, "Tucuman", 30, 3000, fijo: 40));
			Animales.Add(new AnimalDTO("Reptil", "Lagarto", 5, "Tucuman", 100, 64.29, 10, dias: 6));
			Animales.Add(new AnimalDTO("Reptil", "Lagarto", 5, "Tucuman", 120, 65.14, 10, dias: 8));
			Animales.Add(new AnimalDTO("Reptil", "Lagarto", 5, "Tucuman", 90, 59.14, 10, dias: 10));
			return Animales;
		}
	}
}
