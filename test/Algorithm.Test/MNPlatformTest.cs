using System;
using Xunit;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class MNPlatformTest
    {
        private readonly ITestOutputHelper _output;

        public MNPlatformTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(1, 5, 6)]
        [InlineData(5, 1, 6)]
        [InlineData(2, 2, 6)]
        [InlineData(2, 3, 10)]
        [InlineData(3, 2, 10)]
        public void Test_Success(int m, int n, int expect)
        {
            var algorithm = new MNPlatform();
            Assert.Equal(expect, algorithm.GetAvailablePath(m, n));
        }
    }
}
