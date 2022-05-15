namespace RSBot.Core.Objects.Inventory
{
    /// <summary>
    /// Supports cloning.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    public interface ICloneable<T>
    {
        /// <summary>
        /// Creates a new T instance that is a copy of the current instance.
        /// </summary>
        /// <returns>The clone of the current instance.</returns>
        T Clone();
    }
}
