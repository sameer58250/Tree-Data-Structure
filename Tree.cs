using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sameer_ahmad
{
    public delegate void listener(OpType operationType, Tree nodeObj);

    public class Tree
    {
        public event listener CurrentEvent;
        public string Data { get; set; }
        public string Name { get; set; }
        public List<Tree> Children { get; set; }

        public Tree()
        {
            Children = new List<Tree>();
        }

        public void Create(string data, string name)
        {
            Name = name;
            Data = data;
            if(CurrentEvent!=null){
                CurrentEvent(OpType.Created, this);
            }
        }

        public void Update(string data)
        {
            Data = data;
            if (CurrentEvent != null)
            {
                CurrentEvent(OpType.Updated, this);
            }
        }

        public void Delete()
        {
            if (CurrentEvent != null)
            {
                CurrentEvent(OpType.Deleted, this);
            }
            CurrentEvent = null;
        }

        public listener getCurrentEvent(){
            return (listener)CurrentEvent.Clone();
        }
    }

    public enum OpType
    {
        Created,
        Updated,
        Deleted
    }
}
