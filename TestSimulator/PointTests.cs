using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class PointTests{
    [Theory]
    [InlineData(14, 17)]
    public void Constructor_XY_Validator(int x, int y){
        var point = new Point(x, y);
        Assert.Equal((x,y), (point.X, point.Y));
    }
    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(0, 1, Direction.Down, 0, 0)]
    [InlineData(4, 8, Direction.Left, 3, 8)] 
    [InlineData(18, 10, Direction.Right, 19, 10)] 
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var point = new Point(x, y);
        // Act
        var nextPoint = point.Next(direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(19, 19, Direction.Down, 18, 18)]
    [InlineData(11, 8, Direction.Left, 10, 9)]
    [InlineData(0, 10, Direction.Right, 1, 9)] 
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var nextPoint = point.NextDiagonal(direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}