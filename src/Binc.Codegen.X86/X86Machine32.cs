namespace Binc.Codegen.X86
{
    class X86Machine32 : AbstractMachine
    {
        public override string Name
        {
            get { return "x86"; }
        }

        public override int Bitness
        {
            get { return 32; }
        }
    }
}