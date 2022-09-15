using Microsoft.VisualBasic;
using RSBot.Core.Objects;

namespace RSBot.Default.Bot.Objects
{
    internal class TrainingArea
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The center name.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the center position.
        /// </summary>
        /// <value>
        /// The center position.
        /// </value>
        public Position CenterPosition { get; set; }

        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        /// <value>
        /// The radius.
        /// </value>
        public int Radius { get; set; }

        /// <summary>
        /// Return training area from split
        /// </summary>
        public static TrainingArea? FromSplit(string[] split)
        {
            if (!float.TryParse(split[1], out var posX))
                return null;

            if (!float.TryParse(split[2], out var posY))
                return null;

            if (!int.TryParse(split[3], out var radius))
                return null;

            return new TrainingArea
            {
                Name = split[0],
                CenterPosition = new Position
                {
                    XCoordinate = posX,
                    YCoordinate = posY
                },
                Radius = radius
            };
        }
    }
}