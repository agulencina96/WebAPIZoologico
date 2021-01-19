using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIZoologico.Models;

namespace Tests
{
	public class ModelTests
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
			animalesHerbivorosReptiles.AddRange(MockFactoryReptiles());
			animalesHerbivorosReptiles.AddRange(MockFactoryHerbivoros());
			var result = animalesHerbivorosReptiles.Sum(a => a.CalcularAlimento());
			Assert.AreEqual(result, 11888.57D);
		}

		[Test]
		public void CalcularAlimentoSinAnimalesHerbivoros()
		{
			var animalesCarnivorosReptiles = new List<Animal>();
			animalesCarnivorosReptiles.AddRange(MockFactoryReptiles());
			animalesCarnivorosReptiles.AddRange(MockFactoryCarnivoros());
			var result = animalesCarnivorosReptiles.Sum(a => a.CalcularAlimento());
			
			Assert.AreEqual(Math.Round(result, 2), 638.57D);
		}

		[Test]

		public void CalcularAlimentoSinAnimalesReptiles()
		{
			var animalesCarnivorosHerbivoros = new List<Animal>();
			animalesCarnivorosHerbivoros.AddRange(MockFactoryHerbivoros());
			animalesCarnivorosHerbivoros.AddRange(MockFactoryCarnivoros());
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
			animales.AddRange(MockFactoryHerbivoros());
			animales.AddRange(MockFactoryCarnivoros());
			animales.AddRange(MockFactoryReptiles());
			var result = animales.Sum(a => a.CalcularAlimento());
			Assert.AreEqual(result, 12338.57D);

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