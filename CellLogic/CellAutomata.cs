using System.Dynamic;
using System.Globalization;

namespace CellLogic;

public class CellAutomata
{
    public readonly int width;
    public readonly int height;
    public Cell[,] frameOne;
    public Cell[,] frameTwo;
    public int currentFrame = 1;

    public CellAutomata(int dimensionX, int dimensionY) {
        width = dimensionX;
        height = dimensionY;
        frameOne = new Cell[height, width];
        frameTwo = new Cell[height, width];
        PopulateBoard();
    }

    public void PopulateBoard() {
        for (int y = 0; y < frameOne.GetLength(0); y++)
            for (int x = 0; x < frameOne.GetLength(1); x++)
            {
                frameOne[y,x] = new Cell(new Location(x,y));
                frameTwo[y,x] = new Cell(new Location(x,y));
            }
    }

    public Cell[,] getCurrentFrame() =>  currentFrame == 1 ? frameOne : frameTwo;

    public void EvolveFrame() {
        Cell[,] baseFrame, evolveFrame;

        if (currentFrame == 1)
        {
            baseFrame = frameOne;
            evolveFrame = frameTwo;
            currentFrame = 2;
        }
        else {
            baseFrame = frameTwo;
            evolveFrame = frameOne;
            currentFrame = 1;
        }

        for (int y = 0; y < baseFrame.GetLength(0); y++)
            for (int x = 0; x < baseFrame.GetLength(1); x++)
            {
                if (baseFrame[y,x].DoesEvolve(this))
                    evolveFrame[y,x].status = Status.Alive;
                else
                    evolveFrame[y,x].status = Status.Dead;
            }
    }
}