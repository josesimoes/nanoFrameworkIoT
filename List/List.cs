using System;

namespace System.Collections.Generic
{
    //
    // Summary:
    //     Exposes the enumerator, which supports a simple iteration over a collection of
    //     a specified type.
    //
    // Type parameters:
    //   T:
    //     The type of objects to enumerate.
    public interface IEnumerable<out T> : IEnumerable
    {
        //
        // Summary:
        //     Returns an enumerator that iterates through the collection.
        //
        // Returns:
        //     An enumerator that can be used to iterate through the collection.
        IEnumerator<T> GetEnumerator();
    }

    //
    // Summary:
    //     Supports a simple iteration over a generic collection.
    //
    // Type parameters:
    //   T:
    //     The type of objects to enumerate.
    public interface IEnumerator<out T> : IEnumerator, IDisposable
    {
        //
        // Summary:
        //     Gets the element in the collection at the current position of the enumerator.
        //
        // Returns:
        //     The element in the collection at the current position of the enumerator.
        T Current { get; }
    }

    public class List<T> : IEnumerable<T>
    {

        private ArrayList _list;

        //
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.List`1 class that
        //     is empty and has the default initial capacity.
        public List()
        {
            _list = new ArrayList();
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.List`1 class that
        //     contains elements copied from the specified collection and has sufficient capacity
        //     to accommodate the number of elements copied.
        //
        // Parameters:
        //   collection:
        //     The collection whose elements are copied to the new list.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     collection is null.
        public List(IEnumerable<T> collection)
        {
            _list = new ArrayList();
            foreach (var elem in collection)
            {
                _list.Add(elem);
            }
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.List`1 class that
        //     is empty and has the specified initial capacity.
        //
        // Parameters:
        //   capacity:
        //     The number of elements that the new list can initially store.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     capacity is less than 0.
        public List(int capacity)
        {
            _list = new ArrayList();
            _list.Capacity = capacity;
        }

        //
        // Summary:
        //     Gets or sets the element at the specified index.
        //
        // Parameters:
        //   index:
        //     The zero-based index of the element to get or set.
        //
        // Returns:
        //     The element at the specified index.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is less than 0. -or- index is equal to or greater than System.Collections.Generic.List`1.Count.
        public T this[int index]
        {
            get
            {
                return (T)_list[index];
            }

            set
            {
                _list[index] = value;
            }
        }

        //
        // Summary:
        //     Gets the number of elements contained in the System.Collections.Generic.List`1.
        //
        // Returns:
        //     The number of elements contained in the System.Collections.Generic.List`1.
        public int Count => _list.Count;

        //
        // Summary:
        //     Gets or sets the total number of elements the internal data structure can hold
        //     without resizing.
        //
        // Returns:
        //     The number of elements that the System.Collections.Generic.List`1 can contain
        //     before resizing is required.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     System.Collections.Generic.List`1.Capacity is set to a value that is less than
        //     System.Collections.Generic.List`1.Count.
        //
        //   T:System.OutOfMemoryException:
        //     There is not enough memory available on the system.
        public int Capacity { get; set; }

        //
        // Summary:
        //     Adds an object to the end of the System.Collections.Generic.List`1.
        //
        // Parameters:
        //   item:
        //     The object to be added to the end of the System.Collections.Generic.List`1. The
        //     value can be null for reference types.
        public void Add(T item)
        {
            _list.Add(item);
        }

        //
        // Summary:
        //     Adds the elements of the specified collection to the end of the System.Collections.Generic.List`1.
        //
        // Parameters:
        //   collection:
        //     The collection whose elements should be added to the end of the System.Collections.Generic.List`1.
        //     The collection itself cannot be null, but it can contain elements that are null,
        //     if type T is a reference type.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     collection is null.
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var elem in collection)
            {
                _list.Add(elem);
            }
        }

        //
        // Summary:
        //     Returns an enumerator that iterates through the System.Collections.Generic.List`1.
        //
        // Returns:
        //     A System.Collections.Generic.List`1.Enumerator for the System.Collections.Generic.List`1.
        public Enumerator GetEnumerator() => new Enumerator(this);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();        

        //
        // Summary:
        //     Enumerates the elements of a System.Collections.Generic.List`1.
        //
        // Type parameters:
        //   T:
        public struct Enumerator : IEnumerator<T>, IDisposable
        {
            private int _index;
            private List<T> _collection;

