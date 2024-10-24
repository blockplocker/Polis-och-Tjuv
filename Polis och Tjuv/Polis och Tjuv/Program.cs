namespace Polis_och_Tjuv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            List<Person> persons = new List<Person>();

            Citizen citizen = new Citizen(10, 2, "Citizen", "I'm a citizen");
            Citizen citizen2 = new Citizen(10, 1, "Citizen", "I'm a citizen");
            Thief thief = new Thief(10, 10, "Thief", "I'm a thief");
            Police police = new Police(1, 20, "Police", "I'm a police");

            persons.Add(citizen);
            persons.Add(citizen2);
            persons.Add(thief);
            persons.Add(police);

            thief.Steal(citizen, game);
            police.Seize(thief, game);

            
            game.DisplayCity(persons);

            game.DisplayNews();

            // Testar för git - Naser

        }
    }
}
