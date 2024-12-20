﻿using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace PP_Simulator;

using SimConsole;
using Simulator.Maps;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        BigBounceMap map = new(8, 6);
        List<IMappable> mappables = new() { new Orc("Gorbag"), new Elf("Elandor"), new Animals("Rabbits", 8), new Birds("Eagle", 14, true), new Birds("Ostrich", 2, false) };
        List<Point> points = new() { new(0, 0), new(0, 1), new(0, 2), new(0, 3), new(0, 4) };
        string moves = "ldurlllllllurddddddddddddddddddddd";
        Simulation simulation = new(map, mappables, points, moves);
        SimulationHistory history = new(simulation);
        MapVisualizer mapVisualizer = new(simulation.Map);
        while (!simulation.Finished)
        {
            mapVisualizer.Draw();
            Console.WriteLine("\nPress any key to make a move...");
            Console.ReadKey(true);
            Console.Write($"{simulation.CurrentMappable.Info} {simulation.CurrentMappable.position} goes {simulation.CurrentMoveName}\n");
            simulation.Turn();
        }
        mapVisualizer.Draw();
        Console.WriteLine("\nSimulation finished!");
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
