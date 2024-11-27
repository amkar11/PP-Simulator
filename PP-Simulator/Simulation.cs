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
    /// Cyclic list of creatures' moves.
    /// </summary>
    public List<Direction> ParsedMoves { get; private set; }

    /// <summary>
    /// Indicates if the simulation has finished.
    /// </summary>
    public bool Finished { get; private set; } = false;

    /// <summary>
    /// Index of the current creature making a move.
    /// </summary>
    private int currentCreatureIndex = 0;

    /// <summary>
    /// Index of the current move.
    /// </summary>
    private int currentMoveIndex = 0;

    /// <summary>
    /// Simulation constructor.
    /// Throws errors if the creatures list is empty or if the number of creatures differs from the number of starting positions.
    /// </summary>
    public Simulation(SmallMap map, List<Creature> creatures, List<Point> positions, string moves)
    {
        if (creatures.Count == 0)
            throw new Exception("The list of creatures must contain at least one creature.");

        if (creatures.Count != positions.Count)
            throw new Exception("The number of starting positions must match the number of creatures.");

        Map = map;
        Creatures = creatures;

        // Assign creatures to their starting positions on the map
        for (int i = 0; i < creatures.Count; i++)
        {
            creatures[i].AssignToMap(map, positions[i]);
        }

        // Parse moves
        ParsedMoves = DirectionParser.Parse(moves);
        if (ParsedMoves.Count == 0)
            throw new Exception("No valid moves provided.");
    }
    

    /// <summary>
    /// Executes one turn of the simulation.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            Console.WriteLine("The simulation has already finished.");
            return;
        }

        // Get the current creature and direction
        Creature currentCreature = Creatures[currentCreatureIndex];
        Direction currentMove = ParsedMoves[currentMoveIndex];

        // Move the creature
        currentCreature.Go(currentMove);

        // Output the current move
        Console.WriteLine($"Turn {currentMoveIndex + 1}:");
        Console.WriteLine($"{currentCreature.GetType().Name.ToUpper()}: {currentCreature.Name} moves {currentMove}.");

        // Display the map after the move
        MapVisualizer visualizer = new MapVisualizer(Map);
        visualizer.Draw();

        // Update indexes for the next turn
        currentCreatureIndex = (currentCreatureIndex + 1) % Creatures.Count;
        currentMoveIndex++;

        // Check if all moves have been completed
        if (currentMoveIndex >= ParsedMoves.Count)
        {
            Finished = true;
            Console.WriteLine("The simulation has finished.");
        }
        else
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

