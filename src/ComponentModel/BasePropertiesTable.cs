﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace iTin.Core.Hardware.Common.ComponentModel;

/// <summary>
/// Represents a base implementation for a properties table.<br/>
/// Define a suitable generic dictionary to store properties and their value.
/// </summary>
public class BasePropertiesTable : IList<PropertyItem>
{
    #region private readonly members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly List<PropertyItem> _table;
    
    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="BasePropertiesTable" /> class.
    /// </summary>
    protected BasePropertiesTable()
    {
        _table = [];
    }

    #endregion

    #region interfaces

    #region public indexers

    /// <inheritdoc />
    /// <summary>
    /// Gets or sets the element with the specified index.
    /// </summary>
    /// <param name="index">The index of the element that is obtained or established.</param>
    /// <returns>
    /// The element with the specified index.
    /// </returns>
    public PropertyItem this[int index]
    {
        get => _table[index];
        set => _table[index] = value;
    }

    /// <summary>
    /// Gets or sets the element with the specified key.
    /// </summary>
    /// <param name="key">The key of the element that is obtained or established.</param>
    /// <returns>
    /// The element with the specified key.
    /// </returns>
    /// <exception cref="ArgumentNullException">The value of <paramref name="key" /> is <see langword="null" />.</exception>
    /// <exception cref="KeyNotFoundException">The property is retrieved and <paramref name="key" /> can not be found.</exception>
    /// <exception cref="NotSupportedException">The property is set and <see cref="T:System.Collections.Generic.IDictionary`2" /> is read-only.</exception>
    public object this[IPropertyKey key]
    {
        get => _table.FindAll(p => p.Key.Equals(key));
        set => _table.Add(new PropertyItem {Key = key, Value = value});
    }

    #endregion

    #region public readonly properties

    /// <inheritdoc />
    public int Count => _table.Count;

    /// <summary>
    /// Gets a value that indicates whether <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
    /// </summary>
    /// <returns>
    /// Always returns <see langword="true"/>.
    /// </returns>
    public bool IsReadOnly => true;

    /// <summary>
    /// Gets an interface <see cref="T:System.Collections.Generic.ICollection`1" /> that contains the keys.
    /// </summary>
    /// <returns>
    /// <see cref="T:System.Collections.Generic.ICollection`1" /> that contains the keys of the object.
    /// </returns>
    public ICollection<IPropertyKey> Keys
    {
        get
        {
            var keys = new Collection<IPropertyKey>();
            foreach (var item in _table)
            {
                var exist = keys.Contains(item.Key);
                if (exist)
                {
                    continue;
                }

                keys.Add(item.Key);
            }

            return keys;
        }
    }

    #endregion

    #region public methods

    /// <summary>
    /// Gets the index of the specified property item.
    /// </summary>
    /// <param name="item">The property item to find.</param>
    /// <returns>
    /// The index of the property item, or -1 if not found.
    /// </returns>
    public int IndexOf(PropertyItem item) => _table.IndexOf(item);

    /// <inheritdoc />
    /// <summary>
    /// Inserts a property item at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which the property item should be inserted.</param>
    /// <param name="item">The property item to insert.</param>
    public void Insert(int index, PropertyItem item) => _table.Insert(index, item);

    /// <inheritdoc />
    /// <summary>
    /// Removes the property item at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the property item to remove.</param>
    public void RemoveAt(int index) => _table.RemoveAt(index);

    /// <summary>
    /// Adds a property item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
    /// </summary>
    /// <param name="item">The object to be added to <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
    /// <exception cref="NotSupportedException"><see cref="T:System.Collections.Generic.ICollection`1"/> is read only.</exception>
    public void Add(PropertyItem item) => _table.Add(item);

    /// <summary>
    /// Adds a property item with the specified key and value to <see cref="T:System.Collections.Generic.IDictionary`2"/>.
    /// </summary>
    /// <param name="key">The object that is going to be used as the key of the element to be added.</param>
    /// <param name="value">The object to be used as the value of the element to be added.</param>
    /// <exception cref="ArgumentNullException">The value of <paramref name="key"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">An element with the same key already exists in <see cref="T:System.Collections.Generic.IDictionary`2"/>.</exception>
    /// <exception cref="NotSupportedException"><see cref="T:System.Collections.Generic.IDictionary`2"/> is read only.</exception>
    public void Add(IPropertyKey key, object value) => Add(new PropertyItem {Key = key, Value = value});

    /// <summary>
    /// Remove all the elements of <see cref="T:System.Collections.Generic.ICollection`1" />.
    /// </summary>
    /// <exception cref="T:System.NotSupportedException"><see cref="T:System.Collections.Generic.ICollection`1" /> is read only.</exception>
    public void Clear() => _table.Clear();

    /// <summary>
    /// Determines whether <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
    /// </summary>
    /// <param name="item">Object to be searched in <see cref="T:System.Collections.Generic.ICollection`1"/></param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="item"/> is in the array <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, <see langword="false"/>.
    /// </returns>
    public bool Contains(PropertyItem item) => _table.Contains(item);

    /// <summary>
    /// Determines whether <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the specified key.
    /// </summary>
    /// <param name="key">Key to be searched in <see cref="T:System.Collections.Generic.IDictionary`2"/>.</param>
    /// <returns>
    /// Is <see langword="true"/> if <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the key; otherwise, it is <see langword="false"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">The value of <paramref name="key"/> is <see langword="null"/>.</exception>
    public bool ContainsKey(IPropertyKey key) => Keys.Contains(key);

    /// <summary>
    /// Copies the elements of <see cref="T:System.Collections.Generic.ICollection`1"/> into <see cref="T:System.Array"/>, starting with a given index of <see cref="T:System.Array"/>.
    /// </summary>
    /// <param name="array">
    /// <see cref="T:System.Array"/> one-dimensional which is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"/>.
    /// The matrix<see cref="T:System.Array"/> must have a zero base index.
    /// </param>
    /// <param name="arrayIndex">Zero-base index in the <paramref name = "array"/> where the copy starts.</param>
    /// <exception cref="ArgumentNullException">The value of <paramref name="array"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than 0.</exception>
    /// <exception cref="ArgumentException">The number of elements at the origin of <see cref="T:System.Collections.Generic.ICollection`1"/> is greater than the available space from <paramref name="arrayIndex"/> to the end of the destination of <paramref name="array"/>.</exception>
    public void CopyTo(PropertyItem[] array, int arrayIndex) => _table.CopyTo(array, arrayIndex);

    /// <summary>
    /// Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>
    /// Object <see cref="IEnumerator"/> that can be used to iterate through the collection.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Returns an enumerator that processes an iteration in the collection.
    /// </summary>
    /// <returns>
    /// Enumerator that can be used to iterate through the collection.
    /// </returns>
    public IEnumerator<PropertyItem> GetEnumerator() => _table.GetEnumerator();

    /// <summary>
    /// Remove the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" /> interface.
    /// </summary>
    /// <param name="item">Object to be removed from <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
    /// <returns>
    /// Is <see langword="true" /> if <paramref name="item" /> has been successfully removed from the interface <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, it is <see langword="false" />.
    /// This method also returns <see langword="false" /> if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.
    /// </returns>
    /// <exception cref="T:System.NotSupportedException"><see cref="T:System.Collections.Generic.ICollection`1" /> is read only.</exception>
    public bool Remove(PropertyItem item) => _table.Remove(item);

    #endregion

    #endregion

    #region public override methods

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>
    /// A string that represents the current object.
    /// </returns>
    public override string ToString() => $"Count = {_table.Count}";

    #endregion
}
