using System;
using System.Collections.Generic;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<QuizItem> tree = GetTree();
            var nodes = tree.Root;
            while (nodes != null)
            {
                if (nodes.Left != null || nodes.Right != null)
                {
                    Console.WriteLine(nodes.Data.Text);
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Y:
                            WriteAnswer("Yes");
                            nodes = nodes.Left;
                            break;
                        case ConsoleKey.N:
                            WriteAnswer("No");
                            nodes = nodes.Right;
                            break;
                    }
                }
                else
                {
                    WriteAnswer(nodes.Data.Text);
                    nodes = null;
                }
            }

            Console.ReadLine();
        }

        private static void WriteAnswer(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static BinaryTree<QuizItem> GetTree()
        {
            var tree = new BinaryTree<QuizItem>();
            tree.Root = new BinaryTreeNode<QuizItem>()
            {
                Data = new QuizItem("Do you have experience in developing applications ?"),
                Children = new List<TreeNode<QuizItem>>() {
                    new BinaryTreeNode<QuizItem>(){
                        Data = new QuizItem("Have you worked as a developer for more than 5 years ?"),
                        Children = new List<TreeNode<QuizItem>>(){
                           new BinaryTreeNode<QuizItem>(){
                               Data = new QuizItem("Apply as a senior developer!")
                           },
                           new BinaryTreeNode<QuizItem>(){
                               Data = new QuizItem("Apply as a middle developer!")
                           }
                        }
                    },
                    new BinaryTreeNode<QuizItem>{
                        Data = new QuizItem("Have you completed the university ?"),
                        Children = new List<TreeNode<QuizItem>>{
                            new BinaryTreeNode<QuizItem>{
                                Data = new QuizItem("Apply for a junior developer!")
                            },
                            new BinaryTreeNode<QuizItem>{
                                Data = new QuizItem("Will you find some time during the semester ?"),
                                Children = new List<TreeNode<QuizItem>>{
                                    new BinaryTreeNode<QuizItem>{
                                        Data = new QuizItem("Apply for our long-time intership program!")
                                    },
                                    new BinaryTreeNode<QuizItem>{
                                        Data = new QuizItem("Apply for summer intership program!")
                                    }
                                }       
                            }
                        }
                    }
                }
            };
            tree.Count = 9;
            return tree;
        }
    }
}
