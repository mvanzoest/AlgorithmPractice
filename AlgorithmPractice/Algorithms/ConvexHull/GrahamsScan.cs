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
            if (points == null)
            {
                throw new ArgumentNullException(nameof(points));
            }

            points.ThrowIfNullPoints();

            if (points.Length < 3)
            {
                return points;
            }

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

        /// <summary>
        /// Returns the point with the lowest Y value.
        /// If there are multiple, it returns the first point with the lowest X value.
        /// </summary>
        private static Point FindLow(Point[] plane)
        {
            var currentLow = plane[0];

            for (var i = 1; i < plane.Length; i++)
            {
                if (System.Math.Abs(plane[i].Y - currentLow.Y) < 0.0001)
                {
                    if (plane[i].X < currentLow.X)
                    {
                        currentLow = plane[i];
                    }
                }
                else if (plane[i].Y < currentLow.Y)
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

            if (slope == 0)
            {
                return true;
            }

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

        private static void ThrowIfNullPoints(this Point[] points)
        {
            foreach (var point in points)
            {
                if (point == null)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
