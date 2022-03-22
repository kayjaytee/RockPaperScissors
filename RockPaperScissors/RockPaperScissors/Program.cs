namespace RockPaperScissors
{


    internal class Game
    {

        private void Menu()
        {
            try //Gjorde en try-catch istället för en .parse så länge, får se om en parse passar bättre
            {

                //Enda funktionalitet med menyn än så länge är hänvisning till Play(); metoden
                Console.WriteLine("~ ROCK PAPER SCISSORS ~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("[1] Play Game");
                Console.WriteLine("[2] Read Rules");
                Console.WriteLine("[3] Exit");

                string input = Console.ReadLine();
                byte result = Convert.ToByte(input);
                switch (result)
                {
                    case 0:
                        break;

                    case 1:
                        PlayGame();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR");
                Console.Clear();
                Menu();
            }

        }

        private void PlayGame()
        {
            Console.WriteLine("WELCOME TO THE GAMEZZZZ");

            string player1 = "";
            string player2 = "";


            int rounds = 0;
            int bestof = 0;

            rounds++;
            Console.WriteLine("Round: " + rounds);

            while (player1 != "ROCK" && player1 != "PAPER" && player1 != "SCISSOR")
            {
                player1 = Console.ReadLine();
                player1 = player1.ToUpper();

                Console.WriteLine("Player 1 chose: " + player1);
            }

            while (player2 != "ROCK" && player2 != "PAPER" && player2 != "SCISSOR")
            {
                player2 = Console.ReadLine();
                player2 = player2.ToUpper();

                Console.WriteLine("Player 2 chose: " + player2);
            }

            Console.WriteLine("Player 1 = " + player1);
            Console.WriteLine("Player 2 = " + player2);

            switch (player1)
            {
                case "ROCK":
                    switch (player2)
                    {
                        case "ROCK":
                            Console.WriteLine("DRAW");
                            break;
                        case "PAPER":
                            Console.WriteLine("Player 2 Wins!");
                            break;
                        case "SCISSOR":
                            Console.WriteLine("Player 1 Wins!");
                            break;
                    }
                    break;
                case "PAPER":
                    switch (player2)
                    {
                        case "ROCK":

                            Console.WriteLine("Player 1 Wins!");
                            break;
                        case "PAPER":
                            Console.WriteLine("DRAW");
                            break;
                        case "SCISSOR":
                            Console.WriteLine("Player 2 Wins!");
                            break;
                    }
                    break;
                case "SCISSOR":
                    switch (player2)
                    {
                        case "ROCK":

                            Console.WriteLine("Player 2 Wins!");
                            break;
                        case "PAPER":
                            Console.WriteLine("Player 1 Wins!");
                            break;
                        case "SCISSOR":
                            Console.WriteLine("DRAW");
                            break;
                    }
                    break;

            }


        }

        internal void Run()
        {
            Menu();
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var app = new Game();
            app.Run();




        }
    }




}
