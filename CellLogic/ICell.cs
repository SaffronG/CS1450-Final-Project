namespace CellLogic;

public interface ICell
{
    public Location location { get; set; } // Struct storing the X and Y location data
    public Status status { get; set; } // Enum of Alive, and Dead
    public bool isSelected { get; set; } // For the GUI elements
    public abstract void Display(int width);
    public abstract bool DoesEvolve(CellAutomata automata);
    public abstract void ToggleStatus(bool condition);
    public abstract void Select();
}
