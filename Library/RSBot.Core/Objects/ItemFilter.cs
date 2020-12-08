using RSBot.Core.Client.ReferenceObjects;
using System.Collections.Generic;

namespace RSBot.Core.Objects
{
    public class ItemFilter
    {
        /// <summary>
        /// Gets or sets the filters.
        /// </summary>
        /// <value>
        /// The filters.
        /// </value>
        public List<string> Filters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemFilter"/> class.
        /// </summary>
        public ItemFilter()
        {
            Filters = new List<string>();
        }

        /// <summary>
        /// Returns a boolean indicating if the given item should be sold or not.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public bool Invoke(RefObjItem item)
        {
            return Filters.Contains(item.CodeName);
        }

        /// <summary>
        /// Sells the item.
        /// </summary>
        /// <param name="codeName">Name of the code.</param>
        /// <returns></returns>
        public bool Invoke(string codeName)
        {
            return Filters.Contains(codeName);
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="codeName">Name of the code.</param>
        public void AddItem(string codeName)
        {
            if (!Filters.Contains(codeName))
                Filters.Add(codeName);
        }

        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="codeName">Name of the code.</param>
        public void RemoveItem(string codeName)
        {
            if (Filters.Contains(codeName))
                Filters.Remove(codeName);
        }
    }
}