using System;
using System.Collections.Generic;
using AlgorithmPractice.Algorithms.ConvexHull.Models;

namespace AlgorithmPractice.Algorithms.ConvexHull
{
    public static class GrahamsScan
    {
        private const int MaxAngle = 180;

        private class PolarAngleDescending : IComparer<Point>
        {
            private readonly Point _base;

            public PolarAngleDescending(Point @base)
            {
                _base = @base;
            }

            public int Compare(Point p1, Point p2)
            {
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

        /// <summary>
        /// Finds the convex hull of a set of points on a Cartesian plane.
        /// The first element is the lowest point, and
        /// the remaining elements are in clockwise order around the hull.
        /// </summary>
        public static Point[] Scan(Point[] source)
        {
            var plane = new Point[source.Length];

            Array.Copy(source, plane, source.Length);

            var lowIndex = FindLow(plane);
            var low = plane[lowIndex];

            Array.Sort(plane, new PolarAngleDescending(low));

            var hull = new List<Point>
            {
                plane[0],
                plane[1],
            };

            for (var i = 2; i < plane.Length; i++)
            {
                while (IsLeftTurn(SecondLast(hull), Last(hull), plane[i]))
                {
                    hull.RemoveAt(hull.Count - 1);
                }
                hull.Add(plane[i]);
            }

            return hull.ToArray();
        }

        private static Point SecondLast(List<Point> hull)
        {
            return hull.Count < 2 ? null : hull[hull.Count - 2];
        }

        private static Point Last(List<Point> hull)
        {
            return hull[hull.Count - 1];
        }
        
        private static int FindLow(Point[] plane)
        {
            var currentLowIndex = 0;
            var currentLowY = plane[currentLowIndex].Y;

            for (var i = 1; i < plane.Length; i++)
            {
                if (plane[i].Y < currentLowY)
                {
                    currentLowIndex = i;
                    currentLowY = plane[i].Y;
                }
            }

            return currentLowIndex;
        }

        private static bool IsLeftTurn(Point secondLast, Point last, Point current)
        {
            if (secondLast == null)
            {
                return false;
            }

            var p1 = secondLast;
            var p2 = last;

            var rise = p2.Y - p1.Y;
            var run = p2.X - p1.X;

            var m = rise / run;

            var y1 = last.Y;
            var x1 = last.X;

            var y = current.Y;
            var x = x1 + (y - y1) / m;

            if (rise >= 0)
            {
                return current.X <= x;
            }
            else
            {
                return x < current.X;
            }
        }
    }
}
