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

        public Police(string name ) : base(name)
        {
            SeizedItems = new List<string>();
        }

        public void Seize(Thief thief, Game game)
        {
            if(thief.StolenItems.Count > 0)
            {
            game.ArestedThiefs++;
            SeizedItems.AddRange(thief.StolenItems);
            thief.StolenItems.Clear();
            game.NewsFeed.Add($"{Name} seized {SeizedItems.Count} items from {thief.Name}");
            }
            else
            {
                game.NewsFeed.Add($"{Name} checked {thief.Name} but found nothing");
            }
        }

    }
}
