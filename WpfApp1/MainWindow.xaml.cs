using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsoleCalculator;
using RpnLogic;

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
        private void tbx_TextChanged_Expression(object sender, TextChangedEventArgs e) { }

        private void tbx_TextChanged_Rights(object sender, TextChangedEventArgs e) { }
        private void btn_Click(object sender, RoutedEventArgs e) 
        {
            CanvasDrawer.RefreshGraphic(tbkExpression, tbkStart, tbkEnd, tbkStep, tbkRange);
        }
    }
}