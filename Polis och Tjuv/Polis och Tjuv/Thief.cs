using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polis_och_Tjuv
{
    internal class Thief : Person
    {
        public List<string> StolenItems { get; set; }
        public bool InPrisoned { get; set; }

        public Thief(string name) : base(name)
        {
            StolenItems = new List<string>();
        }
        public void Steal(Citizen citizen, Game game)
        {
            if(citizen.Items.Count > 0)
            {
            game.RobbedCitizens++;
            int random = new Random().Next(0, citizen.Items.Count);
            StolenItems.Add(citizen.Items[random]);
            citizen.Items.RemoveAt(random);
            game.NewsFeed.Add($"{Name} stole {StolenItems[StolenItems.Count-1]} from {citizen.Name}");

            }
            else if (citizen.Items.Count == 0)
            {
                game.NewsFeed.Add($"{Name} tried to steal from {citizen.Name} but got nothing");
            }
        }

    }
}
