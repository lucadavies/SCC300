using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCC300cs
{
    class GraphCompare
    {
        List<List<Point>> graphs;
        List<string> names;

        public GraphCompare()
        {
            graphs = new List<List<Point>>();
        }

        public void addGraph(List<Point> d, string name)
        {
            graphs.Add(d);
            names.Add(name);
        }

        //public string FindClosestMatch(List<Point> d)
        //{
        //    double dMax = double.NegativeInfinity;
        //    double dMin = 0;
        //    foreach (Point p in d)
        //    {
        //        if (p.x > dMax)
        //        {
        //            dMax = p.x;
        //        }
        //    }
        //    foreach (List<Point> g in graphs)
        //    {
        //        foreach (Point p in g)
        //        {
        //            p.x = (((p.x - 0) * (dMax - dMin)) / 1);
        //        }
        //    }
        //}

        public double Compare(List<Point> d1, List<Point> d2)
        {
            if (d1.Count == d2.Count)
            {
                double[] avgs = new double[d1.Count];
                double dist;
                for (int i = 0; i < d1.Count; i++)
                {
                    dist = Math.Sqrt(Math.Pow(d1[i].x - d2[i].x, 2) + Math.Pow(d1[i].y - d2[i].y, 2));
                    avgs[i] = dist < 0 ? -dist : dist;
                }
                return avgs.Average();
            }
            else
            {
                throw new ArgumentException("Input data sets must be of equal size");
            }
        }

        public struct Point
        {
            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public double x;
            public double y;
        }
    }
}
