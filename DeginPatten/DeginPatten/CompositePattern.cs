using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeginPatten
{
    class CompositePattern
    {
    }

    public abstract class Node
    {
        public string Name { get; protected set; }
        public abstract void Display();
    }

    public class File_Test : Node
    {
        public File_Test(string name)
        {
            Name = name;
        }
        public override void Display()
        {
            Console.WriteLine($"FILE: {Name}");
        }
    }
    public class Directory : Node
    {
        private List<Node> children = new List<Node>();

        public Directory(string name)
        {
            this.Name = name;
        }

        public override void Display()
        {
            Console.WriteLine($"DIR: {Name}");
            foreach (Node comp in children)
            {
                comp.Display();
            }
        }

        public void AddChild(Node child)
        {
            if (child != null)
            {
                children.Add(child);

            }
        }
    }
    class Composite_Client
    {
        public static void HowToTest()
        {
            Directory dir = new Directory("Folder");
            File_Test file1 = new File_Test("a1.doc");
            File_Test file2 = new File_Test("a2.doc");
            File_Test file3 = new File_Test("a3.doc");
            Directory sub = new Directory("SubFolder");
            dir.AddChild(file1);
            dir.AddChild(file2);
            dir.AddChild(file3);
            dir.AddChild(sub);

            DisplayNodes(file2, dir);
        }

        static void DisplayNodes(params Node[] component)
        {
            foreach (Node item in component)
            {
                item.Display();
            }
        }
    }

}
