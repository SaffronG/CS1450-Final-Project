using System.Reflection.Metadata;
using CellLogic;

namespace GUI;

public class Program {
    public static void Main(string[] args) {
        Console.CursorVisible = false;
        CellAutomata logic = new CellAutomata(int.Parse(args[0]), int.Parse(args[1]));
        GUIFunctions gui = new GUIFunctions(logic);
        
        gui.InitLivingCells(logic);

        while (true) {
        var current = Console.GetCursorPosition();
        gui.Display(logic);
            if (gui.CellSelect(Console.ReadKey(true))) break;
        }

        while (true) {
            gui.Display(logic);
            Thread.Sleep(500);
            logic.EvolveFrame();
        }
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

    public bool CellSelect(ConsoleKeyInfo keystroke) {
        switch (keystroke.Key) {
            case ConsoleKey.W or ConsoleKey.UpArrow:
                SetCursorPosition(logic, 0,-2);
                break;
            case ConsoleKey.A or ConsoleKey.LeftArrow:
                SetCursorPosition(logic, -2,0);
                break;
            case ConsoleKey.S or ConsoleKey.DownArrow:
                SetCursorPosition(logic, 0,2);
                break;
            case ConsoleKey.D or ConsoleKey.RightArrow:
                SetCursorPosition(logic, 2,0);
                break;
            case ConsoleKey.Enter or ConsoleKey.T:
                logic.getCurrentFrame()[current.Y/2,current.X/2].ToggleStatus(true);
                break;
            case ConsoleKey.Delete or ConsoleKey.X:
                logic.getCurrentFrame()[current.Y/2,current.X/2].ToggleStatus(false);
                break;
            case ConsoleKey.Escape:
                logic.getCurrentFrame()[current.Y/2, current.X/2].Select();
                return true;
            default:
                break;
        }
        return false;
    }

    public void Display(CellAutomata automata) {
        Console.Clear();
        Cell[,] currentFrame;

        if (automata.currentFrame == 1)
            currentFrame = automata.frameOne;
        else
            currentFrame = automata.frameTwo;

        foreach (ICell cell in currentFrame)
            cell.Display(automata.width);
        Console.WriteLine($"\nCurrent Generation: {automata.currentGeneration}");
    }
    public void InitLivingCells(CellAutomata automata) {
        var currentFrame = automata.getCurrentFrame();
        currentFrame[0,0].Select();
    }

    public void SetCursorPosition(CellAutomata automata, int left, int right) {
        automata.getCurrentFrame()[current.Y/2, current.X/2].Select();
        current = new Location(int.Clamp(current.X+left, 0, (automata.width*2)-1), int.Clamp(current.Y+right, 0, (automata.height*2)-1));
        automata.getCurrentFrame()[current.Y/2, current.X/2].Select();
        Console.SetCursorPosition(current.X, current.Y/2);
    }
}