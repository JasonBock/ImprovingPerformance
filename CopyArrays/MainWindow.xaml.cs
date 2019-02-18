using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace CopyArrays
{
	public partial class MainWindow 
		: Window
	{
		public MainWindow()
		{
			this.InitializeComponent();
		}

		private void OnRunHalfSecondFunctionClick(object sender, RoutedEventArgs e)
		{
			this.Cursor = Cursors.Wait;
			Thread.Sleep(500);
			this.Cursor = Cursors.Arrow;
		}

		private void OnRunThreeSecondFunctionClick(object sender, RoutedEventArgs e)
		{
			this.Cursor = Cursors.Wait;
			Thread.Sleep(3000);
			this.Cursor = Cursors.Arrow;
		}

		private void OnRunFrameworkCopyClick(object sender, RoutedEventArgs e)
		{
			this.Cursor = Cursors.Wait;
			this.RunCopy<FrameworkArrayCopier<string>>();
			this.Cursor = Cursors.Arrow;
		}

		private void OnRunManualCopyClick(object sender, RoutedEventArgs e)
		{
			this.Cursor = Cursors.Wait;
			this.RunCopy<ManualArrayCopier<string>>();
			this.Cursor = Cursors.Arrow;
		}

		private void RunCopy<T>()
			where T: ArrayCopier<string>, new()
		{
			if (int.TryParse(this.NumberOfItems.Text, out var numberOfItems))
			{
				var source = new string[numberOfItems];

				for (var i = 0; i < numberOfItems; i++)
				{
					source[i] = Guid.NewGuid().ToString();
				}

				var copier = new T();
				copier.Copy(source);
			}
		}
	}
}
