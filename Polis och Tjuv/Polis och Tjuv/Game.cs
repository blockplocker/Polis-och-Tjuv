using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polis_och_Tjuv
{
    internal class Game
    {
        public List<string> NewsFeed { get; set; }
        public bool PersonsMet { get; set; }
        public int RobbedCitizens { get; set; }
        public int ArestedThiefs { get; set; }

        public Game()
        {
            NewsFeed = new List<string>();
            RobbedCitizens = 0;
            ArestedThiefs = 0;
            PersonsMet = false;
        }

        public void DisplayStatistics()
        {
            Console.WriteLine("=STATISTICS=========================================");
            Console.WriteLine("Robbed Citizens: " + RobbedCitizens);
            Console.WriteLine("Arested Thiefs: " + ArestedThiefs);
        }
        public void DisplayNews()
        {
            Console.WriteLine("=NEWS FEED============================================================================================");
            for (int i = NewsFeed.Count; i > 0; i--)
            {
                Console.WriteLine(i + ": " + NewsFeed[i - 1]);
            }

        }
        public bool DisplayPerson(List<Person> persons, int x, int y)
        {
            foreach (Person person in persons)
            {
                if (person.PosX == x && person.PosY == y)
                {

                    Console.Write(person is Citizen ? "C" :
                                  person is Police ? "P" :
                                  person is Thief ? "T" : "");
                    return true;

                }
            }
            return false;
        }
        public void DisplayCity(List<Person> persons)
        {
            Console.WriteLine("=CITY=================================================================================================");
            for (int y = 0; y < 25; y++)
            {
                Console.Write("X");
                for (int x = 0; x < 100; x++)
                {
                    if (!DisplayPerson(persons, x, y))
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("X");
                Console.WriteLine();
            }
        }
    }
}
