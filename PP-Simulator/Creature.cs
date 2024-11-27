public abstract class Creature
{
    private string? name;
    private int level;
    public SmallMap? map;
    public Point position;

    public abstract int power { get; }
    public string? Name
    {
        get { return name; }
        init { name = Validator.Shortener(value, 3, 25, '#'); }
    }
    public int Level
    {
        get { return level; }
        init { level = Validator.Limiter(value, 1, 10); }
    }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature() { }

    public void AssignToMap(SmallMap map, Point startPosition)
    {
        if (this.map != null) { throw new Exception("Существо уже привязано к карте."); }
        this.map = map;
        position = startPosition;
        map.Add(startPosition, this);
    }

    public void Upgrade()
    {
        if (level < 10) { level += 1; }
    }

    public abstract string Info { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    public abstract string Greeting();

    public void Go(Direction direction)
    {
        if (map == null)
        {
            throw new Exception("Существо не привязано к карте.");
        }

        Point newPosition = map.Next(position, direction);

        Console.WriteLine($"{GetType().Name.ToUpper()}: {Name} [{position.X}][{position.Y}] ({position.X + 1}, {position.Y + 1}) идет {direction}.");

        map.Move(position, newPosition, this);
        position = newPosition;
    }
}


    
