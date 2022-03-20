namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
    using ExtendedDatabase;
    using System;
    using System.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }
        [Test]
        public void Test_Constructor_When_Given_More_Than_16_Arguments_Should_Throw_ArgumentException()
        {
            Person[] persons = new Person[17];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, "iks" + i);
            }
            Assert.Throws<ArgumentException>(() =>
            {
                database = new Database(persons);
            });
        }
        [Test]
        public void Test_If_Constructor_Returns_Correct_Count()
        {
            database = new Database(new Person(123, "asd"), new Person(321, "ddss"));
            Assert.AreEqual(2, database.Count);
        }
        [Test]
        public void Test_If_Add_More_People_Than_Capacity_Should_Return_InvalidOperationException()
        {
            Person[] persons = new Person[17];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, "qwe" + i);
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < persons.Length; i++)
                {
                    database.Add(persons[i]);
                }
            });
        }
        [Test]
        public void Test_If_Add_More_Than_One_Person_With_The_Same_Username_Should_Throw_InvalidOperationException()
        {
            Person person1 = new Person(1, "Iks");
            Person person2 = new Person(2, "Iks");
            database.Add(person1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(person2);
            });
        }
        [Test]
        public void Test_If_Add_More_Than_One_Person_With_The_Same_Id_Should_Throw_InvalidOperationException()
        {
            Person person1 = new Person(1, "Iks");
            Person person2 = new Person(1, "Zuji");
            database.Add(person1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(person2);
            });
        }
        [Test]
        public void Test_If_Add_Returns_Correct_Count()
        {
            Person person1 = new Person(1, "Iks");
            Person person2 = new Person(2, "Zuji");
            Person person3 = new Person(3, "Mylo");
            database.Add(person1);
            database.Add(person2);
            database.Add(person3);
            Assert.AreEqual(3, database.Count);
        }
        [Test]
        public void Test_If_Trying_To_Remove_When_Count_Is_0_Should_Throw_InvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }
        [Test]
        public void Test_If_Remove_Returns_Correct_Count()
        {
            Person person1 = new Person(1, "Iks");
            Person person2 = new Person(2, "Zuji");
            Person person3 = new Person(3, "Zujinatoriks");
            database.Add(person1);
            database.Add(person2);
            database.Add(person3);
            var expectedCount = 2;
            database.Remove();
            Assert.AreEqual(expectedCount, database.Count);
        }
        [Test]
        public void Test_If_FindByUsername_Input_Is_Null_Or_Empty_Should_Throw_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            });
        }
         [Test]
        public void Test_If_FindByUsername_Input_Is_Not_Found_In_The_Array_Should_Throw_InvalidOperationException()
        {
            Person person = new Person(1, "A");
            database.Add(person);
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("a");
            });
        }
         [Test]
        public void Test_If_FindByUsername_Returns_Correct_Person()
        {
            Person person = new Person(1, "Iks");
            database.Add(person);
            var returnedUser = database.FindByUsername("Iks");
            Assert.That(returnedUser == person);
        }
        [Test]
        public void Test_If_FindById_Input_Is_Negative_Number_Should_Throw_ArgumentOutOfRangeException()
        {
            Person person = new Person(1, "Iks");
            database.Add(person);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-3);
            });
        }
        [Test]
        public void Test_If_FindById_Input_Is_Not_Contained_In_The_Array_Should_Throw_InvalidOperationException()
        {
            Person person = new Person(13, "Iks");
            database.Add(person);
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(5);
            });
        }
         [Test]
        public void Test_If_FindById_Returns_Correct_Person()
        {
            Person person = new Person(13, "Iks");
            database.Add(person);
            var expectedPerson = database.FindById(13);
            Assert.That(expectedPerson == person);
        }
    }
}