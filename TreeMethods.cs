using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sameer_ahmad
{
    public class TreeMethods : ITreeMethods
    {
        private TreeHelper _helper;

        public TreeMethods(Tree root)
        {
            _helper =new TreeHelper(root);
        }

        public void CreateNode(string path, string data)
        {

            string[] s = _helper.SplitString(path, '/');
            var node = _helper.FindNode(s, s.Length - 1);
            Tree childNode = node.Children.Find(o => o.Name == s[s.Length-1]);
            if (childNode == null)
            {
                childNode = new Tree();
                //attach event on new node if there is a event already attached on the parent
                childNode.CurrentEvent += node.getCurrentEvent();
                //last part of the path is being treated as new node Name to be created
                childNode.Create(data, s[s.Length - 1]);
                node.Children.Add(childNode);
            }
            else
            {
                // if node with same name already exist at same given path;
                throw new Exception("Node already exist in the Tree");
            }
        }

        public void UpdateNode(string path, string data)
        {
            string[] s = _helper.SplitString(path, '/');
            var node = _helper.FindNode(s, s.Length);
            node.Update(data);
        }

        public void DeleteNode(string path)
        {
            string[] s = _helper.SplitString(path, '/');
            var prevNode = _helper.FindNode(s, s.Length - 1);
            var node = prevNode.Children.Find(o => o.Name == s[s.Length - 1]);
            if (node != null)
            {
                prevNode.Children.Remove(node);
                node.Delete();
                node = null;
            }
        }

        /// <summary>
        /// To get data for a given node
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetNodeData(string path)
        {
            string[] s = _helper.SplitString(path, '/');
            var node = _helper.FindNode(s, s.Length);
            return node.Data;
        }

        /// <summary>
        /// Returns all direct children of a given node
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Tree> GetAllChildren(string path)
        {
            string[] s = _helper.SplitString(path, '/');
            var node = _helper.FindNode(s, s.Length);
            return node.Children;
        }

        /// <summary>
        /// Returns all the nodes present in the Tree in top-down order
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<Tree> GetAllNodes(Tree root)
        {
            List<Tree> res = new List<Tree>();
            _getAllNodes(root, res);
            return res;
        }

        private void _getAllNodes(Tree root, List<Tree> res)
        {
            Queue<Tree> q = new Queue<Tree>();
            if (root != null)
            {
                q.Enqueue(root);
            }
            while (q.Count != 0)
            {
                Tree temp = q.Dequeue();
                res.Add(temp);
                foreach (var t in temp.Children)
                {
                    q.Enqueue(t);
                }
            }
        }
    }
}
