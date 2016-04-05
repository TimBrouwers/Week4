using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalShelter;

namespace AnimalShelterTest
{
    [TestClass]
    public class CatAndDogClass
    {
        private readonly SimpleDate lastWalkDate;
        private readonly SimpleDate dateOfBirth;
        private int chipNumber;
        private readonly string name;
        private readonly string badHabits;
        private Dog dog;
        private Cat cat;

        public CatAndDogClass()
        {
            lastWalkDate = new SimpleDate(22, 3, 2016);
            dateOfBirth = new SimpleDate(11, 12, 2015);
            chipNumber = 1;
            name = "test";
            badHabits = "does not do anything, walks away from humans";
            dog = null;
            cat = null;
        }

        [TestInitialize]
        public void InitializeTest()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NoNameCat()
        {
            cat = new Cat(chipNumber, dateOfBirth, null, badHabits);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NoNameDog()
        {
            dog = new Dog(chipNumber, dateOfBirth, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NoChipNumber()
        {
            cat = new Cat(0, dateOfBirth, name, badHabits);
        }

        [TestMethod]
        public void CatObjectCreation()
        {
            cat = new Cat(chipNumber, dateOfBirth, name, badHabits);

            Assert.AreEqual(chipNumber, cat.ChipRegistrationNumber);
            Assert.AreEqual(badHabits, cat.BadHabits);
            Assert.AreEqual(dateOfBirth, cat.DateOfBirth);
            Assert.AreEqual(name, cat.Name);
        }

        [TestMethod]
        public void DogObjectCreation()
        {
            dog = new Dog(chipNumber, dateOfBirth, name, lastWalkDate);

            Assert.AreEqual(chipNumber, dog.ChipRegistrationNumber);
            Assert.AreEqual(lastWalkDate, dog.LastWalkDate);
            Assert.AreEqual(dateOfBirth, dog.DateOfBirth);
            Assert.AreEqual(name, dog.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CatObjectCreationWithInvalidBirthDate()
        {
            DateTime now = DateTime.Now;
            DateTime oneDayAfterNow = now.AddDays(1);
            SimpleDate invalidDateOfBirth = new SimpleDate(oneDayAfterNow.Day, oneDayAfterNow.Month, oneDayAfterNow.Year);
            cat = new Cat(chipNumber, invalidDateOfBirth, name, badHabits);

            Assert.AreEqual(chipNumber, cat.ChipRegistrationNumber);
            Assert.AreEqual(badHabits, cat.BadHabits);
            Assert.AreEqual(dateOfBirth, cat.DateOfBirth);
            Assert.AreEqual(name, cat.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidchipNumberCat()
        {
            int invalidChipNumber = -1;

            cat = new Cat(invalidChipNumber, dateOfBirth, name, badHabits);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void InvalidchipNumberDog()
        {
            int invalidChipNumber = -1;

            dog = new Dog(invalidChipNumber, dateOfBirth, name, lastWalkDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NoNameGiven()
        {
            string invalidName = string.Empty;

            cat = new Cat(chipNumber, dateOfBirth, invalidName, badHabits);
        }

        [TestMethod]
        public void ToStringTestCat()
        {
            Cat testCat = new Cat(3, new SimpleDate(1, 2, 2011), "name", "hello");
            string expected = "Cat: 3, 01-02-2011, name, not reserved, €55, hello"; //55 euros because hello is 5 chars long
            Assert.AreEqual(expected, testCat.ToString());
        }

        [TestMethod]
        public void ToStringTestDog()
        {
            Dog testDog = new Dog(4, new SimpleDate(1, 2, 2011), "name", new SimpleDate(26, 2, 2011));
            string expected = "Dog: 4, 01-02-2011, name, not reserved, €200, 26-02-2011"; 
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
        public void PriceTestCatUnder20()
        {
            Cat testCatPrice = new Cat(4, new SimpleDate(1, 2, 2011), "name", "The price should be very low after I fill his bad behaviour really long but I don't know when it is long enough...");

            Assert.IsFalse(testCatPrice.Price < 20);
            Assert.IsTrue(testCatPrice.Price == 60 - testCatPrice.BadHabits.Length || testCatPrice.Price == 20);
        }
        [TestMethod]
        public void PriceTestDog()
        {
            Dog testDogPrice = new Dog(4, new SimpleDate(1, 2, 2011), "name", new SimpleDate(26, 2, 2011));
            PriceDogTest(testDogPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LastwalkDateLaterThanToday()
        {
            Dog dogLastwalkDateAfterToday = new Dog(5, new SimpleDate(1, 2, 2011), "name", new SimpleDate(29, 3, DateTime.Now.Year + 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LastWalkDateBeforeBorn()
        {
            Dog dogLastwalkDateBeforeBorn = new Dog(6, new SimpleDate(1, 2, 2011), "name", new SimpleDate(29, 1, 2011));
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
