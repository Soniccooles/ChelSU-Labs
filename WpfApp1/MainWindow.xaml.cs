using ConsoleCalculator;
using System.Windows;
using System.Windows.Controls;

namespace WPFCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Tbx_TextChanged_Expression(object sender, TextChangedEventArgs e) { }

        private void Tbx_TextChanged_RightPanels(object sender, TextChangedEventArgs e) { }

        private void Btn_Refresh(object sender, RoutedEventArgs e)
        {
            graphicPlot.Reset();
            double[] dataX;
            double[] dataY;

            dataX = CanvasDrawer.GetPointsX(tbxExpression.Text, tbxStart.Text, tbxEnd.Text, tbxStep.Text);
            dataY = CanvasDrawer.GetPointsY(tbxExpression.Text, tbxStart.Text, tbxEnd.Text, tbxStep.Text);
            graphicPlot.Plot.Add.Scatter(dataX, dataY);
            graphicPlot.Refresh();
        }
    }
}