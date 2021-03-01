using System.Data;

namespace AdaMedicine.Net.Data.Connections
{
    /// <summary>
    /// Interfaces for types that has a CurrentTransaction property of type IDbTransaction
    /// </summary>
    public interface IHasCurrentTransaction
    {
        /// <summary>
        /// Gets the current transaction
        /// </summary>
        IDbTransaction CurrentTransaction { get; }
    }
}