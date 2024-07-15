using ProblemSolving.Utilities;

namespace ProblemSolving.Tests.Utilities;

public class UtilsTests
{
    [Theory]
    [InlineData("test", "tset")]
    [InlineData("aaa", "aaa")]
    [InlineData("", "")]
    [InlineData("a", "a")]
    [InlineData("olo", "olo")]
    public void ReverseString_CorrectString_ReturnsReversedString(string input, string expected)
    {
        // Act
        string actual = Utils.ReverseString(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("level", true)]
    [InlineData("test", false)]
    [InlineData("a", true)]
    [InlineData("", true)]
    [InlineData("maam", true)]
    public void IsPalindrome_CorrectString_ReturnsCorrectResult(string input, bool expected)
    {
        // Act
        bool actual = Utils.IsPalindrome(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MissingElements_NoMissingElements_ReturnsEmptySequence()
    {
        // Arrange
        int[] input = [1, 2, 3, 4, 5];
        int[] expected = [];

        // Act
        IEnumerable<int> actual = Utils.MissingElements(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MissingElements_OneMissingElement_ReturnsMissingElement()
    {
        // Arrange
        int[] input = [1, 2, 4, 5];
        int[] expected = [3];

        // Act
        IEnumerable<int> actual = Utils.MissingElements(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MissingElements_MultipleMissingElements_ReturnsMissingElements()
    {
        // Arrange
        int[] input = [1, 2, 5, 6];
        int[] expected = [3, 4];

        // Act
        IEnumerable<int> actual = Utils.MissingElements(input);

        // Assert
        Assert.Equal(expected, actual);
    }
}
