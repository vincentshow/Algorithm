using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Tree
{
    public class BinaryTree
    {
        public Node Build(int[] source)
        {
            Node root = null;
            for (int i = 0; i < source.Length; i++)
            {
                this.CreateBTree(source[i],ref root);
            }
            return root;
        }

        public Node FindFloorNode(Node source, int target)
        {
            if (source == null)
            {
                return source;
            }

            var current = source;
            if (source.Value <= target)
            {
                current = this.FindFloorNode(source.Right, target);
            }

            var floorLeftNode = this.FindFloorNode(source.Left, target);
            if (current != null && floorLeftNode != null && floorLeftNode.Value < current.Value)
            {
                current = floorLeftNode;
            }
            return current;
        }

        public void PreOrder(Node bTree, IPrintable printer)
        {
            if (bTree == null)
            {
                return;
            }

            printer.WriteLine(bTree.Value);
            PreOrder(bTree.Left, printer);
            PreOrder(bTree.Right, printer);
        }

        public void InOrder(Node bTree, IPrintable printer)
        {
            if (bTree == null)
            {
                return;
            }

            InOrder(bTree.Left, printer);
            printer.WriteLine(bTree.Value);
            InOrder(bTree.Right, printer);
        }

        public void PostOrder(Node bTree, IPrintable printer)
        {
            if (bTree == null)
            {
                return;
            }

            PostOrder(bTree.Left, printer);
            PostOrder(bTree.Right, printer);
            printer.WriteLine(bTree.Value);
        }

        private void CreateBTree(int next,ref Node root)
        {
            var newNode = new Node(next);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node father = null;
                Node current = root;
                while (current != null)
                {
                    father = current;
                    if (current.Value > next)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }

                if (father.Value > next)
                {
                    father.Left = newNode;
                }
                else
                {
                    father.Right = newNode;
                }
            }
        }
    }
}
