using System;
using System.IO;

namespace ECCRemover
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Environment.Exit(1);
            }
            else if (File.Exists(args[0]))
            {
                var data = File.ReadAllBytes(args[0]);
                var file = args[0];
                if (args.Length > 1)
                    file = args[1];
                using (var sw = new BinaryWriter(new FileStream(file, FileMode.CreateNew)))
                {
                    var pages = data.Length / 528;
                    var offset = 0;
                    for (var i = 0; i < pages; i++)
                    {
                        for (var j = 0; j < 512; j++)
                        {
                            sw.Write(data[offset]);
                            offset++;
                        }
                        offset += 16;
                    }
                    sw.Close();
                }
            }
            Environment.Exit(0);
        }
    }
}