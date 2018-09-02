using System.Collections.Generic;
using NDesk.Options;

namespace Binc.Compiler
{
    public class CompilerOptions
    {
        public string InputFilename;

        public bool ShowHelp = false;

        List<string> mArguments = new List<string>();

        public List<string> Arguments
        {
            get { return mArguments; }
        }

        public static CompilerOptions ParseCommandLineArguments(string[] args)
        {
            var options = new CompilerOptions();
            var optionSet = new OptionSet() {
                {"help", v => options.ShowHelp = true}
            };

            options.mArguments.AddRange(optionSet.Parse(args));
            return options;
        }
    }
}