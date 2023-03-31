using System.Collections.Generic;

namespace PathOfHideout.Utilities
{
    public class DuplicateKeyComparer<TKey> : IEqualityComparer<TKey>
    {
        /// <summary>
        /// To allow duplicates.
        /// </summary>
        public bool Equals(TKey? x, TKey? y)
        {
            return false;
        }

        public int GetHashCode(TKey obj)
        {
            return 0;
        }
    }
}
