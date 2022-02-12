using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int currIndex;
        public LibraryIterator(List<Book> books)
        {
            this.books = books;
            currIndex = -1;
        }
        public Book Current => books[currIndex];
        public bool MoveNext()
        {
            currIndex++;
            return currIndex < books.Count;
        }
        public void Dispose() { }
        public void Reset() { }
        object IEnumerator.Current => Current; // legacy
    }
}