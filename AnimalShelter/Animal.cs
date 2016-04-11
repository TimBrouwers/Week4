using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace AnimalShelter
{
    /// <summary>
    /// Class representing an animal in the shelter.
    /// </summary>
    [Serializable]
    public abstract class Animal : ISellable, IComparable<Animal>, ISerializable
    {
        //public static List<int> ChipNumbers { get; set; }

        public abstract decimal Price { get; }
        /// <summary>
        /// The chipnumber of the animal. Must be unique. Must be zero or greater than zero.
        /// </summary>
        public int ChipRegistrationNumber { get; private set; }

        /// <summary>
        /// Date of birth of the animal.
        /// </summary>
        public SimpleDate DateOfBirth { get; private set; }

        /// <summary>
        /// The name of the animal.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Is the animal reserved by a future owner yes or no.
        /// </summary>
        public bool IsReserved { get; set; }

        /// <summary>
        /// Creates an animal.
        /// </summary>
        /// <param name="chipRegistrationNumber">The chipnumber of the animal. 
        ///                                      Must be unique. Must be zero or greater than zero.</param>
        /// <param name="dateOfBirth">The date of birth of the animal.</param>
        /// <param name="name">The name of the animal.</param>
        public Animal(int chipRegistrationNumber, SimpleDate dateOfBirth, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Invalid name");
            }

                
            if (chipRegistrationNumber <= 0)
            {
                throw new ArgumentException("Chipnumber wrong");
            }

            if (dateOfBirth == null || SimpleDate.Compare(dateOfBirth, new SimpleDate(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year)) <= 0)
            {
                throw new ArgumentException("Date of birth is of the wrong type or later than today");
            }
            DateOfBirth = dateOfBirth;
            
            Name = name;
            ChipRegistrationNumber = chipRegistrationNumber;
            IsReserved = false;
        }

        public Animal(SerializationInfo info, StreamingContext ctxt)
        {
            int chipnumber = (int) info.GetValue("ChipRegistrationNumber", typeof (int));
            string name = (string) info.GetValue("Name", typeof (string));
            SimpleDate dateofbirth = (SimpleDate) info.GetValue("BirthDate", typeof (SimpleDate));
            bool isreserved = (bool) info.GetValue("Reserved", typeof (bool));

            if (chipnumber < 0 && string.IsNullOrWhiteSpace(name) && dateofbirth == null)
            {
                throw new ArgumentException("One or more parameters are incorrect, aborting import.");
            }
            ChipRegistrationNumber = chipnumber;
            Name = name;
            DateOfBirth = dateofbirth;
            IsReserved = isreserved;
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext stctxt)
        {
            info.AddValue("ChipRegistrationNumber", ChipRegistrationNumber);
            info.AddValue("Name", Name);
            info.AddValue("BirthDate", DateOfBirth);
            info.AddValue("Reserved", IsReserved);
        }

        /// <summary>
        /// Retrieve information about this animal
        /// 
        /// Note: Every class inherits (automagically) from the 'Object' class,
        /// which contains the virtual ToString() method which you can override.
        /// </summary>
        /// <returns>A string containing the information of this animal.
        ///          The format of the returned string is
        ///          "<ChipRegistrationNumber>, <DateOfBirth>, <Name>, <IsReserved>"
        ///          Where: IsReserved will be "reserved" if reserved or "not reserved" otherwise. 
        /// </returns>
        public override string ToString()
        {
            string IsReservedString;
            if (IsReserved)
            {
                IsReservedString = "reserved";
            }
            else
            {
                IsReservedString = "not reserved";
            }

            string info = ChipRegistrationNumber
                          + ", " + DateOfBirth
                          + ", " + Name
                          + ", " + IsReservedString
                          + ", " + "€" + Price
                          + ", ";
            return info;
        }

        public int CompareTo(Animal other)
        {
            return this.ChipRegistrationNumber.CompareTo(other.ChipRegistrationNumber);
        }
    }
}
