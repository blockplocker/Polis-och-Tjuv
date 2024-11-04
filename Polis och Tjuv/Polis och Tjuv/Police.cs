using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Polis_och_Tjuv
{
    internal class Police : Person
    {
        public List<string> SeizedItems { get; set; }
        public Police(string name) : base(name)
        {
            SeizedItems = new List<string>();
        }

        public void Seize(Thief thief, Game game, Prison prison)
        {
            if (thief.StolenItems.Count > 0)
            {
                game.ArestedThiefs++;
                SeizedItems.AddRange(thief.StolenItems);
                game.NewsFeed.Add($"{Name} seized {SeizedItems.Count} items from {thief.Name}");

                prison.Prisoners.Add(thief);
                thief.IsPrisoned = true;

                thief.ReleaseDay = prison.Day + CalcDays(thief.StolenItems.Count);
                thief.GetPos(prison.MaxX, prison.MaxY, prison.MinX, prison.MinY);
                thief.StolenItems.Clear();
            }
            else
            {
                game.NewsFeed.Add($"{Name} checked {thief.Name} but found nothing");
            }
        }

        public int CalcDays(int itemsStolen)
        {
            return itemsStolen * 20;
        }

    }
}
