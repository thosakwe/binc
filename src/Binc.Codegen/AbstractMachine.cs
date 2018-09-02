namespace Binc.Codegen
{
    abstract class AbstractMachine
    {
        public virtual string Name { get; }

        public virtual int Bitness { get; }
    }
}