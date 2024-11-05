
    public abstract class Creature
    {
        private string? name;
        private int level;
        public abstract int power {get;}
        public string? Name
        {
            get { return name; }
            init {name = Validator.Shortener(value, 3, 25, '#');}
        }
        public int Level
        {
            get { return level; }
            init{ level = Validator.Limiter(value, 1, 10); }
        }
        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }
        public Creature() { }
        public void Upgrade()
        {
            if (level < 10) { level += 1; }
        }
        public abstract string Info {get;}
        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
        public abstract void SayHi();


        public void Go(Direction movement)
    {
        string newMovement = movement.ToString();
        Console.WriteLine($"{Name} goes {newMovement.ToLower()}");
    }

    public void Go(Direction[] movements)
    {
        foreach (var direction in movements)
        {
            Go(direction); 
        }
    }

    public void Go(string movements)
    {
        Direction[] directions = DirectionParser.Parse(movements);
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string[] movements)
    {
        foreach (var movement in movements)
        {
            if (Enum.TryParse(movement, true, out Direction direction))
            {
                Go(direction);
            }
        }
    }
}
