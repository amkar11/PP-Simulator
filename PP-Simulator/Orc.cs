using System.Diagnostics.Tracing;

public class Orc : Creature
{
    public int rage;
    public override int power => 7 * Level + 3 * rage;
    public int Rage{
        get {return rage;}
        init{
            if (value < 1) { rage = 1; }
                else if (value > 10) { rage = 10; }
                else rage = value;
        }

    }
    public void Hunt() => Console.WriteLine($"{Name} is hunting."); 
    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
        {
            this.rage = rage;
        }
    public Orc() {}
    private int counter = 1;
    public override void SayHi(){
        if (counter % 2 == 0  && rage<10){
            rage+=1;
        }
        counter+=1;
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
    }
}