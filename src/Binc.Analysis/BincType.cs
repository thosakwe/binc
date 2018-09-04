namespace Binc.Analysis
{
    public abstract class BincType
    {
        public virtual int SizeInBytes { get; }

        public abstract bool IsExactly(BincType other);
    }
}