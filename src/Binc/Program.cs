using Antlr4.Runtime;
using binc.src.Binc.Parser;
using System;
using System.IO;

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
                options.OptionSet.WriteOptionDescriptions(Console.Out);
            } else if (options.InputFilename == null) {
                Console.Error.WriteLine("fatal error: no input file");
                Console.Error.WriteLine();
                Console.Error.WriteLine("usage: binc [options...] <input_file>");
                Console.Error.WriteLine();
                Console.Error.WriteLine("Options:");
                options.OptionSet.WriteOptionDescriptions(Console.Error);
            } else {
                // Parse the file
                var file = File.OpenText(options.InputFilename);
                var inputStream = new AntlrInputStream(file);
                var lexer = new BincLexer(inputStream);
                var tokenStream = new CommonTokenStream(lexer);
                var parser = new BincParser(tokenStream);
                var compilationUnit = parser.compilationUnit();
            }
        }
    }
}
