using System.Diagnostics.Metrics;
using System.Net.Http.Headers;

public class Elf : Creature 
{
    private int agility;
    public override int power => 8 * Level + 2 * Agility;
    public int Agility{
        get {return agility;}
        init{
            if (value < 1) { agility = 1; }
                else if (value > 10) { agility = 10; }
                else agility = value;
        }

    }

    public void Sing() => Console.WriteLine($"{Name} is singing.");
    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
        {
            this.agility = agility;
        }
    public Elf() {}
    private int counter = 1;
    public override void SayHi(){
        if (counter % 3 == 0 && agility < 10){
            agility+=1;
        }
        counter+=1;
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    }
}