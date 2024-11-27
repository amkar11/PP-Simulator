using System;
using System.Collections.Generic;
using System.Text;
public class MapVisualizer
{
    private SmallMap _map;

    public MapVisualizer(SmallMap map)
    {
        _map = map;
        Console.OutputEncoding = Encoding.UTF8;
    }

   public void Draw()
{
    Console.Write(Box.TopLeft);
    for (int i = 0; i < _map.Size - 1; i++)
    {
        Console.Write(Box.Horizontal);
        Console.Write(Box.TopMid);
    }
    Console.WriteLine(Box.Horizontal + Box.TopRight);

    for (int y = 0; y < _map.Size; y++)
    {
        for (int x = 0; x < _map.Size; x++)
        {
            Point currentPoint = new Point(x, y);

            Console.Write(Box.Vertical);

            if (_map.IsOccupied(currentPoint))
            {
                var creatures = _map.GetCreaturesAt(currentPoint);
                Console.Write(creatures.Count > 1 ? "X" : creatures[0] is Orc ? 'O' : 'E');
            }
            else
            {
                Console.Write(' ');
            }
        }
        Console.WriteLine(Box.Vertical);

        if (y < _map.Size - 1)
        {
            Console.Write(Box.MidLeft);
            for (int i = 0; i < _map.Size - 1; i++)
            {
                Console.Write(Box.Horizontal);
                Console.Write(Box.Cross);
            }
            Console.WriteLine(Box.Horizontal + Box.MidRight);
        }
    }

    Console.Write(Box.BottomLeft);
    for (int i = 0; i < _map.Size - 1; i++)
    {
        Console.Write(Box.Horizontal);
        Console.Write(Box.BottomMid);
    }
    Console.WriteLine(Box.Horizontal + Box.BottomRight);
}
}
