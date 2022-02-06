using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Jiuyong
{
	public partial class ChartData
	{
		public readonly int Width;
		public readonly int Height;
		//public readonly double[] Xs;
		//public readonly double[] Ys;
		public readonly double[,] Zs;
		//public readonly double[] Zs;

		//V -1
		//public ChartData(
		//	(double min, double max, double step) x
		//	, (double min, double max, double step) y
		//	, Func<double, double, double> f)
		//{
		//	var w = (x.max - x.min) / x.step;
		//	Width =  Math.Abs((int)w);

		//	var h = (y.max - y.min) / y.step;
		//	Height = Math.Abs((int)h);

		//	Zs = new double[Width, Height];

		//	for (int i = 0; i < x.max; i+=x.step)
		//	{
		//		for (double j = 0; j < y.max; j+=y.step)
		//		{
		//			Zs[i, j] = f(i, j);
		//		}
		//	}
		//}

		//V 0
		public ChartData(
			int width
			, int height
			, Func<int, int, double> f)
		{
			Width = width;
			Height = height;

			Zs = new double[Width, Height];
			//Zs = new double[Width * Height];

			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					Zs[i, j] = f(i, j);
					//Zs[i * width + j] = f(i, j);
				}
			}
		}
	}
}
namespace Jiuyong
{
	using System.Windows.Media.Media3D;

	/// <summary>
	/// 方便的构造的虚拟的模型。
	/// </summary>
	public partial class ChartData
	{
		/// <summary>
		/// 横向偏移。
		/// </summary>
		public double Wp { get; set; } = 0;

		/// <summary>
		/// 纵向偏移。
		/// </summary>
		public double Hp { get; set; } = 0;

		public IEnumerable<Point3D> GetPositions()
		{
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					yield return new Point3D(i + Wp, j + Hp, Zs[i, j]);
				}
			}
		}

		public IEnumerable<int> GetTriangleIndices()
		{
			for (int i = 0; i < Width - 1; i++)
			{
				for (int j = 0; j < Height - 1; j++)
				{
					var x0 = i * Width + j;

					yield return x0;
					yield return x0 + Width;
					yield return x0 + 1;

					yield return x0 + Width;
					yield return x0 + Width + 1;
					yield return x0 + 1;
				}
			}
		}
	}
}
