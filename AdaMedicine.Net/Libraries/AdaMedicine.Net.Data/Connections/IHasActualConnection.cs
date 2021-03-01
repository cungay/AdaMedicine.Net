﻿using System.Data;

namespace AdaMedicine.Net.Data.Connections
{
    /// <summary>
    /// Interfaces for types that has an ActualConnection property of type IDbConnection
    /// </summary>
    public interface IHasActualConnection
    {
        /// <summary>
        /// Gets the actual connection
        /// </summary>
        IDbConnection ActualConnection { get; }
    }
}