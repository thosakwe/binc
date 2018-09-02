using System;

namespace Binc
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = Compiler.CompilerOptions.ParseCommandLineArguments(args);

            if (options.ShowHelp) {
                Console.WriteLine("usage: binc [options...] <input_file>");
                Console.WriteLine();
                Console.WriteLine("Options:");
                options.OptionSet.WriteOptionDescriptions(System.Console.Out);
            } else {
                Console.WriteLine("TODO: Anything else");
            }
        }
    }
}
