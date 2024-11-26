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
    public void Move(Point p, Creature creature){ // przeniesienie stwora między dwoma punktami
        if(creaturesAtPoints.ContainsKey(p)){
            creaturesAtPoints[p].Add(creature);
        }
        creaturesAtPoints[p] = [creature];
    }
    public string At(Point p){
        if (creaturesAtPoints.ContainsKey(p)){return $"Na tych koordynatach są takie stwory: {creaturesAtPoints[p]}";}
        throw new Exception("Na podanym punkcie nie ma stworów");
    }
}