using ConsoleCalculator;
using System.Drawing.Drawing2D;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using ScottPlot;
using System.Windows.Media.Effects;

namespace WPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void tbx_TextChanged_Expression(object sender, TextChangedEventArgs e){ }

        private void tbx_TextChanged_Rights(object sender, TextChangedEventArgs e) { }

        private void btn_Refresh(object sender, RoutedEventArgs e)
        {
            graphicPlot.Reset();
            double[] dataX;
            double[] dataY;
            CanvasDrawer canvasDrawer = new CanvasDrawer();
            dataX = canvasDrawer.GetPointsX(tbxExpression.Text, tbxStart.Text, tbxEnd.Text, tbxStep.Text);
            dataY = canvasDrawer.GetPointsY(tbxExpression.Text, tbxStart.Text, tbxEnd.Text, tbxStep.Text);
            graphicPlot.Plot.Add.Scatter(dataX, dataY);
            graphicPlot.Refresh();
        }
    }
}