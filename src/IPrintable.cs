using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public interface IPrintable
    {
        void WriteLine();

        void WriteLine<T>(T message);
    }
}
