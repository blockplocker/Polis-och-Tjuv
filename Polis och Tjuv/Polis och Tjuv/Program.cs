namespace Polis_och_Tjuv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            List<Person> persons = new List<Person>();

            Citizen citizen = new Citizen("Citizen", "I'm a citizen");
            Citizen citizen2 = new Citizen("Citizen", "I'm a citizen");
            Thief thief = new Thief("Thief", "I'm a thief");
            Police police = new Police("Police", "I'm a police");

            persons.Add(citizen);
            persons.Add(citizen2);
            persons.Add(thief);
            persons.Add(police);

            thief.Steal(citizen, game);
            police.Seize(thief, game);

            while (true)
            {
                Console.Clear();
                foreach (Person person in persons)
                {

                    person.Move();

                }
                game.DisplayCity(persons);

                game.DisplayNews();
                Console.ReadKey();

            }
        }
    }
}
