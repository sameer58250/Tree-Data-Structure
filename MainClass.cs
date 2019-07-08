using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sameer_ahmad
{
    public class MainClass
    {
        private Tree _root;
        private ITreeMethods _trm;
        private IListener _lis;

        public MainClass(string rootData)
        {
            _root = new Tree();
            _root.Name = "root";
            _root.Data = rootData;
            _trm = new TreeMethods(_root);
            _lis = new Listener(_root);
        }

        public void AddEventListener(string path, listener lis)
        {
            try
            {
                _lis.AddEventListener(path, lis);
            }
            catch (Exception ex)
            {
                throw new Exception("faied to register event " + ex.Message);
            }
        }

        public void RemoveEventListener(string path, listener lis)
        {
            try
            {
                _lis.RemoveEventListener(path, lis);
            }
            catch (Exception ex)
            {
                throw new Exception("faied to unregister event " + ex.Message);
            }
        }

        public void Create(string path,string data){
            try
            {
                _trm.CreateNode(path, data);
            }
            catch (Exception ex)
            {
                throw new Exception("failed to create node " + ex.Message);
            }
        }

        public void Update(string path, string data)
        {
            try
            {
                _trm.UpdateNode(path, data);
            }
            catch (Exception ex)
            {
                throw new Exception("failed to update node " + ex.Message);
            }
        }

        public void Delete(string path)
        {
            try
            {
                _trm.DeleteNode(path);
            }
            catch (Exception ex)
            {
                throw new Exception("failed to delete node " + ex.Message);
            }
        }

        public string Get(string path)
        {
            try
            {
                return _trm.GetNodeData(path);
            }
            catch (Exception ex)
            {
                throw new Exception("failed to read node " + path + ": " + ex.Message);
            }
        }

        public List<Tree> List(string path)
        {
            try
            {
                return _trm.GetAllChildren(path);
            }
            catch (Exception ex)
            {
                throw new Exception("failed to fetch all childs " + ex.Message);
            }
        }

        public List<Tree> GetAllNodes()
        {
            return _trm.GetAllNodes(_root);
        }
    }
}
