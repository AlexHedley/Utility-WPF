﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Utility_WPF.Core.Extensions
{
    /// <summary>
    /// Collection Extensions
    /// Class that provides extension methods to Collection
    /// 
    /// Prism: Dynamically Discover and Load Modules at Runtime
    /// August 6, 2013 - 13 min read
    /// https://brianlagunas.com/prism-dynamically-discover-and-load-modules-at-runtime/
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Add a range of items to a collection.
        /// </summary>
        /// <typeparam name="T">Type of objects within the collection.</typeparam>
        /// <param name="collection">The collection to add items to.</param>
        /// <param name="items">The items to add to the collection.</param>
        /// <returns>The collection.</returns>
        /// <exception cref="System.ArgumentNullException">An <see cref="System.ArgumentNullException"/> is thrown if <paramref name="collection"/> or <paramref name="items"/> is <see langword="null"/>.</exception>
        public static Collection<T> AddRange<T>(this Collection<T> collection, IEnumerable<T> items)
        {
            if (collection == null) throw new System.ArgumentNullException("collection");
            if (items == null) throw new System.ArgumentNullException("items");

            foreach (var each in items)
            {
                collection.Add(each);
            }

            return collection;
        }
    }
}
