using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafOfOphilir.Class.Writers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(params string[] rows)
        {
            foreach (var row in rows)
            {
                Console.WriteLine(row);
            }
        }
    }
}
