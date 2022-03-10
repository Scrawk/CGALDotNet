using System;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Eigen
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class EigenVector : CGALObject
	{

		/// <summary>
		/// 
		/// </summary>
		internal EigenVector()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ptr"></param>
		internal EigenVector(IntPtr ptr) : base(ptr)
		{

		}

		/// <summary>
		/// The first value in the vector.
		/// </summary>
		public double x
        {
			get { return this[0]; }
			set { this[0] = value; }
        }

		/// <summary>
		/// The second value in the vector.
		/// </summary>
		public double y
		{
			get { return this[1]; }
			set { this[1] = value; }
		}

		/// <summary>
		/// The third value in the vector.
		/// </summary>
		public double z
		{
			get { return this[2]; }
			set { this[2] = value; }
		}

		/// <summary>
		/// The fourth value in the vector.
		/// </summary>
		public double w
		{
			get { return this[3]; }
			set { this[3] = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public abstract double this[int i] { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public abstract int Dimension { get; }

		/// <summary>
		/// 
		/// </summary>
		public abstract double Magnitude { get; }

		/// <summary>
		/// 
		/// </summary>
		public abstract void Normalize();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dimension"></param>
		public abstract void Resize(int dimension);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="eps"></param>
		/// <returns></returns>
		public bool IsZero(double eps = MathUtil.DEG_TO_RAD_64)
		{
			for (int x = 0; x < Dimension; x++)
			{
				if (!MathUtil.IsZero(this[x], eps))
					return false;
			}

			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public bool IsPositive()
		{
			for (int x = 0; x < Dimension; x++)
			{
				if (this[x] < 0)
					return false;
			}

			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public bool HasNAN()
		{
			for (int x = 0; x < Dimension; x++)
			{
				if (double.IsNaN(this[x]))
					return true;
			}
			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		public void NoNAN()
		{
			for (int x = 0; x < Dimension; x++)
			{
				if (double.IsNaN(this[x]))
					this[x] = 0;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public bool IsFinite()
		{
			for (int x = 0; x < Dimension; x++)
			{
				if (!MathUtil.IsFinite(this[x]))
					return false;
			}

			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		public void MakeFinite()
		{
			for (int x = 0; x < Dimension; x++)
			{
				if (!MathUtil.IsFinite(this[x]))
					this[x] = 0;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="eps"></param>
		/// <returns></returns>
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="digits"></param>
		public void Round(int digits)
		{
			for (int i = 0; i < Dimension; i++)
				this[i] = Math.Round(this[i], digits);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="builder"></param>
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <exception cref="InvalidOperationException"></exception>
		internal static void AreSameSize(EigenVector v1, EigenVector v2)
		{
			if (v1.Dimension != v2.Dimension)
				throw new InvalidOperationException("Vector1 must be the same size as Vector2.");
		}

	}
}