            public Enumerator(List<T> collection)
            {
                _index = 0;
                _collection = collection;
            }

            //
            // Summary:
            //     Gets the element at the current position of the enumerator.
            //
            // Returns:
            //     The element in the System.Collections.Generic.List`1 at the current position
            //     of the enumerator.
            public T Current => _collection[_index];

            object IEnumerator.Current => Current;

            //
            // Summary:
            //     Releases all resources used by the System.Collections.Generic.List`1.Enumerator.
            public void Dispose()
            {

            }
            //
            // Summary:
            //     Advances the enumerator to the next element of the System.Collections.Generic.List`1.
            //
            // Returns:
            //     true if the enumerator was successfully advanced to the next element; false if
            //     the enumerator has passed the end of the collection.
            //
            // Exceptions:
            //   T:System.InvalidOperationException:
            //     The collection was modified after the enumerator was created.
            public bool MoveNext()
            {
                if (_index >= _collection.Count)
                {
                    return false;
                }

                _index++;
                return true;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        //
        // Summary:
        //     Determines whether an element is in the System.Collections.Generic.List`1.
        //
        // Parameters:
        //   item:
        //     The object to locate in the System.Collections.Generic.List`1. The value can
        //     be null for reference types.
        //
        // Returns:
        //     true if item is found in the System.Collections.Generic.List`1; otherwise, false.
        public bool Contains(T item)
        {
            foreach (var elem in _list)
            {
                if (((T)elem).GetHashCode() == item.GetHashCode())
                {
                    return true;
                }
            }

            return false;
        }

        //
        // Summary:
        //     Copies the entire System.Collections.Generic.List`1 to a compatible one-dimensional
        //     array, starting at the specified index of the target array.
        //
        // Parameters:
        //   array:
        //     The one-dimensional System.Array that is the destination of the elements copied
        //     from System.Collections.Generic.List`1. The System.Array must have zero-based
        //     indexing.
        //
        //   arrayIndex:
        //     The zero-based index in array at which copying begins.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     array is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     arrayIndex is less than 0.
        //
        //   T:System.ArgumentException:
        //     The number of elements in the source System.Collections.Generic.List`1 is greater
        //     than the available space from arrayIndex to the end of the destination array.
        public void CopyTo(T[] array, int arrayIndex)
        {
            CopyTo(0, array, arrayIndex, _list.Count);
        }

        //
        // Summary:
        //     Copies the entire System.Collections.Generic.List`1 to a compatible one-dimensional
        //     array, starting at the beginning of the target array.
        //
        // Parameters:
        //   array:
        //     The one-dimensional System.Array that is the destination of the elements copied
        //     from System.Collections.Generic.List`1. The System.Array must have zero-based
        //     indexing.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     array is null.
        //
        //   T:System.ArgumentException:
        //     The number of elements in the source System.Collections.Generic.List`1 is greater
        //     than the number of elements that the destination array can contain.
        public void CopyTo(T[] array)
        {
            CopyTo(0, array, 0, _list.Count);
        }

        //
        // Summary:
        //     Copies a range of elements from the System.Collections.Generic.List`1 to a compatible
        //     one-dimensional array, starting at the specified index of the target array.
        //
        // Parameters:
        //   index:
        //     The zero-based index in the source System.Collections.Generic.List`1 at which
        //     copying begins.
        //
        //   array:
        //     The one-dimensional System.Array that is the destination of the elements copied
        //     from System.Collections.Generic.List`1. The System.Array must have zero-based
        //     indexing.
        //
        //   arrayIndex:
        //     The zero-based index in array at which copying begins.
        //
        //   count:
        //     The number of elements to copy.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     array is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     index is less than 0. -or- arrayIndex is less than 0. -or- count is less than
        //     0.
        //
        //   T:System.ArgumentException:
        //     index is equal to or greater than the System.Collections.Generic.List`1.Count
        //     of the source System.Collections.Generic.List`1. -or- The number of elements
        //     from index to the end of the source System.Collections.Generic.List`1 is greater
        //     than the available space from arrayIndex to the end of the destination array.
        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            for (int i = index; i < count; i++)
            {
                array[arrayIndex + i] = (T)_list[i];
            }
        }

