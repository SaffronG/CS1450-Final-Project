using CellLogic;

namespace CellTesting;

public class UnitTest1
{
    [Fact]
    public void IsCorrectEvolution()
    {
        CellAutomata logic = new(3,3);

        logic.frameOne[0,1].ToggleStatus(true);
        logic.frameOne[1,0].ToggleStatus(true);
        logic.frameOne[2,1].ToggleStatus(true);

        Assert.Equal(1, logic.getCurrentFrame()[0,0].evolutionMath(logic, Evolution.Bottom));
        Assert.Equal(1, logic.getCurrentFrame()[1,2].evolutionMath(logic, Evolution.TopLeft));
        Assert.Equal(0, logic.getCurrentFrame()[1,2].evolutionMath(logic, Evolution.Left));
        Assert.Equal(1, logic.getCurrentFrame()[1,2].evolutionMath(logic, Evolution.BottomLeft));
        Assert.Equal(0, logic.getCurrentFrame()[1,2].evolutionMath(logic, Evolution.Right));
    }
    [Fact]
    public void IsCorrectEvolution2()
    {
        CellAutomata logic = new(3,3);

        logic.frameOne[0,1].ToggleStatus(true);
        logic.frameOne[1,1].ToggleStatus(true);
        logic.frameOne[2,1].ToggleStatus(true);

        Assert.Equal(0, logic.getCurrentFrame()[1,1].evolutionMath(logic, Evolution.Left));
        Assert.Equal(0, logic.getCurrentFrame()[1,1].evolutionMath(logic, Evolution.Right));
        Assert.Equal(1, logic.getCurrentFrame()[1,1].evolutionMath(logic, Evolution.Bottom));
        Assert.Equal(1, logic.getCurrentFrame()[1,0].evolutionMath(logic, Evolution.Right));
        Assert.Equal(1, logic.getCurrentFrame()[1,2].evolutionMath(logic, Evolution.Left));
    }
    [Fact]
    public void IsCorrectEvolutionMath()
    {
        CellAutomata logic = new(3,3);

        logic.frameOne[0,1].ToggleStatus(true);
        logic.frameOne[1,1].ToggleStatus(true);
        logic.frameOne[2,1].ToggleStatus(true);

        int expected = 2;
        int result = 0;

        for (int i = 0; i < 8; i++) // 1-7
            result += logic.getCurrentFrame()[1,1].evolutionMath(logic, (Evolution) (0b1 << i));

        Assert.Equal(expected, result);
    }
    [Fact]
    public void DoesEvolve()
    {
        // Given
        CellAutomata logic = new (3,3);

        logic.frameOne[0,1].ToggleStatus(true);
        logic.frameOne[1,0].ToggleStatus(true);
        logic.frameOne[2,1].ToggleStatus(true);

        // When
        bool result = logic.getCurrentFrame()[1,1].DoesEvolve(logic);
        bool result2 = logic.getCurrentFrame()[2,2].DoesEvolve(logic);
        bool result3 = logic.getCurrentFrame()[2,1].DoesEvolve(logic);

        // Then
        Assert.True(result);
        Assert.False(result2);
        Assert.False(result3);
    }
}