using System;
using System.Text;

namespace CGALDotNet.Eigen
{
    public abstract class EigenVector : CGALObject
    {

        internal EigenVector()
        {

        }

        internal EigenVector(IntPtr ptr) : base(ptr)
        {

        }

        public abstract double this[int i] { get; set; }

        public abstract int Dimension { get; }

        public abstract double Magnitude { get; }

        public abstract void Normalize();

        public abstract void Resize(int dimension);

        public void Round(int digits)
        {
            for (int i = 0; i < Dimension; i++)
                this[i] = Math.Round(this[i], digits);
        }

        public override void Print(StringBuilder builder)
        {
            builder.AppendLine(this.ToString());
            builder.AppendLine();

            if(this is EigenColumnVector)
            {
                for (int i = 0; i < Dimension; i++)
                {
                    builder.Append(this[i].ToString());
                    if (i != Dimension - 1)
                        builder.AppendLine(",");
                    else
                        builder.AppendLine();
                }
            }
            else
            {
                for (int i = 0; i < Dimension; i++)
                {
                    builder.Append(this[i].ToString());
                    if (i != Dimension - 1)
                        builder.Append(",");
                    else
                        builder.AppendLine();
                }
            }
        }

        internal static void AreSameSize(EigenVector v1, EigenVector v2)
        {
            if (v1.Dimension != v2.Dimension)
                throw new InvalidOperationException("Vector1 must be the same size as Vector2.");
        }

    }
}
