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
            var mineCount = mines.Length;
            var memo = new int[mineCount][];

            for (int i = 0; i < mineCount; i++)
            {
                memo[i] = new int[maxMiners + 1];
                for (int j = 0; j < maxMiners + 1; j++)
                {
                    memo[i][j] = -1;
                }
            }

            return this.GetMaxValueAndMarkDigLabel(maxMiners, mines, mines.Length - 1, memo);
        }

        /// <summary>
        /// not matured
        /// </summary>
        /// <param name="maxMiners"></param>
        /// <param name="mines"></param>
        /// <param name="serialNo"></param>
        /// <returns></returns>
        private int GetMaxValueAndMarkDigLabel(int maxMiners, Mine[] mines, int serialNo, int[][] memo)
        {
            if (serialNo < 0 || serialNo >= mines.Length)
            {
                return 0;
            }

            if (memo[serialNo][maxMiners] > -1)
            {
                return memo[serialNo][maxMiners];
            }

            var maxValue = 0;
            var current = mines[serialNo];
            if (serialNo == 0)
            {
                if (maxMiners >= current.Miners)
                {
                    current.IsDig = true;
                    maxValue = current.Value;
                }
                else
                {
                    current.IsDig = false;
                }
            }
            else
            {
                var dontDigValue = this.GetMaxValueAndMarkDigLabel(maxMiners, mines, serialNo - 1, memo);
                var digValue = 0;
                if (maxMiners >= current.Miners)
                {
                    digValue = current.Value;
                    digValue += this.GetMaxValueAndMarkDigLabel(maxMiners - current.Miners, mines, serialNo - 1, memo);
                }

                maxValue = Math.Max(digValue, dontDigValue);
                current.IsDig = maxValue == digValue;
            }

            memo[serialNo][maxMiners] = maxValue;
            return maxValue;
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
