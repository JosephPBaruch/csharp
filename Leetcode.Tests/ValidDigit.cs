using Leetcode;

namespace Leetcode.Tests;

public class ValidDigitTests
{
    [Fact]
    public void Test1()
    {
        var s = new Solution();

        bool answer = s.ValidDigit(101, 0);

        Assert.Equal(answer, true);

    }
}