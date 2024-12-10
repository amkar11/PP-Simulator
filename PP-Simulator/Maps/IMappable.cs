public interface IMappable{
    void AssignToMap(Map map, Point startPosition);
    void Upgrade();
    void Go(Direction direction);
}