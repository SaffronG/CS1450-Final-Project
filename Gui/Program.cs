using System.ComponentModel.Design;
using CellLogic;
using Microsoft.VisualBasic;

namespace GUI;

public class Program {
    public static void Main(string[] args) {
        Console.CursorVisible = false;
        CellAutomata logic = new CellAutomata(int.Parse(args[0]), int.Parse(args[1]));
        GUIFunctions gui = new GUIFunctions(logic);
        
        gui.Display(logic);
    }
}

public class GUIFunctions {
     public readonly CellAutomata logic;

    public GUIFunctions(CellAutomata automata) {
        logic = automata;
        Console.SetCursorPosition(0,0);
    }

    public void CellSelect() {

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
}