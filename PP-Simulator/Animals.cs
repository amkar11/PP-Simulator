
public class Animals
{
    private string? description;
    public string? Description{
        get {return description;}
        init {
            if (value!= null){
                description = value.Trim();
                if (description.Length < 3){
                    while (description.Length !=3){description+="#";}
                }
                if (description.Length > 15){
                    description = description.Substring(0, 15);
                    description = description.Trim();
                    if (description.Length < 3){
                    while (description.Length !=3){description+="#";}
                }
                }
                description = char.ToUpper(description[0]) + description.Substring(1);
                }
             }
    }
    public uint Size { get; set; } = 3;
    public Animals(string description, uint size)
    {
        Description = description;
        Size = size;
    }
    public Animals() {}
    public string Info => $"{description} [{Size}]";
}