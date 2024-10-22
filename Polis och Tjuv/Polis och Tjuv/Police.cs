using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polis_och_Tjuv
{
    internal class Police : Person
    {
        public List<string> SeizedItems { get; set; }

        public Police(int posX, int posY, string name, string sayHello) : base(posX, posY, name, sayHello)
        {
            SeizedItems = new List<string>();
        }

        public void Seize(Thief thief, Game game)
        {
            game.ArestedThiefs++;
            SeizedItems.AddRange(thief.StolenItems);
            thief.StolenItems.Clear();
            game.NewsFeed.Add($"{Name} seized {SeizedItems.Count} items from {thief.Name}");
        }

    }
}
