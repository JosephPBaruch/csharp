// Run: dotnet test --filter "FullyQualifiedName=Leetcode.Tests.ValidDigitTestsLoop.ValidDigit_ReturnsExpected"
namespace Leetcode.Tests;

public class ValidDigitTestsLoop
{
    public static IEnumerable<object[]> Cases => new[]
    {
        new object[] { 101, 0, true },
        new object[] { 232, 2, false },
        new object[] { 5, 1, false }
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void ValidDigit_ReturnsExpected(int number, int digit, bool expected)
    {
        var s = new Solution();
        Assert.Equal(expected, s.ValidDigit(number, digit));
    }
}