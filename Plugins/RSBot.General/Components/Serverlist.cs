using RSBot.General.Models;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.General.Components
{
    public static class Serverlist
    {
        /// <summary>
        /// Gets or sets the servers.
        /// </summary>
        /// <value>
        /// The servers.
        /// </value>
        public static List<Server> Servers { get; set; }

        /// <summary>
        /// Gets the server by its name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static Server GetServerByName(string name)
        {
            return Servers.FirstOrDefault(s => s.Name.ToLower() == name.ToLower());
        }
    }
}