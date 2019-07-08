using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sameer_ahmad
{
    interface IListener
    {
        void AddEventListener(string path, listener listener);
        void RemoveEventListener(string path, listener listener);
    }
}
