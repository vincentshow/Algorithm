using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class TestBase
    {
        public readonly IPrintable Printer;

        public TestBase(ITestOutputHelper output)
        {
            this.Printer = new TestPrinter(output);
        }
    }
}
