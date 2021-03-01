using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace AdaMedicine.Net.Core.Caching
{
    /// <summary>
    /// An abstraction for a combination of in memory and distributed cache.
    /// </summary>
    public interface ITwoLevelCache
    {
        /// <summary>
        /// Gets the memory cache
        /// </summary>
        IMemoryCache Memory { get; }

        /// <summary>
        /// Gets the distributed cache
        /// </summary>
        IDistributedCache Distributed { get; }
    }
}