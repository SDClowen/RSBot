using RSBot.Core.Objects;
using System.Numerics;

namespace RSBot.Core.Extensions
{
    public static class PositionExtension
    {
        /// <summary>
        /// To the vector2.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        public static Vector2 ToVector2(this Position position)
        {
            return new Vector2(position.XCoordinate, position.YCoordinate);
        }
    }
}