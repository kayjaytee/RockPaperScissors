

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
                Console.WriteLine("[2] Test SQL Connection: User");
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
                        Console.WriteLine("Running SQLClient: User..");
                        TableDatabaseConnection.SqlToConsole();
                        Console.WriteLine("Finished");


                        break;
                    case 3:
                        
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error Message:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.Message);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error Source:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.Source);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error StackTrace:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.StackTrace);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error InnerException:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.InnerException);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error Data:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.Data);

                Console.ForegroundColor = ConsoleColor.Gray;

                Console.ReadLine();
                Console.Clear();
                Menu();
            }

        }

        private void PlayGame()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("GAME START");
            Console.ForegroundColor = ConsoleColor.Gray;

            string player1 = "";
            string player2 = "";


            int rounds = 0;
            int bestof = 0;

            rounds++;
            Console.WriteLine("Round: " + rounds);

            while (player1 != "ROCK" && player1 != "PAPER" && player1 != "SCISSOR")
            {
                Console.WriteLine("Please type in any of the three: ");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("ROCK");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("PAPER");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("SCISSOR");

                Console.ForegroundColor = ConsoleColor.Gray;
                player1 = Console.ReadLine();
                player1 = player1.ToUpper();
                Console.Clear();

            }

            Console.WriteLine("Player 1 chose: " + player1);

            while (player2 != "ROCK" && player2 != "PAPER" && player2 != "SCISSOR")
            {

                Console.WriteLine("Please type in any of the three: ");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("ROCK");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("PAPER");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("SCISSOR");

                Console.ForegroundColor = ConsoleColor.Gray;
                player2 = Console.ReadLine();
                player2 = player2.ToUpper();
                Console.Clear();

            }
            Console.WriteLine("Player 2 chose: " + player2);

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
