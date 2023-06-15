namespace NUMBER_GUESSING_GAME_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            int Guess = 0;
            int Guesses = 0;
            bool playAgain = true;
            string response;

            Console.WriteLine("!!WELCOME TO NUMBER GUESSING GAME!!");

            Random random = new Random();
           
            while (playAgain)
            {
                Guess = 0;
                Guesses = 0;
                num = random.Next(1, 10);
               /* Console.WriteLine(num);*/


                while (Guess != num)
                {

                    Console.WriteLine("Guess The Number Between 1-10 ");
                    Guess = Convert.ToInt32(Console.ReadLine());


                    if (Guess > num)
                    {
                        Console.WriteLine(Guess + " is Too High!!");
                    }
                    else if (Guess < num)
                    {
                        Console.WriteLine(Guess + " is Too Low!!");
                    }

                    Guesses++;

                }

                Console.WriteLine("NUMBER" + " " + num);
                Console.WriteLine("You Win!!");
                Console.WriteLine("Guesses:" + Guesses);

                Console.WriteLine("Would You Like To Play Again?(Y/N):" );
                response = Console.ReadLine();
                response = response.ToUpper();
                
                if (response == "Y")
                {
                    playAgain = true;
                }
                else
                {
                    playAgain = false;
                }

            }

            Console.WriteLine("Thanks For Playing!!");

            Console.ReadKey();


        }
    }
}