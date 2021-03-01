using AdaMedicine.Net.Data.Mapping.Join;
using System.Collections.Generic;

namespace AdaMedicine.Net.Data.Query
{
    /// <summary>
    /// Interface for row type that provides a list of its joins
    /// </summary>
    public interface IHaveJoins
    {
        /// <summary>
        /// List of all joins in entity</summary>
        IDictionary<string, Join> Joins { get; }
    }
}
