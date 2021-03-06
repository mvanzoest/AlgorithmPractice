using System.Collections.Generic;
using System.Diagnostics;
using AlgorithmPractice.Algorithms.ConvexHull.Models;

namespace AlgorithmPractice.Algorithms.ConvexHull.Compare
{
    public class PolarAngleDescending : IComparer<Point>
    {
        private const int MaxAngle = 180;

        private readonly Point _base;

        public PolarAngleDescending(Point @base)
        {
            _base = @base;
        }

        public int Compare(Point p1, Point p2)
        {
            Debug.Assert(p1 != null);
            Debug.Assert(p2 != null);

            var p1Angle = GetAngle(p1);
            var p2Angle = GetAngle(p2);

            if (p1Angle < p2Angle)
            {
                return 1;
            }
            else if (p2Angle < p1Angle)
            {
                return -1;
            }
            else if (p1.X > p2.X)
            {
                return 1;
            }
            else if (p1.X < p2.X)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private double GetAngle(Point p)
        {
            if (p == _base)
            {
                return MaxAngle;
            }
            return System.Math.Atan2(p.Y - _base.Y, p.X - _base.X) * MaxAngle / System.Math.PI;
        }
    }
}