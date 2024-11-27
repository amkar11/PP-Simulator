using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace PP_Simulator;
using Simulator.Maps;
class Program
{
    static void Main(string[] args)
    {
        SmallMap map = new SmallMap(7);
        Creature orc = new Orc("Gorbag", 1);
        Creature elf = new Elf("Legolas", 1);

        List<Creature> creatures = new List<Creature> { orc, elf };
        List<Point> positions = new List<Point> { new Point(2, 2), new Point(2, 3) };

        // Example moves: down, up, left, right (can be parsed)
        string moves = "down up down up";

        Simulation simulation = new Simulation(map, creatures, positions, moves);

        Console.WriteLine("SIMULATION!");
        Console.WriteLine("Starting positions:");
        MapVisualizer visualizer = new MapVisualizer(map);
        visualizer.Draw();

        Console.WriteLine("Press any key to start simulation...");
        Console.ReadKey();

        while (!simulation.Finished)
        {
            simulation.Turn();
        }

        Console.WriteLine("Simulation complete.");
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
    public static void Lab5b()
    {
        SmallSquareMap map = new SmallSquareMap(10);

        Point p1 = new Point(5, 5);
        Console.WriteLine($"Point {p1} exists on the map: {map.Exist(p1)}"); 

        Point p2 = new Point(15, 5);
        Console.WriteLine($"Point {p2} exists on the map: {map.Exist(p2)}"); 

        Point nextPoint = map.Next(p1, Direction.Up);
        Console.WriteLine($"Next point from {p1} in Up direction: {nextPoint}");

        Point diagonalPoint = map.NextDiagonal(p1, Direction.Right);
        Console.WriteLine($"Next diagonal point from {p1} in Right direction: {diagonalPoint}");

        Point outsidePoint = new Point(9, 9);
        Point nextOutsidePoint = map.Next(outsidePoint, Direction.Right); 
        Console.WriteLine($"Next point from {outsidePoint} in Right direction (out of bounds): {nextOutsidePoint}");
    }
  
}
