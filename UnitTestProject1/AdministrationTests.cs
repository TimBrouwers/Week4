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
        public void ExportTestOneAnimal()
        {
            administration.Add(testAnimal);
            administration.Export("TestFile.txt");
            string newline = "\r\n";
            //areequal tests for testanimal with \r\n added, because export writes with a newline on the end
            Assert.AreEqual(testAnimal.ToString() + newline , File.ReadAllText("TestFile.txt"));
        }

        [TestMethod]
        public void ExportTestMoreAnimals()
        {
            administration.Add(testAnimal);
            administration.Add(testAnimal2);
            administration.Export("TestFile.txt");
            string newline = "\r\n";
            //areequal tests for testanimal with \r\n added, because export writes with a newline on the end
            Assert.AreEqual(testAnimal.ToString() + newline + testAnimal2.ToString() + newline, 
                File.ReadAllText("TestFile.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void SerializedFileDoesNotExist()
        {
            administration.Load("notexistingfile");
        }

        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        public void SerializedFileInvalid()
        {
            string testFilePath = "testfile.txt";
            string randomGarbage = "abcdefghijklmnop";
            File.WriteAllText(testFilePath, randomGarbage);
            administration.Load(testFilePath);
        }

        [TestMethod]
        public void SerializationTest()
        {
            string pathToTestFile = "testfile.io";
            administration.Add(testAnimal);
            administration.Add(testAnimal2);
            administration.Save(pathToTestFile);
            administration.Animals.Clear();
            Assert.IsFalse(administration.Animals.Contains(testAnimal));
            Assert.IsFalse(administration.Animals.Contains(testAnimal2));
            administration.Load(pathToTestFile);
            Assert.AreEqual(administration.FindAnimal(testAnimal.ChipRegistrationNumber).ToString(), testAnimal.ToString());
            Assert.AreEqual(administration.FindAnimal(testAnimal2.ChipRegistrationNumber).ToString(), testAnimal2.ToString());
            /* does not work
            CollectionAssert.Contains(administration.Animals, testAnimal);
            Assert.IsTrue(administration.Animals.Contains(testAnimal2));
            */
        }

    }
}