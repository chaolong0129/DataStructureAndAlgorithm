namespace CircularLinkedListExample
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularLinkedList<T> : LinkedList<T>
    {
        public new IEnumerator GetEnumerator()
        {
            return new CircularLinkedListEnumerator<T>(this);
        }
    }
}