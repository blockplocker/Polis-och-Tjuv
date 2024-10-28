namespace Polis_och_Tjuv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            Game game = new Game();

            List<Person> persons = new List<Person>();

            for(int i = 0; i < 8; i++)
            {
                Citizen citizen = new Citizen("Citizen");
                Thief thief = new Thief("Thief");
                Police police = new Police("Police");
                persons.Add(citizen);
                persons.Add(thief);
                persons.Add(police);
            }

            game.DisplayCity(persons);
            game.DisplayNews();
            while (true)
            {
                //game.DetectPersonCollision(persons);
                game.PersonLogic(persons);
                if (game.PersonsMet)
                {
                    
                    Console.Clear();

                    game.DisplayCity(persons);

                    game.DisplayNews();
                    
                    
                    game.PersonLogic(persons);
                    
                    Thread.Sleep(2000);
                    game.PersonsMet = false;
                }
                Thread.Sleep(200);

            }
        }
    }
}
