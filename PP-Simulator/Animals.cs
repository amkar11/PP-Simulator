
public class Animals
{
    private string? description;
    public string? Description{
        get {return description;}
        init {Validator.Shortener(description=value, 3, 15, '#');}
    }
    public uint Size { get; set; } = 3;
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