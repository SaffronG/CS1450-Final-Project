namespace CellLogic;

public class CellAutomata
{
    public readonly int width;
    public readonly int height;
    public Cell[,] frameOne;
    public Cell[,] frameTwo;
    public int currentFrame = 1;
    public int currentGeneration = 0;
    public CellAutomata(int dimensionX, int dimensionY) {
        width = dimensionX;
        height = dimensionY;
        frameOne = PopulateBoard(height,width);
        frameTwo = PopulateBoard(height,width);
    }

    public Cell[,] PopulateBoard(int h, int w) {
        Cell[,] returnBoard = new Cell[h,w];
        for (int y = 0; y < h; y++)
            for (int x = 0; x < w; x++)
            {
                returnBoard[y,x] = new Cell(new Location(x,y));
            }
        return returnBoard;
    }

    public Cell[,] getCurrentFrame() => currentFrame == 1 ? frameOne : frameTwo;
    public Cell[,] getNextFrame() => currentFrame == 1 ? frameTwo : frameOne;


    public void EvolveFrame() {
        Cell[,] baseFrame = getCurrentFrame();
        Cell[,] evolveFrame = getNextFrame();

        for (int y = 0; y < evolveFrame.GetLength(0); y++)
            for (int x = 0; x < evolveFrame.GetLength(1); x++)
                evolveFrame[y,x].ToggleStatus(baseFrame[y,x].DoesEvolve(this));

        currentFrame = currentFrame == 1 ? 2 : 1;
        currentGeneration++;
    }
}