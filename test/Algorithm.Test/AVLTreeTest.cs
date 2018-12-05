using Algorithm.Tree;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class AVLTreeTest : TestBase
    {
        public AVLTreeTest(ITestOutputHelper output)
            : base(output)
        {
        }

        /// <summary>
        /// TODO lost 2 and 13
        /// </summary>
        /// <param name="source"></param>
        [Theory]
        //[InlineData("1,5,3,8")]
        [InlineData("1,5,3,8,9,4,2,6,7")]
        [InlineData("10,5,13,18,19,14,1,12,7")]
        public void TestBuildAndTraverse(string source)
        {
            var sourceArray = this.GetSourceArray(source);

            var bTree = new AVLTree();
            var tree = bTree.Build(sourceArray);

            Assert.NotNull(tree);

            tree.PreOrder(this.Printer);
            this.Printer.WriteLine("PreOrder end");

            tree.InOrder(this.Printer);
            this.Printer.WriteLine("InOrder end");

            tree.PostOrder(this.Printer);
            this.Printer.WriteLine("PostOrder end");
        }

        /*
        [Theory]
        [InlineData("10,5,13,18,19,14,1,12,7", 11, 12)]
        [InlineData("10,5,13,18,19,14,1,12,7", 15, 18)]
        [InlineData("10,5,13,18,19,14,1,12,7", 9, 10)]
        [InlineData("10,5,13,18,19,14,1,12,7", 19, null)]
        public void TestFindFloorNode(string source, int target, int? expect)
        {
            var sourceArray = this.GetSourceArray(source);

            var bTree = new BinaryTree();
            var tree = bTree.Build(sourceArray);
            Assert.NotNull(tree);

            var floorNode = bTree.FindFloorNode(tree, target);
            if (!expect.HasValue)
            {
                Assert.Null(floorNode);
            }
            else
            {
                Assert.NotNull(floorNode);
                Assert.Equal(expect, floorNode.Value);
            }
        }
        */
        private int[] GetSourceArray(string source)
        {
            var splitSource = source.Split(',');
            var sourceArray = new int[splitSource.Length];
            for (int i = 0; i < splitSource.Length; i++)
            {
                sourceArray[i] = int.Parse(splitSource[i]);
            }

            return sourceArray;
        }
    }
}
