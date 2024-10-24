namespace Polis_och_Tjuv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Game game = new Game();

            List<Person> persons = new List<Person>();

            Citizen citizen = new Citizen("Citizen", "I'm a citizen");
            Citizen citizen2 = new Citizen("Citizen", "I'm a citizen");
            Thief thief = new Thief("Thief", "I'm a thief");
            Thief thief1 = new Thief("Thief", "I'm a thief");
            Thief thief2 = new Thief("Thief", "I'm a thief");
            Thief thief3 = new Thief("Thief", "I'm a thief");
            Thief thief4 = new Thief("Thief", "I'm a thief");
            Thief thief5 = new Thief("Thief", "I'm a thief");
            Thief thief6 = new Thief("Thief", "I'm a thief");
            Thief thief7 = new Thief("Thief", "I'm a thief");
            Thief thief8 = new Thief("Thief", "I'm a thief");
            Thief thief9 = new Thief("Thief", "I'm a thief");
            Police police = new Police("Police", "I'm a police");

            persons.Add(citizen);
            persons.Add(citizen2);
            persons.Add(thief);
            persons.Add(thief2);
            persons.Add(thief3);
            persons.Add(thief4);
            persons.Add(thief5);
            persons.Add(thief6);
            persons.Add(thief7);
            persons.Add(thief8);
            persons.Add(thief9);
            persons.Add(police);

            

            game.DisplayCity(persons);
            game.DisplayNews();
            while (true)
            {
                game.DetectPersonCollision(persons);
                game.DisplayAllPersons(persons);
                if (game.PersonsMet)
                {
                Console.Clear();
                game.DisplayCity(persons);

                game.DisplayNews();
                    game.DisplayAllPersons(persons);
                    Thread.Sleep(1000);
                }
                    game.PersonsMet = false;
                Thread.Sleep(200);

            }
        }
    }
}
