using System;

namespace AREA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            rectangle rect = new rectangle();
            rect.Area();
            rect = new Circle();
            rect.Area();

        }
    }
    public class rectangle
    {
        public double length;
        public double breath;
        
        public virtual void Area()
        {
            Console.Write("Enter The Length:");
            length = int.Parse(Console.ReadLine());
            Console.Write("Enter The Breath:");
            breath = int.Parse(Console.ReadLine());

            Console.Write("The Area of rectangle:");
            Console.WriteLine(length * breath);

            Console.WriteLine(" ");
        }
        

    }

    public class Circle : rectangle
    {
        public double radius;
        public  override void Area()
        {

            Console.Write("Enter The Radius:");
            radius = int.Parse(Console.ReadLine());

            Console.Write("The Area of Circle is:");
            Console.WriteLine(3.14 * radius * radius);
        }

    }
}
 