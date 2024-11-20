using Simulator;
using Simulator.Maps;

namespace TestSimulator;
public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]   
    [InlineData(0, 1, 10, 1)] 
    [InlineData(15, 1, 10, 10)] 
    public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
    {
    var result = Validator.Limiter(value, min, max);
    Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 10, 10, 10)] 
    [InlineData(0, 0, 0, 0)]     
    [InlineData(-5, -10, 10, -5)] 
    public void Limiter_ShouldHandleEdgeCases(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("hello", 3, 10, '!', "Hello")]  
    [InlineData("world", 3, 10, '*', "World")]     
    [InlineData("longstring", 3, 8, '_', "Longstri")] 
    public void Shortener_ShouldReturnCorrectResult(string? value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(null, 3, 10, '!', "")] 
    [InlineData("", 5, 10, '*', "*****")] 
    public void Shortener_ShouldHandleNullAndEmptyString(string? value, int min, int max, char placeholder, string expected)
    {
        // Act
        var result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("hello", 5, 5, '-', "Hello")] 
    [InlineData("short", 5, 5, '#', "Short")] 
    [InlineData("biglongtext", 5, 5, '.', "Biglo")] 
    public void Shortener_ShouldHandleEdgeCases(string? value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal(expected, result);
    }
}


