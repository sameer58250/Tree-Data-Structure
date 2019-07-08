using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sameer_ahmad
{
    class Listener : IListener
    {
        private TreeHelper _helper;

        public Listener(Tree root)
        {
            _helper = new TreeHelper(root);
        }

        /// <summary>
        /// Add event listener on all the children including node itself for a given path
        /// </summary>
        /// <param name="path">path of node</param>
        /// <param name="listener">listener method</param>
        public void AddEventListener(string path, listener listener)
        {
            string[] s = _helper.SplitString(path, '/');
            var node = _helper.FindNode(s, s.Length);
            _attachListener(node, listener);
        }

        /// <summary>
        /// Removes events from all children include the node itself for a given path
        /// </summary>
        /// <param name="path">path of node</param>
        /// <param name="listener">listner method</param>
        public void RemoveEventListener(string path, listener listener)
        {
            string[] s = _helper.SplitString(path, '/');
            var node = _helper.FindNode(s, s.Length);
            _removeListener(node, listener);
        }

        private void _attachListener(Tree node, listener lis)
        {
            if (node == null)
            {
                return;
            }
            node.CurrentEvent += lis;
            for (int i = 0; i < node.Children.Count; i++)
            {
                _attachListener(node.Children[i], lis);
            }
        }

        private void _removeListener(Tree node, listener lis)
        {
            if (node == null)
            {
                return;
            }
            node.CurrentEvent -= lis;
            for (int i = 0; i < node.Children.Count; i++)
            {
                _removeListener(node.Children[i], lis);
            }
        }
    }
}
