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

        public void DisplayStatistics(List<Person> persons)
        {
            int cItems = 0;
            int pItems = 0;
            int tItems = 0;

            foreach (Person p in persons)
            {
                if (p is Citizen)
                {
                    cItems += ((Citizen)p).Items.Count();
                }
                if (p is Thief)
                {
                    tItems += ((Thief)p).StolenItems.Count();
                }
                if (p is Police)
                {
                    pItems += ((Police)p).SeizedItems.Count();
                }
            }


            Console.SetCursorPosition(0, 26);
            Console.WriteLine("=STATISTICS===========================================================================================");
            Console.WriteLine("Robbed Citizens: " + RobbedCitizens);
            Console.WriteLine("Arested Thiefs: " + ArestedThiefs);
            Console.WriteLine("Citizens have " + cItems + " items in total   ");
            Console.WriteLine("Police have " + pItems + " items in total   ");
            Console.WriteLine("Thiefs have " + tItems + " items in total   ");


        }
        public void DisplayNews()
        {
            Console.SetCursorPosition(0, 32);
            Console.WriteLine("=NEWS FEED============================================================================================");

            int row = 33;
            for (int i = NewsFeed.Count; i > 0; i--)
            {
                if (NewsFeed.Count - i < 5)
                {
                    Console.SetCursorPosition(0, row);
                    for (int j = 0; j < 100; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(0, row);
                    Console.Write(i + ": " + NewsFeed[i - 1]);
                    row++;
                }
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
        public void PersonLogic(List<Person> persons, Prison prison)
        {
            foreach (Person person in persons)
            {
                DetectPersonCollision(persons, person, prison);

                for (int i = 0; i < persons.Count; i++)
                {
                    if (persons[i] != person && person.PosX == persons[i].PosX && person.PosY == persons[i].PosY && person.MoveX == persons[i].MoveX && person.MoveY == persons[i].MoveY)
                    {
                        person.GetMovment();
                    }
                }

                if (person is not Thief)
                {
                    Console.SetCursorPosition(person.PosX, person.PosY);
                    person.Move(100, 25, 1, 1);

                    Console.Write(" ");
                    DisplayPerson(person);
                }
                else if (!((Thief)person).IsPrisoned)
                {
                    Console.SetCursorPosition(person.PosX, person.PosY);
                    person.Move(100, 25, 1, 1);

                    Console.Write(" ");
                    DisplayPerson(person);
                }
            }
        }
        public void DisplayCity(List<Person> persons)
        {
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
        public void DetectPersonCollision(List<Person> persons, Person person, Prison prison)
        {
            foreach (Person person2 in persons)
            {
                if (person.PosX == person2.PosX && person.PosY == person2.PosY)
                {
                    if ((person is Thief && person2 is Citizen) || (person2 is Thief && person is Citizen))
                    {
                        if (person is Thief && person2 is Citizen)
                        {
                            ((Thief)person).Steal(person2 as Citizen, this);
                        }
                        else
                        {
                            ((Thief)person2).Steal(person as Citizen, this);
                        }
                        PersonsMet = true;
                        return;
                    }
                    if ((person is Thief && person2 is Police) || (person2 is Thief && person is Police))
                    {
                        if (person is Thief && person2 is Police)
                        {
                            ((Police)person2).Seize(person as Thief, this, prison);
                        }
                        else
                        {
                            ((Police)person).Seize(person2 as Thief, this, prison);
                        }
                        PersonsMet = true;
                        return;
                    }
                    if ((person is Citizen && person2 is Police) || (person2 is Citizen && person is Police))
                    {
                        if (person is Citizen)
                        {
                            NewsFeed.Add($"{person.Name} says hello to {person2.Name}");
                        }
                        else
                        {
                            NewsFeed.Add($"{person2.Name} says hello to {person.Name}");
                        }
                        PersonsMet = true;
                        return;
                    }
                }
            }
        }
    }
}
