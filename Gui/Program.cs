using CellLogic;

namespace GUI;

public class Program {
    public static void Main(string[] args) {
        Console.CursorVisible = false;
        CellAutomata logic = new CellAutomata(int.Parse(args[0]), int.Parse(args[1]));
        GUIFunctions gui = new GUIFunctions(logic);
        
        Console.Clear();
        gui.Display(logic);
    }
}

public class GUIFunctions {
    public readonly CellAutomata logic;
    public Location current;

    public GUIFunctions(CellAutomata automata) {
        logic = automata;
        Console.SetCursorPosition(0,0);
        current = new Location(0,0);
    }

    public void CellSelect(ConsoleKeyInfo keystroke) {
        switch (keystroke.Key) {
            case ConsoleKey.W or ConsoleKey.UpArrow:
                SetCursorPosition(0,2);
                break;
            case ConsoleKey.A or ConsoleKey.LeftArrow:
                SetCursorPosition(-2,0);
                break;
            case ConsoleKey.S or ConsoleKey.DownArrow:
                SetCursorPosition(0,-2);
                break;
            case ConsoleKey.D or ConsoleKey.RightArrow:
                SetCursorPosition(2,0);
                break;
            case ConsoleKey.Enter or ConsoleKey.T:
                logic.getCurrentFrame()[current.Y/2,current.X/2].ToggleStatus();
                break;
            case ConsoleKey.Escape:
                Environment.Exit(0);
                break;
            default:
                break;
        }
    }

    public void Display(CellAutomata automata) {
        Cell[,] currentFrame;

        if (automata.currentFrame == 1)
            currentFrame = automata.frameOne;
        else
            currentFrame = automata.frameTwo;

        foreach (ICell cell in currentFrame)
            cell.Display(automata.width);
    }
    public void InitLivingCells(CellAutomata automata) {
        var currentFrame = automata.getCurrentFrame();
        currentFrame[0,0].Select();
    }

    public void SetCursorPosition(int left, int right) {
        current = new Location(left+current.X, right+current.Y);
        Console.SetCursorPosition(current.X, current.Y);
    }
}