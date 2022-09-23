using System;
using RSBot.Core.Components.Collision.Calculated;
using RSBot.Core.Objects;

namespace RSBot.Core.Components.Collision
{
    /// <summary>
    /// Taken from https://github.com/justcoding121/Advanced-Algorithms/blob/master/Advanced.Algorithms/Geometry/Intersection.cs
    /// Slightly modified to match RSBot purposes!
    /// </summary>
    internal class Intersection
    {
        public static (Position collidedAt, CalculatedCollisionLine collidedWith)? FindIntersection(CalculatedCollisionLine lineA, CalculatedCollisionLine lineB, double tolerance = 1)
        {
            double x1 = lineA.Source.XCoordinate, y1 = lineA.Source.YCoordinate;
            double x2 = lineA.Destination.XCoordinate, y2 = lineA.Destination.YCoordinate;

            double x3 = lineB.Source.XCoordinate, y3 = lineB.Source.YCoordinate;
            double x4 = lineB.Destination.XCoordinate, y4 = lineB.Destination.YCoordinate;

            double x, y;

            //lineA is vertical x1 = x2
            //slope will be infinity
            //so lets derive another solution
            if (Math.Abs(x1 - x2) < tolerance)
            {
                //compute slope of line 2 (m2) and c2
                var m2 = (y4 - y3) / (x4 - x3);
                var c2 = -m2 * x3 + y3;

                //equation of vertical line is x = c
                //if line 1 and 2 intersect then x1=c1=x
                //subsitute x=x1 in (4) => -m2x1 + y = c2
                // => y = c2 + m2x1
                x = x1;
                y = c2 + m2 * x1;
            }
            //lineB is vertical x3 = x4
            //slope will be infinity
            //so lets derive another solution
            else if (Math.Abs(x3 - x4) < tolerance)
            {
                //compute slope of line 1 (m1) and c2
                var m1 = (y2 - y1) / (x2 - x1);
                var c1 = -m1 * x1 + y1;

                //equation of vertical line is x = c
                //if line 1 and 2 intersect then x3=c3=x
                //subsitute x=x3 in (3) => -m1x3 + y = c1
                // => y = c1 + m1x3
                x = x3;
                y = c1 + m1 * x3;
            }
            //lineA & lineB are not vertical
            //(could be horizontal we can handle it with slope = 0)
            else
            {
                //compute slope of line 1 (m1) and c2
                var m1 = (y2 - y1) / (x2 - x1);
                var c1 = -m1 * x1 + y1;

                //compute slope of line 2 (m2) and c2
                var m2 = (y4 - y3) / (x4 - x3);
                var c2 = -m2 * x3 + y3;

                //solving equations (3) & (4) => x = (c1-c2)/(m2-m1)
                //plugging x value in equation (4) => y = c2 + m2 * x
                x = (c1 - c2) / (m2 - m1);
                y = c2 + m2 * x;

                //verify by plugging intersection point (x, y)
                //in orginal equations (1) & (2) to see if they intersect
                //otherwise x,y values will not be finite and will fail this check
                if (!(Math.Abs(-m1 * x + y - c1) < tolerance
                    && Math.Abs(-m2 * x + y - c2) < tolerance))
                {
                    return null;
                }
            }

            //x,y can intersect outside the line segment since line is infinitely long
            //so finally check if x, y is within both the line segments
            if (IsInsideLine(lineA, x, y) &&
                IsInsideLine(lineB, x, y))
            {
                return new(new Position((float)x, (float)y), lineB);
            }
            //return default null (no intersection)
            return null;
        }

        /// <summary>
        /// Returns true if given point(x,y) is inside the given line segment
        /// </summary>
        /// <param name="line"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static bool IsInsideLine(CalculatedCollisionLine line, double x, double y)
        {
            var isInX = (x >= line.Source.XCoordinate && x <= line.Destination.XCoordinate
                         || x >= line.Destination.XCoordinate && x <= line.Source.XCoordinate);

            var isInY = (y >= line.Source.YCoordinate && y <= line.Destination.YCoordinate
                         || y >= line.Destination.YCoordinate && y <= line.Source.YCoordinate);

            return isInX && isInY;
        }
    }
}