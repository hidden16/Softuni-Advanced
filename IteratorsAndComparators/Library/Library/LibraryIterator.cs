using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> books;
        private int currentIndex;
        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }
        public Book Current => books[currentIndex];
        public bool MoveNext() => ++currentIndex < books.Count;
        public void Dispose() { }
        public void Reset() => this.currentIndex = -1;
        object IEnumerator.Current => Current; // legacy
    }
}