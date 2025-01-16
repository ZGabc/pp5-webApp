namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; init; }

    public int SizeY { get; init; }

    private readonly Rectangle _rectangle;

    public Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
            throw new ArgumentOutOfRangeException("Minimum size = 5");

        SizeX = sizeX;
        SizeY = sizeY;
        _rectangle = new(0, 0, SizeX - 1, SizeY - 1);
    }

    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public bool Exists(Point p) => _rectangle.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);

    public abstract void Add(Creature creature, Point position);

    public abstract void Remove(Creature creature, Point position);

    public void Move(Creature creature, Point oldPosition, Point newPosition)
    {
        Remove(creature, oldPosition);
        Add(creature, newPosition);
    }

    public abstract List<Creature>? At(int posX, int posY);

    public abstract List<Creature>? At(Point position);
}
