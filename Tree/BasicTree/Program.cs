using System;
using System.Collections.Generic;

namespace BasicTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            tree.Root = new TreeNode<int>()
            {
                Data = 100
            };

            tree.Root.Children = new List<TreeNode<int>>() {
                new TreeNode<int>{ Data = 50, Parent = tree.Root.Parent},
                new TreeNode<int>{ Data = 1, Parent = tree.Root.Parent},
                new TreeNode<int>{ Data = 150, Parent = tree.Root.Parent}
            };

            tree.Root.Children[2].Children = new List<TreeNode<int>> {
                new TreeNode<int> { Data = 30, Parent = tree.Root.Children[2]}
            };


        }
    }
}
