using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrafOfOphilir.Class.Writers;
using GrafOfOphilir.Interfaces;
using GrafOfOphilir.Workers;
using Serilog;

namespace GrafOfOphilir.Class.Workers
{
    /// <summary>
    /// Станция, запускающая все обработчики для графов
    /// </summary>
    public static class WorkerStarter
    {
        public static void Start(IEnumerable<GraphNode> graphNodes)
        {
            var workers = new List<IGraphWorker>()
            {
                new AdjancencyMatrixWorker(new ConsoleWriter()),
                new GraphicRepresentation(new ConsoleWriter())
            };

            foreach (var worker in workers)
            {
                try
                {
                    Log.Information($"{worker.GetType()}: начал работу.");

                    worker.Start(graphNodes);

                    Log.Information($"{worker.GetType()}: завершил работу.");
                }
                catch (Exception ex)
                {
                    Log.Error(ex,$"Произошла непредвиденная ошибка во время работы обработчика {worker.GetType()}.");
                }
            }
        }
    }
}
