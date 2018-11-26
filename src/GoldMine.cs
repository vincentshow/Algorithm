using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class GoldMineProcessor
    {
        public int GetMaxValue(int maxMiners, Mine[] mines)
        {
            return this.GetMaxValueAndMarkDigLabel(maxMiners, mines, mines.Length - 1);
        }

        /// <summary>
        /// not matured
        /// </summary>
        /// <param name="maxMiners"></param>
        /// <param name="mines"></param>
        /// <param name="serialNo"></param>
        /// <returns></returns>
        private int GetMaxValueAndMarkDigLabel(int maxMiners, Mine[] mines, int serialNo)
        {
            if (serialNo < 0 || serialNo >= mines.Length)
            {
                return 0;
            }

            var current = mines[serialNo];
            if (serialNo == 0)
            {
                if (maxMiners >= current.Miners)
                {
                    current.IsDig = true;
                    return current.Value;
                }
                else
                {
                    current.IsDig = false;
                    return 0;
                }
            }

            var dontDigValue = this.GetMaxValueAndMarkDigLabel(maxMiners, mines, serialNo - 1);
            var digValue = 0;
            if (maxMiners >= current.Miners)
            {
                digValue = current.Value;
                digValue += this.GetMaxValueAndMarkDigLabel(maxMiners - current.Miners, mines, serialNo - 1);
            }

            current.IsDig = digValue >= dontDigValue;
            return Math.Max(digValue, dontDigValue);
        }
    }

    public class Mine
    {
        public Mine()
        {
        }

        public Mine(int no, int value, int miners)
        {
            this.No = no;
            this.Value = value;
            this.Miners = miners;
        }

        public int No { get; set; }

        public int Value { get; set; }

        public int Miners { get; set; }

        public bool IsDig { get; set; }

        public override string ToString()
        {
            return $"No:{this.No}, Value:{this.Value}, Miners:{this.Miners}, IsDig:{this.IsDig}";
        }
    }
}
