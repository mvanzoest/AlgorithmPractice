using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmPractice.Algorithms.ConvexHull.Models;

namespace AlgorithmPractice.Algorithms.ConvexHull
{
    public static class GrahamsScan
    {
        private const int MaxAngle = 180;

        private class PolarAngleDescending : IComparer<AngledPoint>
        {
            public int Compare(AngledPoint x, AngledPoint y)
            {
                if (x?.Angle < y?.Angle)
                {
                    return 1;
                }
                else if (y?.Angle < x?.Angle)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Finds the convex hull of a set of points on a Cartesian plane.
        /// The first element is the lowest point, and
        /// the remaining elements are in clockwise order around the hull.
        /// </summary>
        public static Point[] Scan(Point[] plane)
        {
            var lowIndex = FindLow(plane);
            var low = plane[lowIndex];
            var polarAngles = CalculatePolarAngles(plane, low).ToList();

            polarAngles.Sort(new PolarAngleDescending());

            var hull = new List<AngledPoint>
            {
                polarAngles[0],
                polarAngles[1],
            };

            for (var i = 2; i < polarAngles.Count; i++)
            {
                while (IsLeftTurn(SecondLast(hull), Last(hull), polarAngles[i]))
                {
                    hull.RemoveAt(hull.Count - 1);
                }
                hull.Add(polarAngles[i]);
            }

            return hull.Select(p => p.Point).ToArray();
        }

        private static AngledPoint SecondLast(List<AngledPoint> hull)
        {
            return hull.Count < 2 ? null : hull[hull.Count - 2];
        }

        private static AngledPoint Last(List<AngledPoint> hull)
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

        private static AngledPoint[] CalculatePolarAngles(Point[] plane, Point point)
        {
            var polarAngles = new AngledPoint[plane.Length];

            for (var i = 0; i < plane.Length; i++)
            {
                var p1 = point;
                var p2 = plane[i];

                if (p1 == p2)
                {
                    polarAngles[i] = new AngledPoint(p2, MaxAngle);
                }
                else
                {
                    var angle = System.Math.Atan2(p2.Y - p1.Y, p2.X - p1.X) * MaxAngle / System.Math.PI;
                    polarAngles[i] = new AngledPoint(p2, angle);
                }
            }

            return polarAngles;
        }

        private static bool IsLeftTurn(AngledPoint secondLast, AngledPoint last, AngledPoint current)
        {
            if (secondLast == null)
            {
                return false;
            }

            var p1 = secondLast.Point;
            var p2 = last.Point;

            var rise = p2.Y - p1.Y;
            var run = p2.X - p1.X;

            var m = rise / run;

            var y1 = last.Point.Y;
            var x1 = last.Point.X;

            var y = current.Point.Y;
            var x = x1 + (y - y1) / m;

            if (rise >= 0)
            {
                return current.Point.X <= x;
            }
            else
            {
                return x < current.Point.X;
            }
        }

        private class AngledPoint
        {
            public AngledPoint(Point point, double angle)
            {
                Point = point;
                Angle = angle;
            }

            public Point Point { get; }
            public double Angle { get; }
        }
    }
}
