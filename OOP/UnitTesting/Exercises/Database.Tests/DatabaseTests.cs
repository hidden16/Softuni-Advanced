namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }
        [Test]
        public void Test_If_Constructor_Adds_More_Than_16_Items_Should_Throw_InvalidOperationException()
        {
            int[] items = Enumerable.Range(1, 17).ToArray();
            Assert.Throws<InvalidOperationException>(() =>
            {
                database = new Database(items);
            });
        }
        [Test]
        public void Test_Items_Added_Count_From_Constructor()
        {
            int[] items = Enumerable.Range(1, 10).ToArray();
            database = new Database(items);
            Assert.AreEqual(10, database.Count);
        }
        [Test]
        public void Test_If_Count_Changes_When_An_Item_Is_Added()
        {
            database.Add(5);
            database.Add(3);
            Assert.That(2, Is.EqualTo(database.Count));
        }
        [Test]
        public void Test_If_Exception_Is_Thrown_When_Added_More_Than_16_Items()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 17; i++)
                {
                    database.Add(i);
                }
            });
        }
        [Test]
        public void Test_Check_If_Item_Is_Added_On_The_Next_Free_Cell()
        {
            database.Add(5);
            int[] items = database.Fetch();

            Assert.That(database.Count == 1 && items[0] == 5);
        }
        [Test]
        public void Test_When_Elements_Are_0_Remove_Should_Throw_Exception()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }
        [Test]
        public void Test_If_Count_Decreases_When_Item_Is_Removed()
        {
            int[] items = Enumerable.Range(1, 3).ToArray();
            database = new Database(items);
            database.Remove();
            Assert.AreEqual(2, database.Count);
        }
        [Test]
        public void Test_If_Fetch_Returns_Correct_Count()
        {
            int[] items = Enumerable.Range(1, 5).ToArray();
            database = new Database(items);

            int[] returnedCount = database.Fetch();

            Assert.AreEqual(5, returnedCount.Length);
        }
    }
}
