public abstract class SmallMap : Map
{

    private readonly List<Creature>? [,] _fields;
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException("Szerokość mapy musi wynosić maksymalnie 20.");
        if (sizeY > 20) throw new ArgumentOutOfRangeException("Długość mapy musi wynosić maksymalnie 20.");

        _fields = new List<Creature>?[sizeX, sizeY];
    }
    protected override List<Creature>?[,] Fields => _fields;
}