        //
        // Summary:
        //     Creates a shallow copy of a range of elements in the source System.Collections.Generic.List`1.
        //
        // Parameters:
        //   index:
        //     The zero-based System.Collections.Generic.List`1 index at which the range starts.
        //
        //   count:
        //     The number of elements in the range.
        //
        // Returns:
        //     A shallow copy of a range of elements in the source System.Collections.Generic.List`1.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is less than 0. -or- count is less than 0.
        //
        //   T:System.ArgumentException:
        //     index and count do not denote a valid range of elements in the System.Collections.Generic.List`1.
        public List<T> GetRange(int index, int count)
        {
            var list = new List<T>();
            for (int i = index; i < count; i++)
            {
                list.Add((T)_list[i]);
            }

            return list;
        }
        //
        // Summary:
        //     Searches for the specified object and returns the zero-based index of the first
        //     occurrence within the range of elements in the System.Collections.Generic.List`1
        //     that starts at the specified index and contains the specified number of elements.
        //
        // Parameters:
        //   item:
        //     The object to locate in the System.Collections.Generic.List`1. The value can
        //     be null for reference types.
        //
        //   index:
        //     The zero-based starting index of the search. 0 (zero) is valid in an empty list.
        //
        //   count:
        //     The number of elements in the section to search.
        //
        // Returns:
        //     The zero-based index of the first occurrence of item within the range of elements
        //     in the System.Collections.Generic.List`1 that starts at index and contains count
        //     number of elements, if found; otherwise, -1.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is outside the range of valid indexes for the System.Collections.Generic.List`1.
        //     -or- count is less than 0. -or- index and count do not specify a valid section
        //     in the System.Collections.Generic.List`1.
        public int IndexOf(T item, int index, int count) => _list.IndexOf(item, index, count);

        //
        // Summary:
        //     Searches for the specified object and returns the zero-based index of the first
        //     occurrence within the range of elements in the System.Collections.Generic.List`1
        //     that extends from the specified index to the last element.
        //
        // Parameters:
        //   item:
        //     The object to locate in the System.Collections.Generic.List`1. The value can
        //     be null for reference types.
        //
        //   index:
        //     The zero-based starting index of the search. 0 (zero) is valid in an empty list.
        //
        // Returns:
        //     The zero-based index of the first occurrence of item within the range of elements
        //     in the System.Collections.Generic.List`1 that extends from index to the last
        //     element, if found; otherwise, -1.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is outside the range of valid indexes for the System.Collections.Generic.List`1.
        public int IndexOf(T item, int index) => IndexOf(item, index, _list.Count - index);

        //
        // Summary:
        //     Searches for the specified object and returns the zero-based index of the first
        //     occurrence within the entire System.Collections.Generic.List`1.
        //
        // Parameters:
        //   item:
        //     The object to locate in the System.Collections.Generic.List`1. The value can
        //     be null for reference types.
        //
        // Returns:
        //     The zero-based index of the first occurrence of item within the entire System.Collections.Generic.List`1,
        //     if found; otherwise, -1.
        public int IndexOf(T item) => IndexOf(item, 0, _list.Count);

        //
        // Summary:
        //     Inserts an element into the System.Collections.Generic.List`1 at the specified
        //     index.
        //
        // Parameters:
        //   index:
        //     The zero-based index at which item should be inserted.
        //
        //   item:
        //     The object to insert. The value can be null for reference types.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is less than 0. -or- index is greater than System.Collections.Generic.List`1.Count.
        public void Insert(int index, T item) => _list.Insert(index, item);

        //
        // Summary:
        //     Inserts the elements of a collection into the System.Collections.Generic.List`1
        //     at the specified index.
        //
        // Parameters:
        //   index:
        //     The zero-based index at which the new elements should be inserted.
        //
        //   collection:
        //     The collection whose elements should be inserted into the System.Collections.Generic.List`1.
        //     The collection itself cannot be null, but it can contain elements that are null,
        //     if type T is a reference type.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     collection is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     index is less than 0. -or- index is greater than System.Collections.Generic.List`1.Count.
        public void InsertRange(int index, IEnumerable<T> collection)
        {
            foreach (var elem in collection)
            {
                _list.Insert(index++, elem);
            }
        }

