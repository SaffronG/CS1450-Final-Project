﻿namespace CellLogic;

public class Cell : ICell
{
    private ConsoleColor color;
    public Location location { get; set; } // Struct storing the X and Y location data
    public Status status { get; set; } // Enum of Alive, and Dead
    public bool isSelected { get; set; } // For GUI interaction

    public Cell(Location location) {
        this.location = location;
        status = Status.Dead;
    }

    public bool DoesEvolve(CellAutomata automata) {
        int neighbors = 0;

        for (int i = 0; i < 8; i++) // 1-7
            neighbors+= evolutionMath(automata, (Evolution) (0b1 << i));

        // Birth rule: An empty, or “dead,” cell with precisely three “live” neighbors (full cells) becomes live.
        if (neighbors < 2) return false;
        // Survival rule: A live cell with two or three neighbors remains alive.
        if (neighbors >= 2 && neighbors <= 3 && status == Status.Alive) return true;
        if (neighbors == 3 && status == Status.Dead) return true;
        // Death rule: A live cell with zero or one neighbors dies of isolation; a live cell with four or more neighbors dies of overcrowding.
        return false;
    }


    public int evolutionMath(CellAutomata automata, Evolution conditional) {
        int xOffset = 0, yOffset = 0;

        switch (conditional) {
            case Evolution.Top:
                yOffset = -1;
                break;
            case Evolution.TopRight:
                yOffset = -1;
                xOffset = 1;
                break;
            case Evolution.Right:
                xOffset = 1;
                break;
            case Evolution.BottomRight:
                xOffset = 1;
                yOffset =1;
                break;
            case Evolution.Bottom:
                yOffset = 1;
                break;
            case Evolution.BottomLeft:
                yOffset = 1;
                xOffset = -1;
                break;
            case Evolution.Left:
                xOffset = -1;
                break;
            case Evolution.TopLeft:
                xOffset = -1; yOffset = -1;
                break;
        }
        
        try {
            return automata.getCurrentFrame()[location.Y+yOffset, location.X+xOffset].status == Status.Alive ? 1 : 0;
        } catch (IndexOutOfRangeException) {
            return 0;
        }
    }

    public void Display( int width)
    {
        if (isSelected) color = ConsoleColor.Yellow;
        else if (status == Status.Alive) color = ConsoleColor.Black;
        else color = ConsoleColor.White;

        Console.ForegroundColor = color; // Set to appropriate color
        Console.BackgroundColor = color;

        if ((location.X + 1) % width == 0) Console.WriteLine("[]");
        
        else Console.Write("[]");

        Console.BackgroundColor = default; Console.ForegroundColor = default; // Reset to the default
    }
    public void ToggleStatus(bool DoesEvolve) => status = DoesEvolve ? Status.Alive : Status.Dead;
    public void Select() => isSelected = isSelected ? false : true;

}
