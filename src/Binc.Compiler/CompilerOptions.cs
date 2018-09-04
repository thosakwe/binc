using System.Collections.Generic;
using NDesk.Options;

namespace Binc.Compiler
{
    public class CompilerOptions
    {
        private List<string> mArguments = new List<string>();
        private OptionSet mOptionSet;

        public string InputFilename;

        public bool ShowHelp = false;


        public List<string> Arguments
        {
            get { return mArguments; }
        }


        public OptionSet OptionSet
        {
            get { return mOptionSet; }
        }

        public static CompilerOptions ParseCommandLineArguments(string[] args)
        {
            var options = new CompilerOptions();
            var optionSet = new OptionSet();

            optionSet.Add("h|help", "Display this help information.", _ => options.ShowHelp = true);

            var rest = optionSet.Parse(args);

            if (rest.Count > 0) {
                options.InputFilename = rest[0];
                rest.RemoveAt(0);
            }

            options.mArguments.AddRange(rest);
            options.mOptionSet = optionSet;
            return options;
        }
    }
}