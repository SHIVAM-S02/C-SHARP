using System.Drawing;

namespace my_c_sharp
{
    internal class Program
    {
        static void Main(string[] args)

        {

            Console.WriteLine("Enter the number:-");
            int num = Convert.ToInt32(Console.ReadLine());

            for (int row = 1; row <= num; row++)
            {
                if (row == 1)
                {
                    for (int column = 1; column <= num; column++)
                    {
                        Console.Write("* ");
                    }

                }

                if (row == num)
                {
                    for (int column = 1; column <= num; column++)
                    {
                        Console.Write("* ");
                    }
                    Console.WriteLine();
                }

                if (row == num / 2 + 1)
                {
                    for (int column = 1; column <= num; column++)
                    {
                        if (column == 1 || column == num)
                        {
                            Console.Write("* ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }


                    }
                    Console.WriteLine();
                }




                Console.WriteLine();
            }

        }
    }
}



