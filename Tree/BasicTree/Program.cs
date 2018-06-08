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


            Tree<Person> company = new Tree<Person>();

            company.Root = new TreeNode<Person>() {
                Data = new Person { Id = 0, Name = "Robert", Role = "Manager" },
                Parent = null
            };

            company.Root.Children = new List<TreeNode<Person>> {
                new TreeNode<Person>{
                    Data = new Person { Id = 1, Name = "R2", Role = "PM" },
                    Parent = company.Root
                },
                new TreeNode<Person>{
                    Data = new Person { Id = 2, Name = "R3", Role = "Senior Engineer"},
                    Parent = company.Root
                },
                new TreeNode<Person>{
                    Data = new Person { Id = 3, Name = "R4", Role = "Engineer"},
                    Parent = company.Root
                },
                new TreeNode<Person>{
                    Data = new Person { Id = 4, Name = "R5", Role = "Juior Engineer"},
                    Parent = company.Root
                },
            };

            company.Root.Children[0].Children = new List<TreeNode<Person>> {
                new TreeNode<Person> {
                    Data = new Person { Id = 5, Name = "Liz", Role = "Sales"},
                    Parent = company.Root.Children[0]
                }
            };




        }
    }
}
