using RpnLogic;
namespace ConsoleCalculator
{
    public class CanvasDrawer
    {
        public static double[] GetPointsX(string expression, string start, string end, string step)
        {
            int pointsNumber = (int)Math.Floor(((double.Parse(end) - double.Parse(start)) / double.Parse(step) + 1));
            double[] dataX = new double[pointsNumber];
            for (double i = double.Parse(start), j = 0; j <= pointsNumber - 1; j++, i = i + 1 * double.Parse(step))
            {
                dataX[(int)j] = i;
            }
            return dataX;
        }
        public static double[] GetPointsY(string expression, string start, string end, string step)
        {
            int pointsNumber = (int)Math.Floor(((double.Parse(end) - double.Parse(start)) / double.Parse(step) + 1));
            double[] dataY = new double[pointsNumber];
            for (double i = double.Parse(start), j = 0; j <= pointsNumber - 1; j++, i = Math.Round(i + 1 * Math.Round(double.Parse(step), 10), 10))
            {
                dataY[(int)j] = RpnCalculator.CalculateExpression(expression, Convert.ToString(i));
            }
            return dataY;
        }
    }
}