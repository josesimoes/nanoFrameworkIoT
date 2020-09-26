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
}
