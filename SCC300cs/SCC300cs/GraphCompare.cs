using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace SCC300cs
{
    class GraphCompare
    {
        public double Compare(List<DataPoint> d1, List<DataPoint> d2)
        {
            if (d1.Count == d2.Count)
            {
                double[] avgs = new double[d1.Count];
                double x1, y1, x2, y2, dist;
                for (int i = 0; i < d1.Count; i++)
                {
                    x1 = d1[i].XValue;
                    y1 = d1[i].YValues[0];
                    x2 = d2[i].XValue;
                    y2 = d2[i].YValues[0];
                    dist = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
                    avgs[i] = dist < 0 ? -dist : dist;
                }
                return avgs.Average();
            }
            else
            {
                throw new ArgumentException("Input data sets must be of equal size");
            }
        }
    }
}
