namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        private Book book;
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_If_Constructor_BookName_Recieves_Null_Or_Empty_Should_Throw_ArgumentException(string bookName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book(bookName, "Benjamin");
            });
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_If_Constructor_Author_Recieves_Null_Or_Empty_Should_Throw_ArgumentException(string authorName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book("CompleteCode", authorName);
            });
        }
        [Test]
        [TestCase("CompleteCode", "Steve")]
        [TestCase("CodeClean", "Robert")]
        public void Test_If_Constructor_Initializes_Correctly_When_Valid_Paramaters_Are_Given(string bookName, string authorName)
        {
            book = new Book(bookName, authorName);
            Assert.AreEqual(bookName, book.BookName);
            Assert.AreEqual(authorName, book.Author);
        }
        [Test]
        public void Test_If_FootnoteCount_Returns_Correct_Count_Should_Return_0()
        {
            book = new Book("CompleteCode", "Steve");
            Assert.AreEqual(0, book.FootnoteCount);
        }
        [Test]
        public void Test_If_AddFootnote_Adds_Correctly_FoodNoteCount_Should_Increase_With_2()
        {
            book = new Book("CompleteCode", "Steve");
            book.AddFootnote(123, "asd");
            book.AddFootnote(1234, "asdf");
            Assert.AreEqual(2, book.FootnoteCount);
        }
        [Test]
        public void Test_If_AddFootnote_Adds_Same_Number_Should_Throw_InvalidOperationException()
        {
            book = new Book("CompleteCode", "Steve");
            book.AddFootnote(123, "asd");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(123, "asdf");
            });
        }
        [Test]
        public void Test_If_FindFootnote_Returns_Correct_String()
        {
            book = new Book("CompleteCode", "Steve");
            book.AddFootnote(123, "asd");
            Assert.AreEqual("Footnote #123: asd", book.FindFootnote(123));
        }
        [Test]
        public void Test_If_FindFootnote_Recieves_Non_Existent_Number_Should_Throw_InvalidOperationException()
        {
            book = new Book("CompleteCode", "Steve");
            book.AddFootnote(123, "asd");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(321);
            });
        }
        [Test]
        public void Test_If_AlterFootnote_Changes_The_Numbers_Text_Correctly()
        {
            book = new Book("CompleteCode", "Steve");
            book.AddFootnote(123, "Hello");
            book.AlterFootnote(123, "Bye");
            var currBook = book.FindFootnote(123);
            Assert.AreEqual("Footnote #123: Bye", currBook);
        }
        [Test]
        public void Test_If_AlterFootnote_Recieves_Non_Existent_Number_Should_Throw_InvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(12345, "Bye");
            });
        }

    }
}