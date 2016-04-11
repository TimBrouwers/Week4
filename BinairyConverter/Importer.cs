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
                    chipNumber = infoAnimal[1];
                    birthDate = infoAnimal[2];
                    name = infoAnimal[3];
                }
                else
                {
                    throw new FileLoadException("File is corrupt or invalid.");
                }

                if (infoAnimal[0] == "Cat")
                {
                    badHabits = infoAnimal.Length > 5 ? infoAnimal[6] : string.Empty;
                    CatList.Add($"{chipNumber},{name},{birthDate},{badHabits}");
                }
                else if (infoAnimal[0] == "Dog")
                {
                    DogList.Add($"{chipNumber},{name},{birthDate}");
                }
            }
        }
    }
}
