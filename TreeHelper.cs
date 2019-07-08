using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sameer_ahmad
{
    class TreeHelper
    {
        private Tree _root;

        public TreeHelper(Tree root)
        {
            _root = root;
        }

        public Tree FindNode(string[] s, int n)
        {
            if (s[0] == "root" && n==1)
            {
                return _root;
            }
            List<Tree> temp = _root.Children;
            Tree node = null;
            for (int i = 1; i < n; i++)
            {
                node = temp.FirstOrDefault(o => o.Name == s[i]);
                if (node == null)
                {
                    throw new Exception("Full/Some part of path is not found");
                }
                else
                {
                    temp = node.Children;
                }
            }
            return node;
        }

        public string[] SplitString(string path, char c)
        {
            path = path.TrimStart(c);
            return path.Split(c);
        }
    }
}
