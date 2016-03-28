using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalShelter;

namespace AnimalShelterTest
{
    [TestClass]
    public class CatAndDogClass
    {
        private readonly SimpleDate _lastWalkDate;
        private readonly SimpleDate _dateOfBirth;
        private int _chipNumber;
        private readonly string _name;
        private readonly string _badHabits;
        private Dog _dog;
        private Cat _cat;

        public CatAndDogClass()
        {
            _lastWalkDate = new SimpleDate(22, 3, 2016);
            _dateOfBirth = new SimpleDate(11, 12, 2015);
            _chipNumber = 1;
            _name = "test";
            _badHabits = "does not do anything, walks away from humans";
            _dog = null;
            _cat = null;
        }

        [TestInitialize]
        public void InitializeTest()
        {
            Animal.ChipNumbers = new List<int>(); //delete the old list from the previous test
        }



        [TestMethod]
        public void CatObjectCreation()
        {
            _cat = new Cat(_chipNumber, _dateOfBirth, _name, _badHabits);

            Assert.AreEqual(_chipNumber, _cat.ChipRegistrationNumber);
            Assert.AreEqual(_badHabits, _cat.BadHabits);
            Assert.AreEqual(_dateOfBirth, _cat.DateOfBirth);
            Assert.AreEqual(_name, _cat.Name);
        }

        [TestMethod]
        public void DogObjectCreation()
        {
            _dog = new Dog(_chipNumber, _dateOfBirth, _name, _lastWalkDate);

            Assert.AreEqual(_chipNumber, _dog.ChipRegistrationNumber);
            Assert.AreEqual(_lastWalkDate, _dog.LastWalkDate);
            Assert.AreEqual(_dateOfBirth, _dog.DateOfBirth);
            Assert.AreEqual(_name, _dog.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongInputException))]
        public void CatObjectCreationWithInvalidBirthDate()
        {
            DateTime now = DateTime.Now;
            DateTime oneDayAfterNow = now.AddDays(1);
            SimpleDate invalidDateOfBirth = new SimpleDate(oneDayAfterNow.Day, oneDayAfterNow.Month, oneDayAfterNow.Year);
            _cat = new Cat(_chipNumber, invalidDateOfBirth, _name, _badHabits);

            Assert.AreEqual(_chipNumber, _cat.ChipRegistrationNumber);
            Assert.AreEqual(_badHabits, _cat.BadHabits);
            Assert.AreEqual(_dateOfBirth, _cat.DateOfBirth);
            Assert.AreEqual(_name, _cat.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongInputException))]
        public void InvalidchipNumberCat()
        {
            int invalidChipNumber = -1;

            _cat = new Cat(invalidChipNumber, _dateOfBirth, _name, _badHabits);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongInputException))]

        public void InvalidchipNumberDog()
        {
            int invalidChipNumber = -1;

            _dog = new Dog(invalidChipNumber, _dateOfBirth, _name, _lastWalkDate);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongInputException))]
        public void NoNameGiven()
        {
            string invalidName = string.Empty;

            _cat = new Cat(_chipNumber, _dateOfBirth, invalidName, _badHabits);
        }

        [TestMethod]
        public void ToStringTestCat()
        {
            Cat testCat = new Cat(3, new SimpleDate(1, 2, 2011), "name", "none");
            string expected = "Cat: 3, 01-02-2011, name, not reserved, €56, none"; //56 euros because none is 4 chars long
            Assert.AreEqual(expected, testCat.ToString());
        }

        [TestMethod]
        public void ToStringTestDog()
        {
            Dog testDog = new Dog(4, new SimpleDate(1, 2, 2011), "name", new SimpleDate(29, 1, 2011));
            string expected = "Dog: 4, 01-02-2011, name, not reserved, €200, 29-01-2011"; 
            Assert.AreEqual(expected, testDog.ToString());
        }

        [TestMethod]
        public void PriceTestCat()
        {
            Cat testCatPrice = new Cat(4, new SimpleDate(1, 2, 2011), "name", "none");

            Assert.IsFalse(testCatPrice.Price < 20);
            Assert.IsTrue(testCatPrice.Price == 60 - testCatPrice.BadHabits.Length || testCatPrice.Price == 20);
        }

        [TestMethod]
        public void PriceTestDog()
        {
            Dog testDogPrice = new Dog(4, new SimpleDate(1, 2, 2011), "name", new SimpleDate(29, 1, 2011));
            PriceDogTest(testDogPrice);
        }

        public void PriceTestDogOver50000()
        {
            Dog testDogPrice = new Dog(50000, new SimpleDate(1, 2, 2011), "name", new SimpleDate(29, 1, 2011));
            PriceDogTest(testDogPrice);
        }

        public void PriceDogTest(Dog dog)
        {
            if (dog.ChipRegistrationNumber >= 50000)
            {
                Assert.IsTrue(dog.Price == 350);
            }
            else
            {
                Assert.IsTrue(dog.Price == 200);
            }
        }
    }
}
