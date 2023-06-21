
using System;

namespace LIST_PEROGRAM
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter Length Of the List:");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");

            List<Student> list = new List<Student>(num);

            for (int i = 0; i < num; i++)
            {
                Student numb = new Student();

                Console.Write("Enter The Name:");
                numb.name = Console.ReadLine();

                Console.Write("Enter The id:");
                numb.id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter The Age:");
                numb.age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter The hobby:");
                numb.hobby = Console.ReadLine();

                Console.WriteLine(" ");
                Console.WriteLine("**********************");
                Console.WriteLine(" ");

                list.Add(numb);

            }
            foreach (Student number in list)
            {
                Console.WriteLine(number.name + number.id  + number.age  + number.hobby);
                
            }
            Console.WriteLine();
        }
    }
    public class Student
    {

        public string name;
        public int id;
        public int age;
        public string hobby;

        public void student_data()
        {
            Console.WriteLine();
        }


    }

}


