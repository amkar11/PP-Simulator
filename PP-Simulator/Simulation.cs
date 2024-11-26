public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public SmallMap Map { get; } 
    
    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }  

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }
    
    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }
    
    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;
    
    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature {
        get{ }
    } 

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName { /* implement getter only */ } 

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures, 
        List<Point> positions, string moves) {
            if (creatures.Count == 0) {throw new Exception("Lista ze stworami ma zawierać przynajmniej jednego stwora");}
            if (creatures.Count != positions.Count) { throw new Exception ("Liczba startowych pozycji powinna odpowiadać liczbie stworów" );}
            for (int i = 0; i < creatures.Count; i++){
                creatures[i].AssignToMap(map, positions);
            }
        }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() { /* implement */ }
}