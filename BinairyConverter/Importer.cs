using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinairyConverter
{
    public class Importer
    {
        public List<string> DogList { get; private set; }
        public List<string> CatList { get; private set; }

        public Importer()
        {
            DogList = new List<string>();
            CatList = new List<string>();
        }
        public void Import(string fileName)
        {
            string[] data = File.ReadAllLines(fileName);
            char[] seperators = new[] { ',', ':' };
            foreach (string s in data)
            {
                string[] infoAnimal = s.Split(seperators);
                string chipNumber, birthDate, name, badHabits;
                if (infoAnimal.Length > 3)
                {
                    chipNumber = infoAnimal[1].Trim();
                    birthDate = infoAnimal[2].Trim();
                    name = infoAnimal[3].Trim();
                }
                else
                {
                    throw new FileLoadException("File is corrupt or invalid.");
                }

                switch (infoAnimal[0])
                {
                    case "Cat":
                        if (infoAnimal.Length > 5)
                        {
                            badHabits = infoAnimal[6];
                        }
                        else
                        {
                            throw new FileLoadException("File is corrupt or invalid");
                        }
                        CatList.Add($"{chipNumber},{name},{birthDate},{badHabits}");
                        break;
                    case "Dog":
                        DogList.Add($"{chipNumber},{name},{birthDate}");
                        break;
                }
            }
        }
    }
}
