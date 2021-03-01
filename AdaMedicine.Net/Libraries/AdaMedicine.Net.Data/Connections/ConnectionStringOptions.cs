﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace AdaMedicine.Net.Data.Connections
{
    /// <summary>
    /// Connection string options
    /// </summary>
    public class ConnectionStringOptions : Dictionary<string, ConnectionStringEntry>, 
        IOptions<ConnectionStringOptions>
    {
        /// <summary>
        /// Default sectionkey for ConnectionStringOptions
        /// </summary>
        public const string SectionKey = "Data";

        /// <summary>
        /// Creates a new instance
        /// </summary>
        public ConnectionStringOptions()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        /// <summary>
        /// Returns this
        /// </summary>
        public ConnectionStringOptions Value => this;
    }
}