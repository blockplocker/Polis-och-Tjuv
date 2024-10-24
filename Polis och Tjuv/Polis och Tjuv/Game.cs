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
        public void DisplayPerson(Person person)
        {
            
            Console.SetCursorPosition(person.PosX, person.PosY);
            
            ConsoleColor color = (person is Citizen ? ConsoleColor.Green :
                                  person is Police ? ConsoleColor.Blue :
                                  person is Thief ? ConsoleColor.Red : ConsoleColor.White);
            Console.ForegroundColor = color;
            Console.Write(person is Citizen ? "C" :
                                  person is Police ? "P" :
                                  person is Thief ? "T" : "");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void DisplayAllPersons(List<Person> persons)
        {
            foreach (Person person in persons)
            {
                Console.SetCursorPosition(person.PosX, person.PosY);
                person.Move();
                Console.Write(" ");
                DisplayPerson(person);

            }
        }
        public void DisplayCity(List<Person> persons)
        {
            //Console.WriteLine();
            Console.WriteLine("=CITY=================================================================================================");
            for (int y = 0; y < 25; y++)
            {
                Console.Write("X");
                for (int x = 0; x < 100; x++)
                {
                        Console.Write(" ");
                    
                }
                Console.Write("X");
                Console.WriteLine();
            }
        }
        public void DetectPersonCollision(List<Person> persons)
        {
            foreach(Person person in persons)
            {
                foreach (Person person2 in persons)
                {
                    if(person.PosX == person2.PosX && person.PosY == person2.PosY)
                    {
                        if (person is Thief)
                        {
                            if (person2 is Citizen)
                            {
                                ((Thief)person).Steal(person2 as Citizen, this);
                                PersonsMet = true;

                            }
                        }
                    }
                }
            }
        }
    }
}
