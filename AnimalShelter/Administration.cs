using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalShelter
{
    class Administration
    {
        private List<Animal> animals = new List<Animal>();

        public Administration()
        { }

        public bool Add(Animal animal)
        {
            bool ReturnValue = true;
            animals.Add(animal);
            return ReturnValue;
        }

        public bool RemoveAnimal(int chipRegistrationNumber)
        {

            return;
        }

        public static Animal FindAnimal(int chipRegistrationNumber)
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
