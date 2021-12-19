namespace AlgorithmPractice.Algorithms.ConvexHull.Models
{
    /// <summary>
    /// Represents a point on a Cartesian plane.
    /// </summary>
    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
