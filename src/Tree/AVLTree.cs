﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Tree
{
    public class AVLTree
    {
        public Node Build(int[] source)
        {
            Node root = null;
            for (int i = 0; i < source.Length; i++)
            {
                root = this.CreateTree(source[i], root);
            }
            return root;
        }

        private Node CreateTree(int next, Node node)
        {
            var newNode = new Node(next);
            if (node == null)
            {
                node = newNode;
            }
            else
            {
                if (next > node.Value)
                {
                    node.Right = CreateTree(next, node.Right);
                    node = TryAdjustRightNode(next, node);
                }
                else
                {
                    node.Left = CreateTree(next, node.Left);
                    TryAdjustLeftNode(next, node);
                }
            }

            node.Height = node.GetHeight();
            return node;
        }

        private Node TryAdjustLeftNode(int next, Node node)
        {
            if (Math.Abs(node.GetChildGap()) < 2)
            {
                return node;
            }

            var rotateNoded = node.Left;
            if (next > rotateNoded.Value)
            {
                node = node.RotateLeft();
            }
            return node.RotateRight();
        }

        private Node TryAdjustRightNode(int next, Node node)
        {
            if (Math.Abs(node.GetChildGap()) < 2)
            {
                return node;
            }

            var rotateNoded = node.Right;
            if (next < rotateNoded.Value)
            {
                node = node.RotateRight();
            }
            return node.RotateLeft();
        }
    }
}
