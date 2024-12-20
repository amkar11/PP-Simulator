public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; } 
    
    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<IMappable> Mappables { get; }  
    

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
    private List<Direction> filteredMoves { get; }
    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished {get; private set;} = false;
    
    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public IMappable CurrentMappable => Mappables[moves_counter % Mappables.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => filteredMoves.Count > moves_counter ? filteredMoves[moves_counter].ToString().ToLower() : string.Empty;

    private List<Direction>? parsed_moves {get; set;}
    private int moves_counter {get; set;} = 0;
    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables, 
        List<Point> positions, string moves) {
            if (mappables.Count == 0) {throw new Exception("Lista ze stworami ma zawierać przynajmniej jednego stwora");}
            if (mappables.Count != positions.Count) { throw new Exception ("Liczba startowych pozycji powinna odpowiadać liczbie stworów" );}
            for (int i = 0; i < mappables.Count; i++){
                mappables[i].AssignToMap(map, positions[i]);
            }
            Mappables = mappables;
            Positions = positions;
            Moves = moves;
            Map = map;
            filteredMoves = Moves
            .Select(c => DirectionParser.Parse(c.ToString().ToLower()))
            .Where(d => d != null && d.Count > 0)
            .Select(d => d[0])
            .ToList();
            if (filteredMoves.Count == 0)
            {
                throw new ArgumentException("Moves jest pusty.");
            }
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
        if (moves_counter >= filteredMoves.Count)
        {
            Finished = true;
            return;
        }
        Direction direction = filteredMoves[moves_counter];
        CurrentMappable.Go(direction);
        moves_counter++;
        // Check if all moves are done
        if (moves_counter >= filteredMoves.Count)
        {
            Finished = true;
        }
    }
        public SimulationState GetState()
    {
        var mappableStates = Mappables.Select(m => new MappableState(m, m.position)).ToList();
        return new SimulationState(moves_counter, mappableStates);
    }
}
