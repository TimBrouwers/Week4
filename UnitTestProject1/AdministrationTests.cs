using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalShelter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Tests
{
    [TestClass()]
    public class AdministrationTests
    {
        private Animal testAnimal;
        private Administration administration;

        public AdministrationTests()
        {
            administration = new Administration();
            testAnimal = new Cat(1, new SimpleDate(1, 2, 2011), "name", "none");
        }

        [TestInitialize]
        public void InitializeTest()
        {
            Animal.chipNumbers = new List<int>(); //delete the old list from the previous test
        }

        [TestMethod()]
        public void AdministrationTest()
        {
            Assert.IsInstanceOfType(administration.animals, typeof(List<Animal>));
        }

        [TestMethod()]
        public void AddTest()
        {
            administration.Add((testAnimal));
            Assert.IsTrue(administration.animals.Contains(testAnimal));
        }

        [TestMethod()]
        public void RemoveAnimalTest()
        {
            administration.Add(testAnimal);
            Assert.IsTrue(administration.RemoveAnimal(testAnimal.ChipRegistrationNumber));
        }

        [TestMethod()]
        public void FindAnimalTest()
        {
            administration.Add(testAnimal);
            Animal testAnimal2 = administration.FindAnimal(testAnimal.ChipRegistrationNumber);
            Assert.AreEqual(testAnimal, testAnimal2);
        }
    }
}