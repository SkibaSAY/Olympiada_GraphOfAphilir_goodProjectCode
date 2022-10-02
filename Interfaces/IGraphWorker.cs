using GrafOfOphilir.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafOfOphilir.Interfaces
{
    public interface IGraphWorker
    {
        public IWriter Writer { get; }
        public void Start(IEnumerable<GraphNode> graphNodes, IWriter writer = null);
    }
}
