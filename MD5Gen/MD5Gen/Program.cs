namespace MD5Gen {
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    internal static class Program {
        private static void Main(string[] args) {
            foreach(var arg in args) {
                try {
                    Console.WriteLine("Generating hash for {0}", arg);
                    var tmp = new FileStream(arg, FileMode.Open);
                    var hash = MD5.Create().ComputeHash(tmp);
                    tmp.Close();
                    var builder = new StringBuilder();
                    foreach(var h in hash)
                        builder.Append(String.Format("{0:X2}", h));
                    File.WriteAllText(arg + ".md5", builder.ToString());
                    Console.WriteLine("The hash is: {0}", builder);
                }
                catch(Exception ex) {
                    Console.WriteLine(ex);
                    //Console.ReadLine();
                }
            }
        }
    }
}