using RpnLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public class Point
    {
        private float x;
        private float y;
    }
    public class CanvasDrawer
    {
        public void RefreshGraphic(string expression, string start, string end, string step, string range)
        {
            DrawAxis(start, end, step, range);
            RpnCalculator rpnCalculator = new RpnCalculator();

        }
        static void DrawAxis(string start, string end, string step, string range)
        {

        }
    }
}