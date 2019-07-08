using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sameer_ahmad
{
    class TestClass
    {
        static void Main(string[] args)
        {
            var treeObj = new MainClass("Nothing");

            treeObj.AddEventListener("/root", print);

            treeObj.Create("/root/child1", "childdata 1");
            treeObj.Create("/root/child2", "childdata 2");
            treeObj.Create("/root/child1/subchild1", "subchild1");

            Console.WriteLine("-------all node data------");
            var nodes = treeObj.GetAllNodes();
            foreach (var t in nodes)
            {
                Console.WriteLine(t.Data);
            }

            Console.WriteLine("-------all direct children of root------");
            var children = treeObj.List("/root");
            foreach (var child in children)
            {
                Console.WriteLine(child.Name);
            }
            Console.WriteLine("-----------end--------");

            treeObj.Delete("/root/child2");

            treeObj.RemoveEventListener("/root", print);

            treeObj.Update("/root/child1", "child1");

            Console.ReadKey();
        }

        /// <summary>
        /// This is the method to be attached on the event listener on a node
        /// </summary>
        /// <param name="op"></param>
        /// <param name="node"></param>
        public static void print(OpType op, Tree node)
        {
            Console.WriteLine("event : ");
            Console.WriteLine(op+" Node: "+node.Name);
        }
    }
}

