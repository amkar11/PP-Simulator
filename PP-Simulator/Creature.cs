
    public abstract class Creature
    {
        private string? name;
        private int level;
        public abstract int power {get;}
        public string? Name
        {
            get { return name; }
            init
            {
                if (value != null)
                {
                    name = value.Trim();
                    if (name.Length < 3)
                    {
                        while (name.Length < 3) { name += "#"; }
                    }
                    if (name.Length > 25)
                    {
                        name = name.Substring(0, 25);
                        name = name.Trim();
                        if (name.Length < 3)
                        {
                            while (name.Length != 3) { name += "#"; }
                        }
                    }
                    name = char.ToUpper(name[0]) + name.Substring(1);
                }
            }
        }
        public int Level
        {
            get { return level; }
            init
            {
                if (value < 1) { level = 1; }
                else if (value > 10) { level = 10; }
                else level = value;
            }
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
        public string Info => $"{name} [{level}]";
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
