using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class RectangleTests{
    [Fact]
    public void Rectangle_ValidCoordinates_ShouldInitializeCorrectly()
    {
        // Arrange
        int x1 = 1, y1 = 2, x2 = 3, y2 = 4;

        // Act
        var rectangle = new Rectangle(x1, y1, x2, y2);

        // Assert
        Assert.Equal(x1, rectangle.X1);
        Assert.Equal(y1, rectangle.Y1);
        Assert.Equal(x2, rectangle.X2);
        Assert.Equal(y2, rectangle.Y2);
    }
    [Fact]
    public void Rectangle_InvalidCoordinates_ShouldThrowArgumentException()
    {
        int x1 = 1, y1 = 1, x2 = 1, y2 = 1; 
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }

    [Fact]
    public void Rectangle_SwappedCoordinates_ShouldInitializeCorrectly()
    {
        int x1 = 5, y1 = 6, x2 = 2, y2 = 3;

        var rectangle = new Rectangle(x1, y1, x2, y2);

        Assert.Equal(2, rectangle.X1);
        Assert.Equal(3, rectangle.Y1); 
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(6, rectangle.Y2);
    }

    [Theory]
    [InlineData(0, 0, 1, 1)]
    [InlineData(0, 0, 100, 100)]
    public void Rectangle_MinimumSize_ShouldInitializeCorrectly(int x1, int y1, int x2, int y2)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(Math.Min(x1, x2), rectangle.X1);
        Assert.Equal(Math.Min(y1, y2), rectangle.Y1);
        Assert.Equal(Math.Max(x1, x2), rectangle.X2);
        Assert.Equal(Math.Max(y1, y2), rectangle.Y2);
    }

}
