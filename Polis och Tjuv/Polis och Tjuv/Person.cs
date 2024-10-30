using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polis_och_Tjuv
{
    internal class Person
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public string Name { get; set; }
        public int MoveX { get; set; }
        public int MoveY { get; set; }

        public Person(string name)
        {
            GetPos(100, 25, 1, 1);
            Name = name;

            GetMovment();
        }
        public void GetMovment()
        {
            Random random = new Random();
            MoveX = 0;
            MoveY = 0;
            while (MoveX == 0 && MoveY == 0)
            {
                MoveX = random.Next(-1, 2);
                MoveY = random.Next(-1, 2);
            }
        }
        public void Move(int xMax, int yMax, int xMin, int yMin)
        {
            while (true)
            {
                PosX += MoveX;
                PosY += MoveY;

                if (PosX > xMax || PosX < xMin || PosY < yMin || PosY > yMax)
                {
                    PosX -= MoveX;
                    PosY -= MoveY;
                    GetMovment();
                }
                else
                {
                    break;
                }
            }
        }


        public void GetPos(int xMax, int yMax, int xMin, int yMin)
        {
            Random rand = new Random();
            PosX = rand.Next(xMin, xMax);
            PosY = rand.Next(yMin, yMax);
        }
    }
}
