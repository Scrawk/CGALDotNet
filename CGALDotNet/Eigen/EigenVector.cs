using System;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

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

		public bool IsZero(double eps = MathUtil.DEG_TO_RAD_64)
		{
			for (int x = 0; x < Dimension; x++)
			{
				if (!MathUtil.IsZero(this[x], eps))
					return false;
			}

			return true;
		}

		public bool IsPositive()
		{
			for (int x = 0; x < Dimension; x++)
			{
				if (this[x] < 0)
					return false;
			}

			return true;
		}

		public bool HasNAN()
		{
			for (int x = 0; x < Dimension; x++)
			{
				if (double.IsNaN(this[x]))
					return true;
			}
			return false;
		}

		public void NoNAN()
		{
			for (int x = 0; x < Dimension; x++)
			{
				if (double.IsNaN(this[x]))
					this[x] = 0;
			}
		}

		public bool IsFinite()
		{
			for (int x = 0; x < Dimension; x++)
			{
				if (!MathUtil.IsFinite(this[x]))
					return false;
			}

			return true;
		}

		public void MakeFinite()
		{
			for (int x = 0; x < Dimension; x++)
			{
				if (!MathUtil.IsFinite(this[x]))
					this[x] = 0;
			}
		}

		public bool IsConst(double eps = MathUtil.EPS_64)
		{
			var value = this[0];
			for (int x = 0; x < Dimension; x++)
			{
				if (!MathUtil.AlmostEqual(this[x], value, eps))
					return false;
			}

			return true;
		}

		public void Round(int digits)
		{
			for (int i = 0; i < Dimension; i++)
				this[i] = Math.Round(this[i], digits);
		}

		public override void Print(StringBuilder builder)
		{
			builder.AppendLine(this.ToString());

			if (this is EigenColumnVector)
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
