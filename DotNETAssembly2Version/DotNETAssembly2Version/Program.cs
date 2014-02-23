namespace DotNETAssembly2Version {
    using System;
    using System.IO;
    using System.Reflection;

    internal static class Program {
        private static void Main(string[] args) {
            if(args.Length != 1)
                Environment.Exit(1);
            if(!File.Exists(args[0]))
                Environment.Exit(2);
            Console.WriteLine(Assembly.ReflectionOnlyLoadFrom(args[0]).GetName().Version);
        }
    }
}