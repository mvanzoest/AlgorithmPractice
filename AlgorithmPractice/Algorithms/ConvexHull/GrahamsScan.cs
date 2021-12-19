using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmPractice.Algorithms.ConvexHull.Models;

namespace AlgorithmPractice.Algorithms.ConvexHull
{
    public static class GrahamsScan
    {
        /// <summary>
        /// Finds the convex hull of a set of points on a Cartesian plane.
        /// The first element is the lowest point, and
        /// the remaining elements are in clockwise order around the hull.
        /// </summary>
        public static Point[] Scan(Point[] plane)
        {
            var lowIndex = FindLow(plane);
            var low = plane[lowIndex];
            var planeExceptLow = RemoveLow(plane, lowIndex);
            var polarAngles = CalculatePolarAngles(planeExceptLow, low).ToList();

            polarAngles.Sort();

            var hull = new List<AngledPoint>
            {
                new AngledPoint(low, 0),
                polarAngles[0]
            };

            for (var i = 1; i < polarAngles.Count; i++)
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
        
        private static Point[] RemoveLow(Point[] plane, int lowIndex)
        {
            var planeExceptLow = new Point[plane.Length - 1];

            for (var i = 0; i < lowIndex; i++)
            {
                planeExceptLow[i] = plane[i];
            }

            for (var j = lowIndex + 1; j < plane.Length; j++)
            {
                planeExceptLow[j - 1] = plane[j];
            }

            return planeExceptLow;
        }

        private static AngledPoint[] CalculatePolarAngles(Point[] plane, Point point)
        {
            var polarAngles = new AngledPoint[plane.Length];

            for (var i = 0; i < plane.Length; i++)
            {
                var p1 = point;
                var p2 = plane[i];
                var angle = System.Math.Atan2(p2.Y - p1.Y, p2.X - p1.X) * 180 / System.Math.PI;

                polarAngles[i] = new AngledPoint(p2, angle);
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

        private class AngledPoint : IComparable<AngledPoint>
        {
            public AngledPoint(Point point, double angle)
            {
                Point = point;
                Angle = angle;
            }

            public Point Point { get; }
            public double Angle { get; }

            public int CompareTo(AngledPoint other)
            {
                if (other == null || Angle < other.Angle)
                {
                    return 1;
                }
                else if (other.Angle < Angle)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
