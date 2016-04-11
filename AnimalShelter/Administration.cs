using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace AnimalShelter
{
    [Serializable]
    public class Administration : ISerializable
    {
        public List<Animal> Animals { get; private set; }

        private Stream file = null;

        public Administration()
        {
            Animals = new List<Animal>();
        }

        public Administration(SerializationInfo info, StreamingContext ctxt)
        {
            Animals = (List<Animal>)info.GetValue("Animals", typeof(List<Animal>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Animals", Animals);
        }

        //does not return a bool anymore, because exceptions are thrown when the input is wrong
        public void Add(Animal animal)
        {
            if (animal == null)
            {
                throw new ArgumentException("Animal does not exist.");
            }
            if (FindAnimal(animal.ChipRegistrationNumber) != null)
            {
                throw new ArgumentException("Chipregistrationnumber already exists");
            }
            Animals.Add(animal);
        }

        public bool RemoveAnimal(int chipRegistrationNumber)
        {
            Animal animalToRemove = FindAnimal(chipRegistrationNumber);
            return Animals.Remove(animalToRemove);
        }

        public Animal FindAnimal(int chipRegistrationNumber)
        {
            Animal foundAnimal = null;

            foreach (Animal animal in Animals)
            {
                if (animal.ChipRegistrationNumber == chipRegistrationNumber)
                {
                    foundAnimal = animal;
                }
            }
            return foundAnimal;
        }

        /// <summary>
        /// Saves all animals to a file with the given file name using serialisation.
        /// </summary>
        /// <param name="fileName">The file to write to.</param>
        public void Save(string fileName)
        {
            try
            {
                file = File.Open(fileName, FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(file, Animals);
                file.Close();
            }
            catch (IOException ioException)
            {
                MessageBox.Show(ioException.Message);
            }
            finally
            {
                file.Close();
            }
        }

        /// <summary>
        /// Loads all animals from a file with the given file name using deserialisation.
        /// All animals currently in the administration are removed.
        /// </summary>
        /// <param name="fileName">The file to read from.</param>
        public void Load(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File not found.");
            }
            try
            {
                file = File.Open(fileName, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                Animals = (List<Animal>)formatter.Deserialize(file);
                file.Close();
            }
            catch (SerializationException)
            {
                throw new FileLoadException("File invalid or corrupt.");
            }
            /*
            //this is an exception that was thrown while testing with corrupt files.
            After reading the internet, it was concluded that this exception should close the application,
            because there is not much we can do when this happens.
            It might sometimes happen when trying to read a corrupt file.
            catch (OutOfMemoryException)
            {
                throw new FileLoadException("File invalid or corrupt.");
            }*/
            finally
            {
                file.Close();
            }
        }

        /// <summary>
        /// Exports the info of all animals to a text file with the given file name.
        /// 
        /// Each line of the file contains the info about exactly one animal.
        /// Each line starts with the type of animal and a colon (e.g. 'Cat:' or 'Dog:')
        /// followed by the properties of the animal seperated by comma's.
        /// </summary>
        /// <param name="fileName">The text file to write to.</param>
        public void Export(string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            foreach (Animal a in Animals)
            {
                string exportInfo = null;
                if (a is Cat)
                {
                    Cat cat = a as Cat;
                    exportInfo = string.Format("Cat:{0},{1},{2},{3},{4},{5}",
                        cat.ChipRegistrationNumber,
                        cat.DateOfBirth,
                        cat.Name,
                        cat.IsReserved,
                        cat.Price,
                        cat.BadHabits);
                }
                else if (a is Dog)
                {
                    Dog dog = a as Dog;
                    exportInfo = string.Format("Dog:{0},{1},{2},{3},{4},{5}",
                        dog.ChipRegistrationNumber,
                        dog.DateOfBirth,
                        dog.Name,
                        dog.IsReserved,
                        dog.Price,
                        dog.LastWalkDate);
                }
                writer.WriteLine(exportInfo);
            }
            writer.Close();
        }

    }
}
