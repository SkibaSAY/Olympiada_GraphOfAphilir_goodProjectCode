using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafOfOphilir.Class.Writers
{
    public class FileWriter : IWriter
    {
        public string Path { get; set; }

        public void Write(params string[] rows)
        {
            if (!File.Exists(Path))
            {
                throw new ArgumentException("Файл не найден");
            }

            using (var sw = new StreamWriter(Path))
            {
                foreach (var row in rows)
                {
                    sw.WriteLine(row);
                }
            }
        }

        public FileWriter()
        {

        }
    }
}
