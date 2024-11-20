namespace Simulator.Maps
{
    public class SmallSquareMap : Map
    {
        public int Size { get; }
        public Point point{
            get {return point;}
            set {
                if (point.X < 0 || point.Y < 0){throw new ArgumentOutOfRangeException("Proszę podać wartości równe lub powyżej 0");}
            }
        }

        public SmallSquareMap(int size)
        {
            if (size < 5 || size > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20.");
            }

            Size = size;
        }

        public override bool Exist(Point point)
        {
            return point.X >= 0 && point.X < Size - 1 && point.Y >= 0 && point.Y < Size - 1;
        }

        public override Point Next(Point p, Direction d)
        { 
            if (Exist(p)){
                return p.Next(d);
            }
            return p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            if (Exist(p)){
                return p.NextDiagonal(d);
            }
            return p;
        }
    }
}
