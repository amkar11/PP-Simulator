using System.Diagnostics.Metrics;
using System.Net.Http.Headers;

public class Elf : Creature 
{
    private int agility;
    public override int power => 8 * Level + 2 * Agility;
    public int Agility{
        get {return agility;}
        init{agility = Validator.Limiter(value, 1, 10);}
    }

    public void Sing() => Console.WriteLine($"{Name} is singing.");
    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
        {
            Agility = agility;
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
    public override string Info => $"{Name} [{Level}] [{Agility}]";
}