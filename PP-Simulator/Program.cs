using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace PP_Simulator;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
          
    Lab5a();
    }
   public static void Lab5a(){
            Rectangle rectangle = new Rectangle(6, 7, 12, 13);
            Console.WriteLine(rectangle);
            Rectangle chudy_rectangle = new Rectangle(6, 7, 6, 13);
            Rectangle zly_rectangle = new Rectangle(6, 7, 5, 13);
            Console.WriteLine(zly_rectangle);
            Point rectangle_point = new(8 ,11);
            Point rectangle_point1 = new(7, 14);
            Console.WriteLine(rectangle.Contains(rectangle_point));
            Console.WriteLine(rectangle.Contains(rectangle_point1));
        }
    
}
