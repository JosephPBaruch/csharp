// Run: dotnet test --filter "FullyQualifiedName=Leetcode.Tests.MaxContainersTestsLoop.MaxContainers_ReturnsExpected"
namespace Leetcode.Tests;

public class MaxContainersTestsLoop
{
    public static IEnumerable<object[]> Cases => new[]
    {
        new object[] { 2, 3, 15, 4 },
        new object[] { 3, 5, 20, 4 },
        new object[] { 1, 20, 5, 0 },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void MaxContainers_ReturnsExpected(int n, int w, int maxWeight, int expected)
    {
        var s = new MaxContainersClass();
        Assert.Equal(expected, s.MaxContainers(n, w, maxWeight));
    }
}