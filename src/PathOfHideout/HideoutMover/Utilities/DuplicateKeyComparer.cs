using System.Collections.Generic;

namespace PathOfHideout.HideoutMover.Utilities;

public class DuplicateKeyComparer<TKey> : IEqualityComparer<TKey>
{
    /// <summary>
    /// To allow duplicates, the dictionary enables storing
    /// multiple quantities of items of the same type
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
