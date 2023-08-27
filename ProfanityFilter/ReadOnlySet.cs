/*
MIT License
Copyright (c) 2019 
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;

namespace ProfanityFilterTools;

//[Serializable]
//[DebuggerTypeProxy(typeof(ICollectionDebugView<>))]
[DebuggerDisplay("Count = {Count}")]
public class ReadOnlySet<T> : ICollection, ICollection<T>, IReadOnlyCollection<T>, ISet<T>, IReadOnlySet<T>
{
    private readonly ISet<T> set; // Do not rename (binary serialization)

    public ReadOnlySet(ISet<T> set) => this.set = set ?? throw new ArgumentNullException(nameof(set));

    /// <summary>Gets an empty <see cref="ReadOnlyCollection{T}"/>.</summary>
    /// <value>An empty <see cref="ReadOnlyCollection{T}"/>.</value>
    /// <remarks>The returned instance is immutable and will always be empty.</remarks>
    public static ReadOnlySet<T> Empty { get; } = new ReadOnlySet<T>(new HashSet<T>(0));

    public int Count => set.Count;
    public bool Contains(T value) => set.Contains(value);

    public void CopyTo(T[] array, int index) => set.CopyTo(array, index);

    public IEnumerator<T> GetEnumerator() => set.GetEnumerator();

    bool ICollection<T>.IsReadOnly => true;
    [DoesNotReturn]
    protected void ThrowNotSupported() => throw new NotSupportedException("Collection is read-only.");
    void ICollection<T>.Add(T value) => ThrowNotSupported();

    void ICollection<T>.Clear() => ThrowNotSupported();

    bool ICollection<T>.Remove(T value)
    {
        ThrowNotSupported();
        return false;
    }
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)set).GetEnumerator();

    bool ICollection.IsSynchronized => false;

    object ICollection.SyncRoot => set is ICollection coll ? coll.SyncRoot : this;

    void ICollection.CopyTo(Array array, int index)
    {
        ArgumentNullException.ThrowIfNull(nameof(array));
        ((ICollection)set).CopyTo(array, index);
    }

    // Non-null values are fine.  Only accept nulls if T is a class or Nullable<U>.
    // Note that default(T) is not equal to null for value types except when T is Nullable<U>.
    protected static bool IsCompatibleObject(object? value) => (value is T) || (value == null && default(T) == null);

    public bool IsProperSubsetOf(IEnumerable<T> other) => set.IsProperSupersetOf(other);
    public bool IsProperSupersetOf(IEnumerable<T> other) => set.IsProperSupersetOf(other);
    public bool IsSubsetOf(IEnumerable<T> other) => set.IsSubsetOf(other);
    public bool IsSupersetOf(IEnumerable<T> other) => set.IsSupersetOf(other);
    public bool Overlaps(IEnumerable<T> other) => set.Overlaps(other);
    public bool SetEquals(IEnumerable<T> other) => set.SetEquals(other);
    bool ISet<T>.Add(T item)
    {
        ThrowNotSupported();
        return false;
    }

    void ISet<T>.ExceptWith(IEnumerable<T> other) => ThrowNotSupported();
    void ISet<T>.IntersectWith(IEnumerable<T> other) => ThrowNotSupported();
    void ISet<T>.SymmetricExceptWith(IEnumerable<T> other) => ThrowNotSupported();
    void ISet<T>.UnionWith(IEnumerable<T> other) => ThrowNotSupported();
}
