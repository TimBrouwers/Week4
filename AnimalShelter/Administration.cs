using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalShelter
{
    public class Administration
    {
        public List<Animal> animals { get; private set; }

        public Administration()
        {
            animals = new List<Animal>();
        }

        public bool Add(Animal animal)
        {
            if (FindAnimal(animal.ChipRegistrationNumber) != null)
            {
                throw new ArgumentException("Chipregistrationnumber already exists");
            }
            if (animal == null)
            {
                throw new ArgumentException("Animal does not exist.");
            }
            animals.Add(animal);
            return true;
        }

        public bool RemoveAnimal(int chipRegistrationNumber)
        {
            Animal animalToRemove = FindAnimal(chipRegistrationNumber);
            return animals.Remove(animalToRemove);
        }

        public Animal FindAnimal(int chipRegistrationNumber)
        {
            Animal foundAnimal = null;

            foreach (Animal animal in animals)
            {
                if (animal.ChipRegistrationNumber == chipRegistrationNumber)
                {
                    foundAnimal = animal;
                }
            }

            return foundAnimal;
        }
    }
}
