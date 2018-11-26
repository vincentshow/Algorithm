using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class TestBase
    {
        public readonly ITestOutputHelper Output;

        public TestBase(ITestOutputHelper output)
        {
            this.Output = output;
        }
    }
}
