using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sameer_ahmad
{
    interface ITreeMethods
    {
        void CreateNode(string path,string data);
        void UpdateNode(string path, string data);
        void DeleteNode(string path);
        string GetNodeData(string path);
        List<Tree> GetAllChildren(string path);
        List<Tree> GetAllNodes(Tree root);
    }
}
