using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace BinarySearchTreeOperations
{
    class Node
    {
        public int key_value;
        public int depth;
        public Node left;
        public Node right;
    }

    class Tree
    {
        private Node newNode, root, current, pre;
        private List<Node> visitedList = new List<Node>();
        private int level = 0;

        public void Insert()
        {
            Console.Clear();
            newNode = new Node();
            Console.Write("Enter value: ");
            int value = Convert.ToInt32(Console.ReadLine());

            newNode.key_value = value;
            newNode.left = null;
            newNode.right = null;

            if (root == null)
            {
                root = newNode;
                newNode.depth = 0;
                Console.WriteLine("Root node is added!");
            }
            else if (root.left == null && value < root.key_value)
            {
                root.left = newNode;
                newNode.depth = 1;
                Console.WriteLine("Root left child is added!");
            }
            else if (root.right == null && value > root.key_value)
            {
                root.right = newNode;
                newNode.depth = 1;
                Console.WriteLine("Root right child is added");
            }
            else
            {
                if (value < root.key_value)
                    current = root.left;
                else
                    current = root.right;

                while (current != null)
                {
                    pre = current;
                    if (value > current.key_value)
                    {
                        current = current.right;
                    }
                    else
                    {
                        current = current.left;
                    }

                    level++;
                }

                newNode.depth = 1 + level;
                if (value > pre.key_value)
                {
                    pre.right = newNode;
                    Console.WriteLine("Right child is added");
                }
                else
                {
                    pre.left = newNode;
                    Console.WriteLine("Left child is added");
                }
                level = 0;
            }

            Console.WriteLine("\n\nPress ENTER to add more or ESCAPE to go back to Main Menu.");
            var k = Console.ReadKey();
            if (k.Key == ConsoleKey.Enter)
            {
                Insert();
            }
            else if (k.Key == ConsoleKey.Escape)
            {
                MainMenu();
            }
        }

        public void DisplayPath(Node c)
        {
            Console.Clear();
            Console.Write("Enter node data of which you wanna get path: ");
            int value = Convert.ToInt32(Console.ReadLine());

            bool check = false;

            if (root == null)
            {
                Console.WriteLine("Tree is empty!");
            }
            else
            {
                current = c;

                while (current != null)
                {

                    if (current.key_value == value)
                    {
                        check = true;
                        break;
                    }

                    pre = current;

                    if (value < current.key_value)
                    {
                        current = current.left;
                    }
                    else if (value > current.key_value)
                        current = current.right;
                }
            }

            if (check)
            {
                current = c;

                while (current != null)
                {
                    Console.Write(current.key_value + ">" + current.depth);

                    if (current.key_value == value)
                    {
                        break;
                    }

                    Console.Write(" . ");

                    pre = current;

                    if (value < current.key_value)
                    {
                        current = current.left;
                    }
                    else if (value > current.key_value)
                        current = current.right;

                }
            }
            else
            {
                Console.Write(string.Format("\n\a{0} is not in the Tree!", value));
            }

            Console.WriteLine("\n\nPress ENTER to get more paths or ESCAPE to go back to Main Menu.");
            var k = Console.ReadKey();
            if (k.Key == ConsoleKey.Enter)
            {
                DisplayPath(root);
            }
            else if (k.Key == ConsoleKey.Escape)
            {
                MainMenu();
            }
        }

        public void DFS(Node root)
        {
            Node tmp = root;
            Stack<Node> stck = new Stack<Node>();

            stck.Push(tmp);


            while (stck.Count != 0)
            {
                while (tmp.left != null)
                {
                    tmp = tmp.left;
                    stck.Push(tmp);
                }
                while (stck.Count != 0)
                {
                    tmp = stck.Peek();
                    stck.Pop();
                    Console.Write(tmp.key_value);

                    if (tmp.right != null)
                    {
                        tmp = tmp.right;
                        stck.Push(tmp);
                        break;
                    }
                }
            }
        }

        /*void DFS(Node r)
        {
            if (r==null)
            {
                return;
            }
            else
            {
                Console.Write(r.key_value+" ");
                visitedList.Add(r);
                current = r;
            }

            while (visitedList.Count!=0)
            {
                if ()
                {
                    Console.Write(r.key_value + " ");

                }

                if (current.left != null)
                {
                    Console.Write(current.key_value + " ");
                    visitedList.Add(current);
                    current = current.left;
                }
                else if (current.left == null && current.right != null)
                {

                }
            }
        }
        public void Print()
        {
            Stack<Node> s = new Stack<Node>();
            s.Push(root);
            while (s.Count > 0)
            {
                Node t = s.Pop();
                Console.Write(t.key_value + " ");

                if (t.left != null)
                {
                    s.Push(t.left);

                }

                if (t.right != null)
                {
                    s.Push(t.right);
                }
            }
            Console.WriteLine();
        }*/

        void BFS()
        {
            Console.Clear();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                Node tempNode = queue.Dequeue();

                Console.Write(tempNode.key_value + " ");

                if (tempNode.left != null)
                {
                    queue.Enqueue(tempNode.left);
                }

                if (tempNode.right != null)
                {
                    queue.Enqueue(tempNode.right);
                }
            }
        }

        void IDDFS()
        {
            Console.Clear();

            Stack<Node> s = new Stack<Node>();
            //Console.WriteLine(MaxDepth(root));
            s.Push(root);
            Console.Write("Visited Nodes: ");

            //int depth = MaxDepth(root);


                while (s.Count != 0)
                {
                    Node currentNode = s.Pop();
                    //onsole.WriteLine(s.Count);
                    Console.Write(currentNode.key_value + " ");

                    if (currentNode.right != null)
                    {
                        s.Push(currentNode.right);
                    }
                    if (currentNode.left != null)
                    {
                        s.Push(currentNode.left);
                    }

                }
                Console.Write("   ");
            



        }

        void IDDFS2()
        {
            Console.Clear();

            Stack<Node> s = new Stack<Node>();
            //Console.WriteLine(MaxDepth(root));

            Console.Write("Visited Nodes: ");

            int depth = MaxDepth(root);

            for (int i = 0; i < depth; i++)
            {
                s.Push(root);
                DLS(i);
                s.Clear();
                Console.Write("   ");
            }

            void DLS(int limit)
            {
                bool maxLevel = false;
                while (s.Count > 0)
                {
                    Node currentNode = s.Pop();

                    if (currentNode.depth == limit)
                    {
                        maxLevel = true;
                    }

                    if (maxLevel && currentNode.depth != limit)
                    {
                        break;
                    }


                    //Console.WriteLine(s.Count);
                    Console.Write(currentNode.key_value + " ");

                    if (currentNode.right != null)
                    {
                        s.Push(currentNode.right);
                    }
                    if (currentNode.left != null)
                    {
                        s.Push(currentNode.left);
                    }



                }
            }
        }



        public void MainMenu()
        {
            Console.Clear();

            Console.Write(
                "1. Create Nodes in the Tree\n2. Display Path\n3. DFS\n4. BFS\n5. IDDFS\n\nEnter your choice: ");

            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    Insert();
                    break;
                case ConsoleKey.D2:
                    DisplayPath(root);
                    break;
                case ConsoleKey.D3:
                    DFS(root);
                    break;
                case ConsoleKey.D4:
                    BFS();
                    break;
                case ConsoleKey.D5:
                    IDDFS();
                    break;
                case ConsoleKey.D6:

                    break;
                case ConsoleKey.D7:

                    break;
                case ConsoleKey.D8:

                    break;
                default:
                    Console.WriteLine("\aWrong entry!");
                    break;
            }
        }


        int MaxDepth(Node node)
        {
            if (node == null)
                return 0;
            else
            {
                /* compute the depth of each subtree */
                int lDepth = MaxDepth(node.left);
                int rDepth = MaxDepth(node.right);

                /* use the larger one */
                if (lDepth > rDepth)
                    return (lDepth + 1);
                else
                    return (rDepth + 1);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Tree bTree = new Tree();
                bTree.MainMenu();

                Console.ReadKey();
            }
        }
    }
}
