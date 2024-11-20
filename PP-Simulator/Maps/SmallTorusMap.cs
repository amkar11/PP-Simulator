using System.Drawing;
using System.Security.Cryptography.X509Certificates;

public class SmallTorusMap : Map
{
    public readonly int Size;
    public SmallTorusMap(int size){
        if (size < 5 || size > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20.");
            }
        Size = size;
    }

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X <= Size - 1 && p.Y >= 0 && p.Y <= Size - 1;
    }

    public override Point Next(Point p, Direction d)
    {
        if (Exist(p))
        {
            p = p.Next(d);
            if (p.X > Size-1) { p = new Point(0, p.Y); }
            if (p.X < 0) { p = new Point(Size - 1, p.Y); }
            if (p.Y > Size-1) { p = new Point(p.X, 0); }
            if (p.Y < 0) { p = new Point(p.X, Size - 1); }
            return p;
            }
        return p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (Exist(p))
        {
            p = p.NextDiagonal(d);
            if (p.X > Size-1) { p = new Point(0, p.Y); }
            if (p.X < 0) { p = new Point(Size - 1, p.Y); }
            if (p.Y > Size - 1) { p = new Point(p.X, 0); }
            if (p.Y < 0) { p = new Point(p.X, Size - 1); }
            return p;
            }
        return p;
    }
}