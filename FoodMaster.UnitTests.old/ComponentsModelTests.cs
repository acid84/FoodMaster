using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMaster.Common.Entities;
using FoodMaster.Model;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace FoodMaster.UnitTests
{
    [TestFixture]
    public class ComponentsModelTests
    {
        private Mock<IStorage<Component>> _storageMock;
        private ComponentsModel _model;

        [SetUp]
        public void Init()
        {
            _storageMock = new Mock<IStorage<Component>>();
            _model = new ComponentsModel(_storageMock.Object);
        }

        [Test]
        public void AddComponentStoresComponent_Test()
        {
            Task task = _model.AddComponentAsync(CreateComponent());
            task.Wait();
            _storageMock.Verify(x => x.Store(It.IsAny<IEnumerable<Component>>()), Times.Exactly(1));
        }

        [Test]
        public async Task GetAllComponentReturnsAllItems_Test()
        {
            var createdComponents = new List<Component> {CreateComponent(), CreateComponent(), CreateComponent()};

            _storageMock.Setup(x => x.GetItems()).Returns(() => Task.FromResult(createdComponents.AsEnumerable()));

            var components = await _model.GetAllComponentsAsync();
            _storageMock.Verify(x => x.GetItems(), Times.Exactly(1));
            Assert.AreEqual(createdComponents, components);
        }

	    [Test]
	    public void Test()
	    {
		    var comp = CreateComponent();
		    var jsonString = JsonConvert.SerializeObject(comp);

		    Console.WriteLine(jsonString);
	    }

        private Component CreateComponent()
        {
            var comp = new Component();
            comp.Name = "Chicken";
            comp.NutritionValue = new Nutrition
            {
                Carbs = 10,
                Fat = 1,
                Kcal = 300,
                Fiber = 3
            };
            return comp;
        }
    }
}
