namespace Binc.Analysis
{
    public class BincNumericType : BincType
    {
        private int mSizeInBytes;
        private string mName;

        private bool mIsIntegral;

        BincNumericType(string name, int sizeInBytes, bool isIntegral = true)
        {
            mName = name;
            mSizeInBytes = sizeInBytes;
            mIsIntegral = isIntegral;
        }

        public override int SizeInBytes
        {
            get { return mSizeInBytes; }
        }

        public string Name
        {
            get { return mName; }
        }

        public bool IsIntegral
        {
            get { return mIsIntegral; }
        }

        public override bool IsExactly(BincType other)
        {
            var numeric = other as BincNumericType;

            if (other == null)
            {
                return false;
            }
            else
            {
                return numeric.Name == Name && numeric.SizeInBytes == SizeInBytes && numeric.IsIntegral == IsIntegral;
            }
        }
    }
}