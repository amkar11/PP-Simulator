public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; } 
    
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
    public bool Finished {get; private set;} = false;
    
    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature => Creatures[moves_counter % Creatures.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => Moves[moves_counter].ToString().ToLower();

    private List<Direction>? parsed_moves {get; set;}
    private int moves_counter {get; set;} = 0;
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
                creatures[i].AssignToMap(map, positions[i]);
            }
            Creatures = creatures;
            Positions = positions;
            Moves = moves;
            Map = map;
        }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("The simulation is already finished.");
        }
        if (Moves.Length == 0)
        {
            Finished = true;
            return;
        }
        char currentMoveChar = Moves[moves_counter];
        var directions = DirectionParser.Parse(currentMoveChar.ToString());
        if (directions != null && directions.Count > 0)
        {
            var direction = directions[0];
            CurrentCreature.Go(direction);
        }
        moves_counter++;
        // Check if all moves are done
        if (moves_counter >= Moves.Length)
        {
            Finished = true;
        }
    }
}