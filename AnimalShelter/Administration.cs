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
            if (animal != null)
            {
                animals.Add(animal);
                return true;
            }
            return false;
        }

        public bool RemoveAnimal(int chipRegistrationNumber)
        {
            Animal animalToRemove = null;
            foreach (Animal animal in animals)
            {
                if (animal.ChipRegistrationNumber == chipRegistrationNumber)
                {
                    animalToRemove = animal;
                    break;
                }
            }
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
