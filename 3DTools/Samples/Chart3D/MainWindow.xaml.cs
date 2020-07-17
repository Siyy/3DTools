using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jiuyong
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Loaded += MainWindow_Loaded;
		}

		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			T3D.Model = new GeometryModel3D
			{
				Geometry = new MeshGeometry3D
				{
					Positions = new Point3DCollection(
					new[] {
						new Point3D(-1, -1, 1),
						new Point3D(1, -1, 1),
						new Point3D(-1, -1, -1),
						new Point3D(1, -1, -1),
					}),
					TriangleIndices = new Int32Collection(new[] {
						0, 1, 2, 1, 3, 2
					}),
				},
				Material = new DiffuseMaterial
				{
					//Color = Colors.Red,
					Brush = new SolidColorBrush(Colors.Red),
				},
				BackMaterial = new DiffuseMaterial
				{
					Brush = new SolidColorBrush(Colors.Green),
				}
			};
		}
	}
}
