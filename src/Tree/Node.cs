using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Tree
{
    public class Node
    {
        public Node()
        {
        }

        public Node(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Height { get; set; } = -1;
    }

    public static class NodeExtensions
    {
        public static int GetHeight(this Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        }

        public static int GetChildGap(this Node node)
        {
            if (node == null)
            {
                return 0;
            }

            var leftHeight = node.Left == null ? 0 : node.Left.Height;
            var rightHeight = node.Right == null ? 0 : node.Right.Height;

            return leftHeight - rightHeight;
        }


        public static Node RotateLeft(this Node node)
        {
            if (node == null || node.Right == null)
            {
                return node;
            }

            var top = node.Right;
            node.Right = top.Left;
            top.Left = node;

            top.Height = top.GetHeight();
            node.Height = node.GetHeight();

            return top;
        }

        public static Node RotateRight(this Node node)
        {
            if (node == null || node.Left == null)
            {
                return node;
            }

            var top = node.Left;
            node.Left = top.Right;
            top.Right = node;

            top.Height = top.GetHeight();
            node.Height = node.GetHeight();

            return top;
        }

        public static void PreOrder(this Node bTree, IPrintable printer)
        {
            if (bTree == null)
            {
                return;
            }

            printer.WriteLine(bTree.Value);
            PreOrder(bTree.Left, printer);
            PreOrder(bTree.Right, printer);
        }

        public static void InOrder(this Node bTree, IPrintable printer)
        {
            if (bTree == null)
            {
                return;
            }

            InOrder(bTree.Left, printer);
            printer.WriteLine(bTree.Value);
            InOrder(bTree.Right, printer);
        }

        public static void PostOrder(this Node bTree, IPrintable printer)
        {
            if (bTree == null)
            {
                return;
            }

            PostOrder(bTree.Left, printer);
            PostOrder(bTree.Right, printer);
            printer.WriteLine(bTree.Value);
        }
    }
}
