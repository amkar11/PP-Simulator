public class SmallMap : Map{
    private Dictionary<Point, List<Creature>> creaturesAtPoints;
    public SmallMap(int size) : base(size)
        {
            if (size > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20.");
            }
            creaturesAtPoints = new Dictionary<Point, List<Creature>>();
        }
    public void Add(Point p, Creature creature)
    {
        if (!creaturesAtPoints.ContainsKey(p))
        {
            creaturesAtPoints[p] = new List<Creature>();
        }
        creaturesAtPoints[p].Add(creature);
    }

    public void Remove(Point p, Creature creature)
    {
        if (creaturesAtPoints.ContainsKey(p))
        {
            creaturesAtPoints[p].Remove(creature);
            if (creaturesAtPoints[p].Count == 0)
            {
                creaturesAtPoints.Remove(p);
            }
        }
    }
    public bool IsOccupied(Point p)
    {
        return creaturesAtPoints.ContainsKey(p) && creaturesAtPoints[p].Count > 0;
    }

    public List<Creature> GetCreaturesAt(Point p)
    {
        if (creaturesAtPoints.ContainsKey(p))
        {
            return new List<Creature>(creaturesAtPoints[p]);
        }
        return new List<Creature>();
    }
    public void Move(Point from, Point to, Creature creature)
    {
        Remove(from, creature);
        Add(to, creature);
    }

    public string At(Point p)
    {
        if (creaturesAtPoints.ContainsKey(p))
        {
            var creatures = string.Join(", ", creaturesAtPoints[p]);
            return $"W tym punkcie są takie stwory: {creatures}";
        }
        return "W tym punkcie nie ma stworów";
    }
}