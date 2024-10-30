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

            for (int i = 0; i < 8; i++)
            {
                Citizen citizen = new Citizen("Citizen");
                Thief thief = new Thief("Thief");
                Police police = new Police("Police");
                persons.Add(citizen);
                persons.Add(thief);
                persons.Add(police);
            }

            game.DisplayCity(persons);
            game.DisplayStatistics(persons);
            game.DisplayNews();
            prison.DisplayPrison();
            while (true)
            {
                //game.DetectPersonCollision(persons);
                game.PersonLogic(persons, prison);
                prison.ReleasePrisoner(persons, game);
                prison.DisplayPrisoners();

                if (game.PersonsMet)
                {

                    // Console.Clear();

                    //game.DisplayCity(persons);
                    game.DisplayStatistics(persons);
                    game.DisplayNews();


                   // game.PersonLogic(persons, prison);
                    //prison.DisplayPrison();
                    //prison.DisplayPrisoners();

                    Thread.Sleep(1000);
                    game.PersonsMet = false;
                }
                Thread.Sleep(200);

            }
        }
    }
}
