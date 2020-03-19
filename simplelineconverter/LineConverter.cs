using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace simplelinereader
{
    class LineConverter
    {
        public static void SendMsg(String str)
        {
            Console.WriteLine(str); Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Console.Title = "LineConverter";

            Console.Write("input file name -> ");
            var nameOfInputFile = Console.ReadLine();

            if (nameOfInputFile.Length <= 0)
            {
                SendMsg("wrong name");
                return;
            }

            if (File.Exists(nameOfInputFile) == false)
            {
                SendMsg("can't find file");
                return;
            }

            var AllLines = File.ReadAllLines(nameOfInputFile);

            int count = AllLines.Length;

            if (count <= 0)
            {
                SendMsg("file is empty");
                return;
            }

            Console.WriteLine("line count -> {0}", count);

            var sym = ':';
            Console.WriteLine("symbol which will divide -> {0}", sym);

            Console.Write("output file name -> ");
            var nameOfoutputFile = Console.ReadLine();

            if (nameOfoutputFile.Length <= 0)
            {
                SendMsg("wrong file name");
                return;
            }

            StreamWriter SW = new StreamWriter(new FileStream(nameOfoutputFile, FileMode.Create, FileAccess.Write));

            Console.WriteLine("writing to file in login:pass type");
            for (int i = 0; i < count; i++)
            {
                String[] parts = AllLines[i].Split(sym);

                SW.Write("{0}:{1}\n", parts[0], parts[1]);
            }

            SW.Close();

            Console.WriteLine("Done! File {0} successfully saved", nameOfoutputFile);

            Console.ReadLine();
        }
    }
}
