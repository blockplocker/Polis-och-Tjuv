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

            thief.Steal(citizen, game);
            police.Seize(thief, game);

            game.DisplayCity(persons);
            game.DisplayNews();
            while (true)
            {
                //game.DetectPersonCollision(persons);
                foreach (Person person in persons)
                {
                    Console.SetCursorPosition(person.PosX, person.PosY);
                    person.Move();
                    Console.Write(" ");
                    game.DisplayPerson(person);

                }
                if (game.PersonsMet)
                {
                Console.Clear();
                game.DisplayCity(persons);

                game.DisplayNews();

                }
                Thread.Sleep(200);

            }
        }
    }
}
