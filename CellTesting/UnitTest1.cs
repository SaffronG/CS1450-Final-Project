using CellLogic;

namespace CellTesting;

public class UnitTest1
{
    [Fact]
    public void IsCorrectEvolution()
    {
        CellAutomata logic = new(3,3);

        logic.frameOne[0,1].ToggleStatus();
        logic.frameOne[1,0].ToggleStatus();
        logic.frameOne[2,1].ToggleStatus();

        Assert.Equal(1, logic.getCurrentFrame()[0,0].evolutionMath(logic, Evolution.Bottom));
        Assert.Equal(1, logic.getCurrentFrame()[1,2].evolutionMath(logic, Evolution.TopLeft));
        Assert.Equal(0, logic.getCurrentFrame()[1,2].evolutionMath(logic, Evolution.Left));
        Assert.Equal(1, logic.getCurrentFrame()[1,2].evolutionMath(logic, Evolution.BottomLeft));
        Assert.Equal(0, logic.getCurrentFrame()[1,2].evolutionMath(logic, Evolution.Right));
    }
    [Fact]
    public void DoesEvolve()
    {
        // Given
        CellAutomata logic = new (3,3);

        logic.frameOne[0,1].ToggleStatus();
        logic.frameOne[1,0].ToggleStatus();
        logic.frameOne[2,1].ToggleStatus();

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