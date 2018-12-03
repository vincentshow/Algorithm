using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class HanoiTower
    {
        public void Move(int n, string original, string assistant, string destination, IPrintable printer)
        {
            if (n == 1)
            {
                printer.WriteLine($"move {n} from {original} to {destination}");
            }
            else
            {
                Move(n - 1, original, destination, assistant, printer);
                Move(1, original, assistant, destination, printer);
                Move(n - 1, assistant, original, destination, printer);
            }
        }
    }
}
