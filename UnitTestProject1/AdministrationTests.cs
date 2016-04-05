using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalShelter;
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Tests
{
    [TestClass()]
    public class AdministrationTests
    {
        private Animal testAnimal;
        private Animal testAnimal2;
        private Administration administration;

        public AdministrationTests()
        {
            administration = new Administration();
            testAnimal = new Cat(1, new SimpleDate(1, 2, 2011), "name", "none");
            testAnimal2 = new Dog(2, new SimpleDate(12,12, 2014), "doggy",new SimpleDate(13, 12, 2015));
        }

        [TestInitialize]
        public void InitializeTest()
        { }

        [TestMethod()]
        public void AdministrationTest()
        {
            Assert.IsInstanceOfType(administration.animals, typeof(List<Animal>));
        }

        [TestMethod()]
        public void AddTest()
        {
            administration.Add(testAnimal);
            Assert.IsTrue(administration.animals.Contains(testAnimal));
        }

        [TestMethod()]
        public void AddTestFail()
        {
            administration.Add(null);
            Assert.IsFalse(administration.animals.Contains(testAnimal));
        }

        [TestMethod()]
        public void RemoveAnimalTest() //add two animals to test if not the wrong animal was removed
        {
            administration.Add(testAnimal);
            administration.Add(testAnimal2);
            Assert.IsTrue(administration.RemoveAnimal(testAnimal2.ChipRegistrationNumber));
            Assert.IsFalse(administration.animals.Contains(testAnimal2));
            Assert.IsTrue(administration.animals.Contains(testAnimal));
        }

        [TestMethod]
        public void RemoveAnimalTestFail()
        {
            administration.Add(null);
            Assert.IsFalse(administration.RemoveAnimal(testAnimal.ChipRegistrationNumber));
        }

        [TestMethod()]
        public void FindAnimalTest() //two animals so it will work when more than one animals are added
        {
            administration.Add(testAnimal);
            administration.Add(testAnimal2);
            Animal testAnimalFindAnimal = administration.FindAnimal(testAnimal2.ChipRegistrationNumber);
            Assert.AreEqual(testAnimal2, testAnimalFindAnimal);
        }
    }
}