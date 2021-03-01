using System.Data;

namespace AdaMedicine.Net.Data.Connections
{
    /// <summary>
    /// Interfaces for types that has an CommandTimeout property that
    /// determines the default command timeout for that connection
    /// </summary>
    public interface IHasCommandTimeout
    {
        /// <summary>
        /// Gets the command timeout
        /// </summary>
        int? CommandTimeout { get; set; }
    }
}