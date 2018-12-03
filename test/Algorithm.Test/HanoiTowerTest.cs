using System;
using Xunit;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class HanoiTowerTest : TestBase
    {
        public HanoiTowerTest(ITestOutputHelper output)
            : base(output)
        {
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Test_Success(int n)
        {
            var hanoi = new HanoiTower();

            this.Printer.WriteLine($"Begin move {n}");
            hanoi.Move(n, "A", "B", "C", this.Printer);
            this.Printer.WriteLine($"=====Finshed moving {n}=====");
            this.Printer.WriteLine();
        }
    }
}
