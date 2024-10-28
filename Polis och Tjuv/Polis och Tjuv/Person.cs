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
        public string  Name { get; set; }
        public int MoveX { get; set; }
        public int MoveY { get; set; }

        public Person(string name)
        {
            GetPos();
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
        public void Move()
        {
            while (true)
            {
                PosX += MoveX;
                PosY += MoveY;

                if (PosX > 100 || PosX < 1 || PosY < 1 || PosY > 25)
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


    public void GetPos()
        {
            Random rand = new Random();
            PosX = rand.Next(1, 100);
            PosY = rand.Next(1, 25);
        }
    }
}
