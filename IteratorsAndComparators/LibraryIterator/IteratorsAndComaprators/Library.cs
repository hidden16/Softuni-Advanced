using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComaprators
{

    public class Library : IEnumerable<Book>
    {
        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly IReadOnlyList<Book> books;
            private int currentIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();
                this.books = new List<Book>(books);

            }

            public void Dispose() { }
            public bool MoveNext() => ++currentIndex < books.Count;
            public void Reset() => currentIndex = -1;
            public Book Current => books[currentIndex];
            object IEnumerator.Current => this.Current;
        }

        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            LibraryIterator iter = new LibraryIterator(books);

            return iter;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    }
}
