using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalShelter;

namespace AnimalShelterTest
{
    [TestClass]
    public class TestObjectCreation
    {
        [TestMethod]
        public void TestDogObject()
        {
            int chipnumber = 10000;
            SimpleDate lastwalk = new SimpleDate(1, 2, 3000);
            SimpleDate dateofbirth = new SimpleDate(5, 6, 5000);
            string name = "hond";

            Dog dog = new Dog(chipnumber, dateofbirth, name, lastwalk);

            Assert.AreEqual(chipnumber, dog.ChipRegistrationNumber);
            Assert.AreEqual(lastwalk, dog.LastWalkDate);
            Assert.AreEqual(dateofbirth, dog.DateOfBirth);
            Assert.AreEqual(name, dog.Name);
        }

        [TestMethod]
        public void TestCatObject()
        {
            int chipnumber = 11000;
            SimpleDate dateofbirth = new SimpleDate(5, 6, 5000);
            string name = "kat";
            string badHabits = "krast";

            Cat cat = new Cat(chipnumber, dateofbirth, name, badHabits);

            Assert.AreEqual(chipnumber, cat.ChipRegistrationNumber);
            Assert.AreEqual(badHabits, cat.BadHabits);
            Assert.AreEqual(dateofbirth, cat.DateOfBirth);
            Assert.AreEqual(name, cat.Name);
        }

       /* [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestWrongChipnumber()
        {
            int chipnumber = -1;
            SimpleDate dateofbirth = new SimpleDate(5, 6, 1111);
            SimpleDate lastwalkdate = new SimpleDate(1, 24, 2);
            string name = "test";
            string badHabits = "not an actual cat";

            Cat cat = new Cat(chipnumber, dateofbirth, name, badHabits);
            Dog dog = new Dog(chipnumber, dateofbirth, name, lastwalkdate);
        }*/
    }
}
