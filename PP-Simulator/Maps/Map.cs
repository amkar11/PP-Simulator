/// <summary>
/// Map of points.
/// </summary>
public class Map
{
    public int Size { get; }
    public Map(int size)
        {
            if (size < 5)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20.");
            }

            Size = size;
        }
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p){
        return p.X >= 0 && p.X <= Size - 1 && p.Y >= 0 && p.Y <= Size - 1;
    }
    
    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public virtual Point Next(Point p, Direction d){
        if (Exist(p)){
                p = p.Next(d);
                if (p.X > Size - 1 || p.X < 0 || p.Y > Size - 1 || p.Y < 0) {throw new ArgumentOutOfRangeException("Jedna z wartości przekroczyła Size lub stała mniejsza od zera");}
            }
            return p;
    }

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public virtual Point NextDiagonal(Point p, Direction d){
        if (Exist(p)){
                p = p.NextDiagonal(d);
                if (p.X > Size - 1 || p.X < 0 || p.Y > Size - 1 || p.Y < 0) {throw new ArgumentOutOfRangeException("Jedna z wartości przekroczyła Size lub stała mniejsza od zera");}
            }
            return p;
    }
}