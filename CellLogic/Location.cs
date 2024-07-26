namespace CellLogic;

public struct Location
{
    public readonly int X;
    public readonly int Y;
    public Location(int X, int Y) {
        this.X = X;
        this.Y = Y;
    }
    public override string ToString() => $"({X}, {Y})";
}