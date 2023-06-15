namespace GRADE_CALCULATOR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("!! GRADE CALCULATOR !! ");

            Console.WriteLine("Enter The Number of Subjects:");
            int num = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[num];

            for (int i = 0; i < array.Length; i++)
            {

                Console.WriteLine("Enter The Subject Marks: ");
                array[i] = Convert.ToInt32(Console.ReadLine());

            }

            int sum = 0;
            Console.WriteLine("Sum of The Marks: ");
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];

            }

            Console.WriteLine(sum);

            int Avg = sum / num;
            Console.WriteLine("Average of The Marks: ");
            Console.WriteLine(Avg);

            Console.WriteLine("Grade Of the student: ");

            if (Avg > 90)
            {
                Console.WriteLine("A");
            }

            else if (Avg > 80 & Avg < 89)
            {
                Console.WriteLine("B");
            }

            else if (Avg > 70 & Avg < 79)
            {
                Console.WriteLine("C");
            }

            else if (Avg > 60 & Avg < 69)
            {
                Console.WriteLine("D");
            }
            else
            {
                Console.WriteLine("F");
            }


        }
    }
}