        //
        // Summary:
        //     Searches for the specified object and returns the zero-based index of the last
        //     occurrence within the entire System.Collections.Generic.List`1.
        //
        // Parameters:
        //   item:
        //     The object to locate in the System.Collections.Generic.List`1. The value can
        //     be null for reference types.
        //
        // Returns:
        //     The zero-based index of the last occurrence of item within the entire the System.Collections.Generic.List`1,
        //     if found; otherwise, -1.
        public int LastIndexOf(T item) => LastIndexOf(item, _list.Count - 1, _list.Count);

        //
        // Summary:
        //     Searches for the specified object and returns the zero-based index of the last
        //     occurrence within the range of elements in the System.Collections.Generic.List`1
        //     that extends from the first element to the specified index.
        //
        // Parameters:
        //   item:
        //     The object to locate in the System.Collections.Generic.List`1. The value can
        //     be null for reference types.
        //
        //   index:
        //     The zero-based starting index of the backward search.
        //
        // Returns:
        //     The zero-based index of the last occurrence of item within the range of elements
        //     in the System.Collections.Generic.List`1 that extends from the first element
        //     to index, if found; otherwise, -1.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is outside the range of valid indexes for the System.Collections.Generic.List`1.
        public int LastIndexOf(T item, int index) => LastIndexOf(item, index, _list.Count - index);

        //
        // Summary:
        //     Searches for the specified object and returns the zero-based index of the last
        //     occurrence within the range of elements in the System.Collections.Generic.List`1
        //     that contains the specified number of elements and ends at the specified index.
        //
        // Parameters:
        //   item:
        //     The object to locate in the System.Collections.Generic.List`1. The value can
        //     be null for reference types.
        //
        //   index:
        //     The zero-based starting index of the backward search.
        //
        //   count:
        //     The number of elements in the section to search.
        //
        // Returns:
        //     The zero-based index of the last occurrence of item within the range of elements
        //     in the System.Collections.Generic.List`1 that contains count number of elements
        //     and ends at index, if found; otherwise, -1.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is outside the range of valid indexes for the System.Collections.Generic.List`1.
        //     -or- count is less than 0. -or- index and count do not specify a valid section
        //     in the System.Collections.Generic.List`1.
        public int LastIndexOf(T item, int index, int count)
        {
            for (int i = index; i >= _list.Count - count - index; i--)
            {
                if (((T)_list[i]).GetHashCode() == item.GetHashCode())
                {
                    return i;
                }
            }

            return -1;
        }
        //
        // Summary:
        //     Removes the first occurrence of a specific object from the System.Collections.Generic.List`1.
        //
        // Parameters:
        //   item:
        //     The object to remove from the System.Collections.Generic.List`1. The value can
        //     be null for reference types.
        //
        // Returns:
        //     true if item is successfully removed; otherwise, false. This method also returns
        //     false if item was not found in the System.Collections.Generic.List`1.
        public bool Remove(T item)
        {
            if (_list.Contains(item))
            {
                _list.Remove(item);
                return true;
            }

            return false;
        }

        //
        // Summary:
        //     Removes the element at the specified index of the System.Collections.Generic.List`1.
        //
        // Parameters:
        //   index:
        //     The zero-based index of the element to remove.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is less than 0. -or- index is equal to or greater than System.Collections.Generic.List`1.Count.
        public void RemoveAt(int index) => _list.RemoveAt(index);

        //
        // Summary:
        //     Removes a range of elements from the System.Collections.Generic.List`1.
        //
        // Parameters:
        //   index:
        //     The zero-based starting index of the range of elements to remove.
        //
        //   count:
        //     The number of elements to remove.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is less than 0. -or- count is less than 0.
        //
        //   T:System.ArgumentException:
        //     index and count do not denote a valid range of elements in the System.Collections.Generic.List`1.
        public void RemoveRange(int index, int count)
        {
            for (int i = 0; i < count; i++)
            {
                _list.RemoveAt(index);
            }
        }

        //
        // Summary:
        //     Copies the elements of the System.Collections.Generic.List`1 to a new array.
        //
        // Returns:
        //     An array containing copies of the elements of the System.Collections.Generic.List`1.
        public T[] ToArray()
        {
            T[] array = new T[_list.Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (T)_list[i];
            }

            return array;
        }

    }
}
