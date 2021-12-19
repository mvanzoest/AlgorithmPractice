using System;
using System.Collections.Generic;
using AlgorithmPractice.Algorithms.ConvexHull.Compare;
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
        public static Point[] Scan(Point[] points)
        {
            var plane = new Point[points.Length];

            Array.Copy(points, plane, points.Length);
            
            var low = FindLow(plane);

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

        private static Point FindLow(Point[] plane)
        {
            var currentLow = plane[0];

            for (var i = 1; i < plane.Length; i++)
            {
                if (plane[i].Y < currentLow.Y)
                {
                    currentLow = plane[i];
                }
            }

            return currentLow;
        }

        private static Point SecondLast(List<Point> hull)
        {
            return hull.Count < 2 ? null : hull[hull.Count - 2];
        }

        private static Point Last(List<Point> hull)
        {
            return hull[hull.Count - 1];
        }

        private static bool IsLeftTurn(Point secondLastPoint, Point lastPoint, Point nextPoint)
        {
            if (secondLastPoint == null)
            {
                return false;
            }

            var rise = lastPoint.Y - secondLastPoint.Y;
            var run = lastPoint.X - secondLastPoint.X;

            var slope = rise / run;

            var boundary = lastPoint.X + (nextPoint.Y - lastPoint.Y) / slope;
            
            if (rise >= 0)
            {
                return nextPoint.X <= boundary;
            }
            else
            {
                return boundary < nextPoint.X;
            }
        }
    }
}
