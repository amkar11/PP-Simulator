public interface IMappable
{
    public char Symbol { get; }
    string Info { get; }
    Point position { get; }
    void AssignToMap(Map map, Point startPosition);
    void Go(Direction direction);
}