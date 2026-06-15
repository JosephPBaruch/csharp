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

    [Fact]
    public void Test2()
    {
        var s = new Solution();

        bool answer = s.ValidDigit(232, 2);

        Assert.Equal(answer, false);

    }

    [Fact]
    public void Test3()
    {
        var s = new Solution();

        bool answer = s.ValidDigit(5, 1);

        Assert.Equal(answer, false);

    }
}