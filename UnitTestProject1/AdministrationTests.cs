using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalShelter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
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
            testAnimal2 = new Dog(2, new SimpleDate(12, 12, 2014), "doggy", new SimpleDate(13, 12, 2015));
        }

        [TestInitialize]
        public void InitializeTest()
        { }

        [TestMethod()]
        public void AdministrationTest()
        {
            Assert.IsInstanceOfType(administration.Animals, typeof(List<Animal>));
        }

        [TestMethod()]
        public void AddTest()
        {
            administration.Add(testAnimal);
            Assert.IsTrue(administration.Animals.Contains(testAnimal));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddTestFail()
        {
            administration.Add(null);
        }

        [TestMethod()]
        public void RemoveAnimalTest() //add two Animals to test if not the wrong animal was removed
        {
            administration.Add(testAnimal);
            administration.Add(testAnimal2);
            Assert.IsTrue(administration.RemoveAnimal(testAnimal2.ChipRegistrationNumber));
            Assert.IsFalse(administration.Animals.Contains(testAnimal2));
            Assert.IsTrue(administration.Animals.Contains(testAnimal));
        }

        [TestMethod]
        public void RemoveAnimalTestFail()
        {
            try
            {
                administration.Add(null);
            }

            catch (ArgumentException)
            {

            }

            Assert.IsFalse(administration.RemoveAnimal(testAnimal.ChipRegistrationNumber));
        }

        [TestMethod()]
        public void FindAnimalTest() //two Animals so it will work when more than one Animals are added
        {
            administration.Add(testAnimal);
            administration.Add(testAnimal2);
            Animal testAnimalFindAnimal = administration.FindAnimal(testAnimal2.ChipRegistrationNumber);
            Assert.AreEqual(testAnimal2, testAnimalFindAnimal);
        }

        [TestMethod]
        public void ExportTest()
        {
            administration.Add(testAnimal);
            administration.Export("TestFile.txt");
            //Assert.AreEqual(File.ReadAllText() == testAnimal.ToString());

        }

    }
}