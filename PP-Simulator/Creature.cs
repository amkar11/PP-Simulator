
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
        public abstract string Greeting();


        public string Go(Direction movement) => $"{movement.ToString().ToLower()}";


    public string[] Go(Direction[] movements)
    {
        // Assuming 'Direction' has a meaningful ToString() implementation
        string[] result = new string[movements.Length];

        for (int i = 0; i < movements.Length; i++)
        {
            result[i] = Go(movements[i]);
        }

        return result;
    }
    public string[] Go(string movements)
    {
        Direction[] parsedDirections = DirectionParser.Parse(movements);
        return Go(parsedDirections);
    }
}

    
