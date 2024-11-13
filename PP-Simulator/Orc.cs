using System.Diagnostics.Tracing;

public class Orc : Creature
{
    public int rage;
    public override int power => 7 * Level + 3 * rage;
    public int Rage{
        get {return rage;}
        init{ Validator.Limiter(rage = value, 1, 10); }

    }
    public string Hunt() => $"{Name} is hunting."; 
    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
        {
            Rage = rage;
        }
    public Orc() {}
    private int counter = 1;
    public override string Greeting(){
        if (counter % 2 == 0  && rage<10){
            rage+=1;
        }
        counter+=1;
        return $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";
    }
    public override string Info => $"{Name} [{Level}] [{Rage}]";
}