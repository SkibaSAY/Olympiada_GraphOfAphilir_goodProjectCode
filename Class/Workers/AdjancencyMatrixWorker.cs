using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrafOfOphilir.Class;
using GrafOfOphilir.Interfaces;

namespace GrafOfOphilir.Workers
{
    public class AdjancencyMatrixWorker:IGraphWorker
    {
        public IWriter Writer { get; }

        public AdjancencyMatrixWorker(IWriter writer)
        {
            Writer = writer;
        }
        public void Start(IEnumerable<GraphNode> graphNodes,IWriter writer = null)
        {
            if (writer == null) writer = Writer;

            var graphNodesCount = graphNodes.Count();
            var matrix = new Matrix<int>(graphNodesCount, graphNodesCount);

            for(var i = 0 ; i < graphNodesCount;i++)
            {
                var node = graphNodes.ElementAt(i);Щ
                if(node.ReferenceIds == null) continue;

                foreach (var childId in node.ReferenceIds)
                {
                    matrix[node.Id-1, childId - 1] = 1;
                    matrix[childId - 1, node.Id-1] = 1;
                }
            }

            matrix.PrintMatrix(writer);
        }
    }
}
