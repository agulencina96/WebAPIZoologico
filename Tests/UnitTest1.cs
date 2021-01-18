using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIZoologico.Models;

namespace Tests
{
	public class Tests
	{
        private List<AnimalCarnivoro> _animalesCarnivoros;
        private List<AnimalHerbivoro> _animalesHerbivoros;
        private List<AnimalReptil> _animalesReptiles;


        [SetUp]
        public void Setup()
        {
            _animalesCarnivoros = new List<AnimalCarnivoro>();
            _animalesHerbivoros = new List<AnimalHerbivoro>();
            _animalesReptiles = new List<AnimalReptil>();
        }

		[Test]
		public void CalcularAlimentoSinAnimalesCarnivoros()
		{
			var animalesHerbivorosReptiles = new List<Animal>();
			_animalesReptiles.AddRange(MockFactoryReptiles());
			_animalesHerbivoros.AddRange(MockFactoryHerbivoros());
			animalesHerbivorosReptiles.AddRange(_animalesReptiles);
			animalesHerbivorosReptiles.AddRange(_animalesHerbivoros);
			var result = animalesHerbivorosReptiles.Sum(a => a.CalcularAlimento());
			Assert.AreEqual(result, 11888.57D);
		}

		[Test]
		public void CalcularAlimentoSinAnimalesHerbivoros()
		{
			var animalesCarnivorosReptiles = new List<Animal>();
			_animalesReptiles.AddRange(MockFactoryReptiles());
			_animalesCarnivoros.AddRange(MockFactoryCarnivoros());
			animalesCarnivorosReptiles.AddRange(_animalesReptiles);
			animalesCarnivorosReptiles.AddRange(_animalesCarnivoros);
			var result = animalesCarnivorosReptiles.Sum(a => a.CalcularAlimento());
			
			Assert.AreEqual(Math.Round(result, 2), 638.57D);
		}

		[Test]

		public void CalcularAlimentoSinAnimalesReptiles()
		{
			var animalesCarnivorosHerbivoros = new List<Animal>();
			_animalesHerbivoros.AddRange(MockFactoryHerbivoros());
			_animalesCarnivoros.AddRange(MockFactoryCarnivoros());
			animalesCarnivorosHerbivoros.AddRange(_animalesHerbivoros);
			animalesCarnivorosHerbivoros.AddRange(_animalesCarnivoros);
			var result = animalesCarnivorosHerbivoros.Sum(a => a.CalcularAlimento());
			Assert.AreEqual(result, 12150D);
		}

		[Test]
        public void CalcularAlimentoSoloCarnivoros()
        {
            _animalesCarnivoros.AddRange(MockFactoryCarnivoros());
            var result = _animalesCarnivoros.Sum(a => a.CalcularAlimento());
            Assert.AreEqual(result, 450D);
        }

		[Test]
		public void CalcularAlimentoSoloHerviboros()
		{
			_animalesHerbivoros.AddRange(MockFactoryHerbivoros());
			var result = _animalesHerbivoros.Sum(a => a.CalcularAlimento());
			Assert.AreEqual(result, 11700D);
		}

		[Test]
		public void CalcularAlimentoSoloReptiles()
		{
			_animalesReptiles.AddRange(MockFactoryReptiles());
			var result = _animalesReptiles.Sum(a => a.CalcularAlimento());
			Assert.AreEqual(result, 565,710D);
		}

		[Test]
		public void CalcularAlimentoTodos()
		{
			var animales = new List<Animal>();
			_animalesHerbivoros.AddRange(MockFactoryHerbivoros());
			_animalesCarnivoros.AddRange(MockFactoryCarnivoros());
			_animalesReptiles.AddRange(MockFactoryReptiles());
			animales.AddRange(_animalesHerbivoros);
			animales.AddRange(_animalesCarnivoros);
			animales.AddRange(_animalesReptiles);
			var result = animales.Sum(a => a.CalcularAlimento());
			Assert.AreEqual(result, 12338.57D);

		}

		[Test]
		public void CalcularCantidadTotalCarne()
		{
			var carnesTotales = 0D;
			var animales = new List<Animal>();
			_animalesCarnivoros.AddRange(MockFactoryCarnivoros());
			_animalesReptiles.AddRange(MockFactoryReptiles());
			animales.AddRange(_animalesCarnivoros);
			animales.AddRange(_animalesReptiles);
			foreach (var animal in animales)
			{
				if (animal.GetType().ToString() == "WebAPIZoologico.Models.AnimalCarnivoro")
				{
					carnesTotales += animal.CalcularAlimento();
				}
				if (animal.GetType().ToString() == "WebAPIZoologico.Models.AnimalReptil")
				{
					carnesTotales += animal.CalcularAlimento() / 2;
				}
			}
			Assert.AreEqual(carnesTotales, 732,855D);

		}

		[Test]
		public void CalcularCantidadTotalHierbas()
		{
			var hierbasTotales = 0D;
			var animales = new List<Animal>();
			_animalesHerbivoros.AddRange(MockFactoryHerbivoros());
			_animalesReptiles.AddRange(MockFactoryReptiles());
			animales.AddRange(_animalesHerbivoros);
			animales.AddRange(_animalesReptiles);
			foreach (var animal in animales)
			{
				if (animal.GetType().ToString() == "WebAPIZoologico.Models.AnimalHerbivoro")
				{
					hierbasTotales += animal.CalcularAlimento();
				}
				if (animal.GetType().ToString() == "WebAPIZoologico.Models.AnimalReptil")
				{
					hierbasTotales += animal.CalcularAlimento() / 2;
				}
			}
			Assert.AreEqual(hierbasTotales, 11982,855D);

		}

		#region Mock Factory
		private List<AnimalCarnivoro> MockFactoryCarnivoros()
		{
			var list = new List<AnimalCarnivoro>();
			list.Add(new AnimalCarnivoro( "Lobo", 5, "Tucuman", 80, 10));
			list.Add(new AnimalCarnivoro( "Lobo", 2, "Tucuman", 40, 10));
			list.Add(new AnimalCarnivoro( "Lobo", 1, "Tucuman", 30, 10));
			return list;
		}

		private List<AnimalHerbivoro> MockFactoryHerbivoros()
		{
			var list = new List<AnimalHerbivoro>();
			list.Add(new AnimalHerbivoro(30,  "Tortuga", 5, "Tucuman", 80));
			list.Add(new AnimalHerbivoro(20, "Tortuga", 2, "Tucuman", 40));
			list.Add(new AnimalHerbivoro(40, "Tortuga", 1, "Tucuman", 30));
			return list;
		}

		private List<AnimalReptil> MockFactoryReptiles()
		{
			var list = new List<AnimalReptil>();
			list.Add(new AnimalReptil("Lagarto",5,"Tucuman",100,6,10));
			list.Add(new AnimalReptil( "Lagarto", 5, "Tucuman", 120, 8, 10));
			list.Add(new AnimalReptil( "Lagarto", 5, "Tucuman", 90, 10, 10));
			return list;
		}

		#endregion
	}
}