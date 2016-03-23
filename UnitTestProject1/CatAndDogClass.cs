﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalShelter;

namespace AnimalShelterTest
{
    [TestClass]
    public class CatAndDogClass
    {
        SimpleDate lastWalkDate;
        SimpleDate dateOfBirth;
        int chipNumber;
        string name;
        string badHabits;

        [TestInitialize]
        public void InitializeTest()
        {
            lastWalkDate = new SimpleDate(22, 3, 2016);
            dateOfBirth = new SimpleDate(11, 12, 2015);
            chipNumber = 1;
            name = "test";
            badHabits = "does not do anything, walks away from humans";
        }
        [TestMethod]
        public void DogObjectCreation()
        {
            Dog dog = new Dog(chipNumber, dateOfBirth, name, lastWalkDate);

            Assert.AreEqual(chipNumber, dog.ChipRegistrationNumber);
            Assert.AreEqual(lastWalkDate, dog.LastWalkDate);
            Assert.AreEqual(dateOfBirth, dog.DateOfBirth);
            Assert.AreEqual(name, dog.Name);
        }

        [TestMethod]
        public void CatObjectCreation()
        {
            Cat cat = new Cat(chipNumber, dateOfBirth, name, badHabits);

            Assert.AreEqual(chipNumber, cat.ChipRegistrationNumber);
            Assert.AreEqual(badHabits, cat.BadHabits);
            Assert.AreEqual(dateOfBirth, cat.DateOfBirth);
            Assert.AreEqual(name, cat.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void CatObjectCreationWithInvalidBirthDate()
        {
            SimpleDate invalidDateOfBirth;
            DateTime now = DateTime.Now;
            DateTime oneDayAfterNow = now.AddDays(1);
            invalidDateOfBirth = new SimpleDate(oneDayAfterNow.Day, oneDayAfterNow.Month, oneDayAfterNow.Year);
            Cat cat = new Cat(chipNumber, dateOfBirth, name, badHabits);

            Assert.AreEqual(chipNumber, cat.ChipRegistrationNumber);
            Assert.AreEqual(badHabits, cat.BadHabits);
            Assert.AreEqual(dateOfBirth, cat.DateOfBirth);
            Assert.AreEqual(name, cat.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InvalidchipNumberCat()
        {
            int chipNumber = -1;

            Cat cat = new Cat(chipNumber, dateOfBirth, name, badHabits);
        }
        public void InvalidchipNumberDog()
        {
            int chipNumber = -1;

            Dog dog = new Dog(chipNumber, dateOfBirth, name, lastWalkDate);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NoNameGiven()
        {
            name = string.Empty;

            Cat cat = new Cat(chipNumber, dateOfBirth, name, badHabits);
        }
    }
}