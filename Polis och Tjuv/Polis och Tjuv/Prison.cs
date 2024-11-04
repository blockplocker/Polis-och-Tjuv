using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Polis_och_Tjuv
{
    internal class Prison
    {
        public int Day { get; set; }
        public List<Thief> Prisoners { get; set; }

        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public int MinX { get; set; }
        public int MinY { get; set; }

        public Prison()
        {
            Prisoners = new List<Thief>();
            Day = 0;
            MaxX = 125;
            MaxY = 16;
            MinX = 103;
            MinY = 1;
        }

        public void DisplayPrison()
        {
            string topRow = $"=PRISON==================";
            string row = $"|                       |";
            string bottomRow = $"=========================";

            Console.SetCursorPosition(102, 0);
            Console.Write(topRow);

            for (int i = 1; i < 17; i++)
            {
                Console.SetCursorPosition(102, i);
                Console.Write(row);
            }
            Console.SetCursorPosition(102, 17);
            Console.Write(bottomRow);
        }

        public void DisplayPrisoners()
        {
            foreach (Thief prisoner in Prisoners)
            {
                Console.SetCursorPosition(prisoner.PosX, prisoner.PosY);
                prisoner.Move(MaxX, MaxY, MinX, MinY);
                Console.Write(" ");
                Console.SetCursorPosition(prisoner.PosX, prisoner.PosY);
                Console.Write("T");
            }
        }

        public void ReleasePrisoner(List<Person> persons, Game game)
        {
            Day++;
            foreach (Thief prisoner in Prisoners.ToList())
            {
                if (prisoner.ReleaseDay == Day)
                {
                    Console.SetCursorPosition(prisoner.PosX, prisoner.PosY);
                    Console.Write(" ");
                    prisoner.IsPrisoned = false;
                    prisoner.GetPos(100, 25, 1, 1);
                    Prisoners.Remove(prisoner);
                    game.NewsFeed.Add(prisoner.Name + " has been released from prison");

                }
            }
        }
    }
}
