using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class GoldMineTest : TestBase
    {
        public GoldMineTest(ITestOutputHelper output)
            : base(output)
        {

        }

        [Theory]
        //[InlineData("20, 3; 50, 4; 10, 1", 7, 70)]
        //[InlineData("20, 3; 50, 4; 10, 1; 80, 8; 60, 6", 10, 110)]
        [InlineData("20, 3; 50, 4; 10, 1; 80, 8; 60, 6", 11, 120)]
        //[InlineData("20, 3; 50, 4; 10, 1; 80, 8; 60, 6", 8, 80)]
        //[InlineData("10, 2; 20, 4; 60, 6; 80, 8; 100, 10", 23, 200)]
        public void TestSuccess(string input, int maxMiners, int expect)
        {
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            var splitMines = input.Split(';');
            var mines = new Mine[splitMines.Length];

            for (int i = 0; i < splitMines.Length; i++)
            {
                var mineParam = splitMines[i].Split(',');
                if (mineParam.Length < 2)
                {
                    throw new ArgumentException(nameof(input));
                }

                mines[i] = new Mine(i, int.Parse(mineParam[0]), int.Parse(mineParam[1]));
            }

            this.Output.WriteLine("source mines:");
            this.Output.WriteLine(string.Join("; ", mines.ToList()));

            var goldMine = new GoldMineProcessor();
            var maxValue = goldMine.GetMaxValue(maxMiners, mines);

            Assert.Equal(expect, maxValue);

            //this.Output.WriteLine($"get max value {maxValue} with following dig result:");
            //this.Output.WriteLine(string.Join("; ", mines.ToList()));
        }
    }
}
