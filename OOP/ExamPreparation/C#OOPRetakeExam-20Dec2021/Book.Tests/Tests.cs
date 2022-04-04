namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_Constructor_If_Recieves_Null_Or_Empty_Book_Name_Should_Throw_ArgumentException(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(name, "James");
            });
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_Constructor_If_Recieves_Null_Or_Empty_Author_Should_Throw_ArgumentException(string author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Connor", author);
            });
        }
        [Test]
        public void Test_Constructor_If_Instantiates_Dictionary_Correctly()
        {
            Book book = new Book("Connor", "Austin");
            Assert.AreEqual(0, book.FootnoteCount);
        }
        [Test]
        public void Test_Constructor_If_Inserts_Correct_Values()
        {
            Book book = new Book("Connor", "Austin");
            Assert.AreEqual("Connor", book.BookName);
            Assert.AreEqual("Austin", book.Author);
            Assert.AreEqual(0, book.FootnoteCount);
        }
        [Test]
        public void Test_AddFootnote_If_Recieves_Same_Number_Should_Throw_InvalidOperationException()
        {
            Book book = new Book("Connor", "Austin");
            book.AddFootnote(1, "RandomText");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(1, "ASD");
            });
        }
        [Test]
        public void Test_AddFootnote_If_Works_Correctly_FootnoteCount_Should_Increase()
        {
            Book book = new Book("Connor", "Austin");
            book.AddFootnote(1, "RandomText");
            Assert.AreEqual(1, book.FootnoteCount);
        }
        [Test]
        public void Test_FindFootnote_If_Recieves_Number_That_Doesnt_Exist_Should_Throw_InvalidOperationException()
        {
            Book book = new Book("Connor", "Austin");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(123);
            });
        }
        [Test]
        public void Test_FindFootnote_If_Returns_Correctly()
        {
            Book book = new Book("Connor", "Austin");
            book.AddFootnote(1, "RandomText");
            var test = book.FindFootnote(1);
            Assert.AreEqual($"Footnote #1: RandomText", test);
        }
        [Test]
        public void Test_AlterFootnote_If_Recieves_Number_That_Doesnt_Exist_Should_Throw_InvalidOperationException()
        {
            Book book = new Book("Connor", "Austin");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(13, " asdsad");
            });
        }
        [Test]
        public void Test_Alter_Footnote_If_Works_Correctly()
        {
            Book book = new Book("Connor", "Austin");
            book.AddFootnote(1, "RandomText");
            book.AlterFootnote(1, "TextRandom");
            var test = book.FindFootnote(1);
            Assert.AreEqual($"Footnote #1: TextRandom", test);
        }

    }
}