
    public abstract class Creature : IMappable
    {
        private string? name;
        private int level;
        public Map? map;
        public Point position { get; private set;}
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
        public void AssignToMap(Map map, Point startPosition)
        {
            if (this.map!=null) {throw new Exception("Stwór jest już przypisany do mapy");}
            this.map = map;
            position = startPosition;
        }
        public void Upgrade()
        {
            if (level < 10) { level += 1; }
        }
        public abstract string Info {get;}
        public abstract char Symbol { get; }
        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
        public abstract string Greeting();


        public void Go(Direction direction)
        {
        if (map == null)
            return;
        Point nextPosition = map.Next(position, direction);
        map.Move(this, position, nextPosition);
        position = nextPosition;
        }
}


    
