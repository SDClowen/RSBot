using RSBot.Core.Components.Collision;
using RSBot.Core.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace RSBot.Core.Components
{
    public class CollisionManager
    {
        /// <summary>
        /// Gets the regions.
        /// </summary>
        /// <value>
        /// The regions.
        /// </value>
        public static List<Objects.Region> LoadedRegions { get; private set; }

        /// <summary>
        /// Gets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        public static Objects.Region Region { get; private set; }

        private static CollisionLoader _collisionLoader;

        private static List<Line> _collisions;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        internal static void Initialize()
        {
            var collisionFile = Path.Combine(Environment.CurrentDirectory, "Data", "Game", "map.rsc");
            var collisionIndexFile = Path.Combine(Environment.CurrentDirectory, "Data", "Game", "map.rsci");

            if (!File.Exists(collisionFile) || !File.Exists(collisionIndexFile))
            {
                Log.Error("Could not find collision files, collision detection will not be functional.");
                return;
            }

            _collisionLoader = new CollisionLoader(collisionFile, collisionIndexFile);
        }

        /// <summary>
        /// Updates the specified region identifier.
        /// </summary>
        /// <param name="regionId">The region identifier.</param>
        internal static void Update(ushort regionId)
        {
            if (_collisionLoader == null)
                return;

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            Region = new Objects.Region(regionId);
            LoadedRegions = Objects.Region.GetSurroundingRegions(Region.XSector, Region.YSector);

            var rawLines = new Dictionary<int, List<Line>>();

            var index = 0; //0-8
            foreach (var region in LoadedRegions)
            {
                rawLines.Add(index, _collisionLoader.GetCollisions(region.Id));
                index++;
            }

            //Take all "raw" lines and recalculate their positions to match the 3x3 grid.
            _collisions = TranslatePoints(rawLines);

            stopWatch.Stop();

            Log.Debug($"[CollisionManager] {LoadedRegions.Count} regions with a total of {_collisions.Count} collisions loaded in {stopWatch.ElapsedMilliseconds}ms");
        }

        /// <summary>
        /// Determines whether [has collision between] [the specified source and destionation].
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>
        ///   <c>true</c> if [has collision between] [the specified a]; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasCollisionBetween(Position source, Position destination)
        {
            var offsetSource = GetOffsetByRegionIndex(GetRegionIndexFromPosition(source));
            var offsetDestination = GetOffsetByRegionIndex(GetRegionIndexFromPosition(destination));

            if(offsetSource.X == 1920 && offsetSource.Y == 1920 && 
               offsetDestination.X == 1920 && offsetDestination.Y == 1920)
                return false; // when source and destionation positions are x-y = 1920 its bugging

            //Position -> SharpDX.Point
            var pointSource = new Point
            {
                X = Convert.ToInt32(offsetSource.X + source.XOffset),
                Y = Convert.ToInt32(offsetSource.Y + (1920 - source.YOffset))
            };

            //Position -> SharpDX.Point
            var pointDestination = new Point
            {
                X = Convert.ToInt32(offsetDestination.X + destination.XOffset),
                Y = Convert.ToInt32(offsetDestination.Y + (1920 - destination.YOffset))
            };

            //It might be possible, that the player is standing right next to an obstacle, that would cause calculation issues and false positives,
            //Therefore it's required to reset the source point to a point right next to the source and between source and destination.
            var pointBetweenSourceAndDestination = CalculatePointBetweenPoints(pointSource, pointDestination, 2); //2 = size of player.. or at least kind of.
            if (CollisionDetector.HasCollisionBetween(pointSource, pointBetweenSourceAndDestination, _collisions))
                pointSource = pointBetweenSourceAndDestination;

            return CollisionDetector.HasCollisionBetween(pointSource, pointDestination, _collisions);
        }

        /// <summary>
        /// Translates the collision points (relative for each sector) to absolute points in the sector grid.
        /// </summary>
        private static List<Line> TranslatePoints(Dictionary<int, List<Line>> rawLines)
        {
            var result = new List<Line>();

            var index = 0;
            foreach (var region in rawLines.Keys)
            {
                var gridOffset = GetOffsetByRegionIndex(region);
                var lines = rawLines[index];

                var calculatedLines = new List<Line>(lines.Count);

                foreach (var line in lines)
                {
                    //Recalculate the obstacle position to match the grid (3x3) instead of only one sector.
                    var translatedLine = new Line
                    {
                        Source = new Point
                        (
                            Convert.ToInt32(gridOffset.X + line.Source.X),
                            Convert.ToInt32(gridOffset.Y + line.Source.Y)
                        ),
                        Destination = new Point
                        (
                            Convert.ToInt32(gridOffset.X + line.Destination.X),
                            Convert.ToInt32(gridOffset.Y + line.Destination.Y)
                        )
                    };

                    calculatedLines.Add(translatedLine);
                }

                result.AddRange(calculatedLines);

                index++;
            }

            return result;
        }

        /// <summary>
        /// Gets the x offset.
        /// </summary>
        /// <param name="regionIndex">Index of the region.</param>
        /// <returns></returns>
        private static Point GetOffsetByRegionIndex(int regionIndex)
        {
            var offsetX = 0;
            var offsetY = 0;

            switch (regionIndex)
            {
                case 0: //Top left
                    offsetX = 0;
                    offsetY = 0;
                    break;

                case 1: //Top center
                    offsetX = 1920;
                    offsetY = 0;
                    break;

                case 2: //Top right
                    offsetX = 1920 * 2;
                    offsetY = 0;
                    break;

                case 3: //Center left
                    offsetX = 0;
                    offsetY = 1920;
                    break;

                case 4: //Center center
                    offsetX = 1920;
                    offsetY = 1920;
                    break;

                case 5: //Center right
                    offsetX = 1920 * 2;
                    offsetY = 1920;
                    break;

                case 6: //Bottom left
                    offsetX = 0;
                    offsetY = 1920 * 2;
                    break;

                case 7: //Bottom center
                    offsetX = 1920;
                    offsetY = 1920 * 2;
                    break;

                case 8: //Bottom right
                    offsetX = 1920 * 2;
                    offsetY = 1920 * 2;
                    break;
            }

            return new Point(offsetX, offsetY);
        }

        /// <summary>
        /// Gets the region index from position.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        private static int GetRegionIndexFromPosition(Position position)
        {
            for (var i = 0; i < LoadedRegions.Count; i++)
                if (LoadedRegions[i].Id == position.RegionID)
                    return i;

            return -1;
        }

        /// <summary>
        /// Calculates the point between points.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="distance">The distance.</param>
        /// <returns></returns>
        private static Point CalculatePointBetweenPoints(Point a, Point b, int distance)
        {
            // a. calculate the vector from o to g:
            double vectorX = b.X - a.X;
            double vectorY = b.Y - a.Y;

            // b. calculate the proportion of hypotenuse
            var factor = distance / Math.Sqrt(vectorX * vectorX + vectorY * vectorY);

            // c. factor the lengths
            vectorX *= factor;
            vectorY *= factor;

            // d. calculate and Draw the new vector,
            return new Point((int)(a.X + vectorX), (int)(a.Y + vectorY));
        }
    }
}