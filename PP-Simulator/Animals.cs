
public class Animals : IMappable
{
    private string? description;
    public Map? map;
    public Point position { get; set;}
    public uint Size { get; set; } = 3;
    public virtual char Symbol => 'A';
    public string? Description
    {
        get {return description;}
        init {Validator.Shortener(description=value, 3, 15, '#');}
    }
    public void AssignToMap(Map map, Point startPosition)
    {
        if (this.map!=null) {throw new Exception("Stwór jest już przypisany do mapy");}
        this.map = map;
        position = startPosition;
    }
    public virtual void Go(Direction direction)
    {
    if (map == null)
        return;
    Point nextPosition = map.Next(position, direction);
    map.Move(this, position, nextPosition);
    position = nextPosition;
    }
    public Animals(string description, uint size)
    {
        Description = description;
        Size = size;
    }
    public Animals() {}
    public virtual string Info => $"{Description} [{Size}]";
    public override string ToString()
    {
        return $"{Description?.GetType()}: {Info}";
    }
}