using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GrafOfOphilir.Class;
using GrafOfOphilir.Class.Workers;
using GrafOfOphilir.Workers;
using GrafOfOphilir.Class.Writers;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace GrafOfOphilir
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();

            //не забыть перенести в параметры args
            var url = args.Length == 0? "http://194.58.111.216:6061/input":args[0];
            StartGraphWorker(url);

            Console.ReadLine();
        }

        /// <summary>
        /// Старт задачи с обработкой графа
        /// </summary>
        /// <param name="url"></param>
        public static void StartGraphWorker(string url)
        {
            var success = true;

            #region получение выходных данных

            #region проверка валидности url
            success = Uri.IsWellFormedUriString(url,UriKind.Absolute);
            #endregion

            List<GraphNode> graphNodes = null;
            if (success)
            {
                var httpReader = new HttpReader();
                success = httpReader.Get(url, out List<GraphNode> responce);
                graphNodes = responce;
            }
            else 
                Log.Warning($"Параметр url = {url} некорретный, проверьте передаваемый параметр " +
                            $"url и повторите попытку.");

            #endregion

            if (success)
                Task.Factory.StartNew(() => WorkerStarter.Start(graphNodes));
            else
                Log.Warning($"Не удалось получить входные данные, попробуйте позже.");
        }

        /// <summary>
        /// Инициализация лога
        /// </summary>
        public static void Init()
        {
            //глобальный логгер
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(LogEventLevel.Debug)
                .WriteTo.File("logs/errors.txt", LogEventLevel.Error)
                .WriteTo.File("logs/debug",LogEventLevel.Debug)
                .CreateLogger();
        }
    }
}
