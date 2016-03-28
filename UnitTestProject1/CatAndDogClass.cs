﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalShelter;

namespace AnimalShelterTest
{
    [TestClass]
    public class CatAndDogClass
    {
        private readonly SimpleDate _lastWalkDate;
        private readonly SimpleDate _dateOfBirth;
        private readonly int _chipNumber;
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
            //might use this eventually?
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
        public void CatObjectCreation()
        {
            _cat = new Cat(_chipNumber, _dateOfBirth, _name, _badHabits);

            Assert.AreEqual(_chipNumber, _cat.ChipRegistrationNumber);
            Assert.AreEqual(_badHabits, _cat.BadHabits);
            Assert.AreEqual(_dateOfBirth, _cat.DateOfBirth);
            Assert.AreEqual(_name, _cat.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
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
        [ExpectedException(typeof(FormatException))]
        public void InvalidchipNumberCat()
        {
            int invalidChipNumber = -1;

            _cat = new Cat(invalidChipNumber, _dateOfBirth, _name, _badHabits);
        }
        public void InvalidchipNumberDog()
        {
            int invalidChipNumber = -1;

            _dog = new Dog(invalidChipNumber, _dateOfBirth, _name, _lastWalkDate);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NoNameGiven()
        {
            string invalidName = string.Empty;

            _cat = new Cat(_chipNumber, _dateOfBirth, invalidName, _badHabits);
        }
    }
}
