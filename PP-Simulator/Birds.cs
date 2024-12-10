public class Birds : Animals
{
    public bool CanFly { get; set; } = true;
    public override char Symbol => CanFly ? 'B' : 'b';
    public Birds() { }
    public Birds(string description, uint size = 3, bool canFly = true) : base(description, size)
    {
        CanFly = canFly;
    }
    public override void Go(Direction direction)
    {
        if (map == null)
        {
            Console.WriteLine("Mapa nie jest przypisana.");
            return;
        }
        Point nextPosition = CanFly ? map.Next(map.Next(position, direction), direction) : map.NextDiagonal(position, direction); 
        map.Move(this, position, nextPosition);
        position = nextPosition;
    }

    public override string Info
    {
        get
        {
            string flyAbility = CanFly ? "fly+" : "fly-";
            return $"{Description} ({flyAbility}) <{Size}>";
        }
    }
}
