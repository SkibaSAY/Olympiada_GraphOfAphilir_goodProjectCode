using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrafOfOphilir.Interfaces;

namespace GrafOfOphilir.Class.Workers
{
    public class GraphicRepresentation : IGraphWorker
    {
        public IWriter Writer { get; }

        public GraphicRepresentation(IWriter writer)
        {
            Writer = writer;
        }

        public void Start(IEnumerable<GraphNode> graphNodes, IWriter writer = null)
        {
            if (writer == null) writer = Writer;

            //зациклился на коде и не успеваю основное
            //+ не придумал адекватного алгоритма, предполагал перебор с пошаговым подключением деталей
            //проверка возможности подключения через попытки соединить(метод Matrix.Merge()) детали(деталь = матрица детали)
            //в разных их формах
            //под разными формами понимается транспонированная матрица, повернётая, отзеркаленная и тд.

            throw new ArgumentException("Функционал не готов к использованию");
        }
    }
}
