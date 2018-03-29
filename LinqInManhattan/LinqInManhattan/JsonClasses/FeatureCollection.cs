using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LinqInManhattan.JsonClasses
{
    /// <summary>
    /// Represents a FeatureCollection JSON object in C#
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    class FeatureCollection : IList<Feature>
    {
        [JsonProperty]
        public string Type { get; set; }
        [JsonProperty]
        public List<Feature> Features { get; set; }

        /// <summary>
        /// Get an array of strings for all of the neighborhoods within
        /// this FeatureCollection. Does not filter out empty Neighborhood
        /// properties.
        /// </summary>
        /// <returns>An array of strings for each neighbord within this
        /// FeatureCollection</returns>
        public string[] GetAllNeighborhoods() => (from f in Features
                                                  select f.Properties.Neighborhood).ToArray();

        /// <summary>
        /// Get an array of strings for all of the neighborhoods within
        /// this FeatureCollection, filtering out all of the empty
        /// Neighborhood properties from the resultant array
        /// </summary>
        /// <returns>An array of strings for every non-empty Neighborhood
        /// property within this FeatureCollection</returns>
        public string[] GetAllNonEmptyNeighborHoods() => (from n in GetAllNeighborhoods()
                                                          where n.Length > 0
                                                          select n).ToArray();

        /// <summary>
        /// Get an array of strings for all of the unique neighborhood
        /// names within this FeatureCollection with all empty
        /// Neighborhood properties filtered out.
        /// </summary>
        /// <returns>An array of strings for every unique, non-empty
        /// Neighborhood property within this FeatureCollection.</returns>
        public string[] GetAllUniqueNonEmptyNeighborhoods() =>
            GetAllNonEmptyNeighborHoods().Select(neighborhood => neighborhood)
                                         .Distinct()
                                         .ToArray();

        /// <summary>
        /// Get an array of strings for all of the unique neighborhood
        /// names within this FeatureCollection with all empty
        /// Neighborhood properties filtered out performed as a single
        /// LINQ query using lambda syntax.
        /// </summary>
        /// <returns>An array of strings for every unique, non-empty
        /// Neighborhood property within this FeatureCollection</returns>
        public string[] GetAllUniqueNonEmptyNeighborhoodsConsolidated() =>
            Features.Select(feature => feature.Properties.Neighborhood)
                    .Distinct()
                    .Where(content => content.Length > 0)
                    .ToArray();

        #region IList<Feature> Implementation (via Features property)
        public Feature this[int index] { get => ((IList<Feature>)Features)[index]; set => ((IList<Feature>)Features)[index] = value; }

        public int Count => ((IList<Feature>)Features).Count;

        public bool IsReadOnly => ((IList<Feature>)Features).IsReadOnly;

        public void Add(Feature item)
        {
            ((IList<Feature>)Features).Add(item);
        }

        public void Clear()
        {
            ((IList<Feature>)Features).Clear();
        }

        public bool Contains(Feature item)
        {
            return ((IList<Feature>)Features).Contains(item);
        }

        public void CopyTo(Feature[] array, int arrayIndex)
        {
            ((IList<Feature>)Features).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Feature> GetEnumerator()
        {
            return ((IList<Feature>)Features).GetEnumerator();
        }

        public int IndexOf(Feature item)
        {
            return ((IList<Feature>)Features).IndexOf(item);
        }

        public void Insert(int index, Feature item)
        {
            ((IList<Feature>)Features).Insert(index, item);
        }

        public bool Remove(Feature item)
        {
            return ((IList<Feature>)Features).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<Feature>)Features).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<Feature>)Features).GetEnumerator();
        }
        #endregion
    }
}
