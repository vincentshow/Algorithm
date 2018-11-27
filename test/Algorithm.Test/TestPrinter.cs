using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class TestPrinter : IPrintable
    {
        private readonly ITestOutputHelper _output;

        public TestPrinter(ITestOutputHelper output)
        {
            this._output = output;
        }

        public void WriteLine()
        {
            this._output.WriteLine(string.Empty);
        }

        public void WriteLine<T>(T message)
        {
            this._output.WriteLine(message?.ToString());
        }
    }
}
