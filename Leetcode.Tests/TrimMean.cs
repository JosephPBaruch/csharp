// Run: dotnet test --filter "FullyQualifiedName=Leetcode.Tests.TrimMeanTestsLoop.TrimMean_ReturnsExpected"
namespace Leetcode.Tests;

public class TrimMeanTestsLoop
{
    public static IEnumerable<object[]> Cases => new[]
    {
        new object[] { new int[] {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3}, 2.0 },
        // new object[] { new int[] {6,2,7,5,1,2,0,3,10,2,5,0,5,5,0,8,7,6,8,0}, 4.0 },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void TrimMean_ReturnsExpected(int[] arr, double expected)
    {
        var s = new TrimMeanClass();
        Assert.Equal(expected, s.TrimMean(arr));
    }
}