using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; set; }
        public int Count { get; set; }

        public void TraversePreOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
        {
            if (node != null) {
                result.Add(node);
                TraversePreOrder(node.Left, result);
                TraversePreOrder(node.Right, result);
            }
        }
        public void TraverseInOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
        {
            if (node != null)
            {
                TraverseInOrder(node.Left, result);
                result.Add(node);
                TraverseInOrder(node.Right, result);
            }
        }
        public void TraversePostOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
        {
            if (node != null)
            {
                TraversePostOrder(node.Left, result);
                TraversePostOrder(node.Right, result);
                result.Add(node);
            }
        }

        public List<BinaryTreeNode<T>> Traverse(TraverseEnum mode)
        {
            List <BinaryTreeNode<T>> nodes = new List<BinaryTreeNode<T>>();
            switch (mode) {
                case TraverseEnum.INORDER:TraverseInOrder(Root, nodes);break;
                case TraverseEnum.PREORDER:TraversePreOrder(Root, nodes);break;
                case TraverseEnum.POSTORDER:TraversePostOrder(Root, nodes);break;
                default:break;
            }
            return nodes;
        }

        public int GetHeight()
        {
            int height = 0;
            foreach (var node in Traverse(TraverseEnum.PREORDER))
            {
                height += Math.Max(height, node.GetHeight());
            }
            return height;
        }
    }

    public enum TraverseEnum
    {
        INORDER,
        PREORDER,
        POSTORDER
    }
}
