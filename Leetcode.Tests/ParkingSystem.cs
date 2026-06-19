// Run: dotnet test --filter "FullyQualifiedName=Leetcode.Tests.ParkingSystemTestsLoop.ParkingSystem_ReturnsExpected"
using System;
using System.Linq;
using System.Collections.Generic;

namespace Leetcode.Tests;

public class ParkingSystemTestsLoop
{
    public static IEnumerable<object[]> Cases => new[]
    {
        new object[] { 1, 1, 0, new int[] { 1, 2, 3, 1 }, new bool[] { true, true, false, false } },
        new object[] { 1, 1, 1, new int[] { 1, 2, 3, 1, 2, 3 }, new bool[] { true, true, true, false, false, false } },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void ParkingSystem_ReturnsExpected(int big, int medium, int small, int[] cars, bool[] expected)
    {
        var s = new ParkingSystemClass(big, medium, small);
        var actual = cars.Select(carType => s.AddCar(carType)).ToArray();
        Assert.Equal(expected, actual);
    }
}