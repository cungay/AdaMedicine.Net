﻿namespace AdaMedicine.Net.Core.Localization
{
    /// <summary>
    /// Abstraction for objects that supports clearing all items, like a cache or local text registry.
    /// </summary>
    /// <remarks>
    /// This is introduced so that we don't have to add a RemoveAll to ILocalTextRegistry 
    /// and break backward compatibility, while trying to resolve issue:
    /// https://github.com/volkanceylan/Serenity/issues/4568
    /// </remarks>
    public interface IRemoveAll
    {
        /// <summary>
        /// Removes all cached items from target object.
        /// </summary>
        void RemoveAll();
    }
}