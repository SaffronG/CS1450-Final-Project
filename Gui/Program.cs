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