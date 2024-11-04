using System.Security.Cryptography.X509Certificates;

namespace Polis_och_Tjuv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Game game = new Game();

            List<Person> persons = new List<Person>();
            Prison prison = new Prison();

            List<string> name = new List<string> { "Adam", "Bertil", "Cesar", "David", "Erik", "Filip", "Gustav", "Henrik", "Ivar", "Johan", "Kalle", "Ludvig", "Martin", "Niklas", "Olof", "Petter", "Qvintus", "Rudolf", "Sigurd", "Tore", "Urban", "Viktor", "Wilhelm", "Xerxes", "Yngve", "Zorro" };
            Queue<string> names = new Queue<string>(name);


            for (int i = 0; i < 8; i++)
            {
                Citizen citizen = new Citizen("Citizen " + names.Dequeue());
                Thief thief = new Thief("Thief " + names.Dequeue());
                Police police = new Police("Police " + names.Dequeue());
                persons.Add(citizen);
                persons.Add(thief);
                persons.Add(police);
            }

            game.DisplayCity();
            game.DisplayStatistics(persons);
            game.DisplayNews();
            prison.DisplayPrison();
            while (true)
            {
                foreach (Person person in persons)
                {
                    game.PersonMove(persons, person);
                    game.DetectPersonCollision(persons, prison, person);
                }

                prison.ReleasePrisoner(persons, game);
                prison.DisplayPrisoners();

                if (game.PersonsMet)
                {
                    game.DisplayStatistics(persons);
                    game.DisplayNews();
                    Thread.Sleep(1000);
                    game.PersonsMet = false;
                }
                Thread.Sleep(200);
            }
        }
    }
}
