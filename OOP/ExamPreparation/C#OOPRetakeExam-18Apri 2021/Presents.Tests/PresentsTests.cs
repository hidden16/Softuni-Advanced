namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;
        [SetUp]
        public void SetUp()
        {
            bag = new Bag();
        }
        [Test]
        public void Test_If_Constructor_Instantiates_Correctly_Through_Method()
        {
            var test = bag.GetPresents();
            Assert.AreEqual(0, test.Count);
        }
        [Test]
        public void Test_Create_Method()
        {
            //test 1
            Present present = new Present("Vlad", 50);
            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(null);
            });
            //test 2
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            });
            //test 3
            bag = new Bag();
            var test = bag.Create(present);
            Assert.AreEqual($"Successfully added present Vlad.", test);
            //test 4
            var testCount = bag.GetPresents();
            Assert.AreEqual(1, testCount.Count); ;
        }
        [Test]
        public void Test_Remove_Method()
        {
            Present present = null;
            var booleanReturn = bag.Remove(present);
            Assert.IsFalse(booleanReturn);

            Present present2 = new Present("Vayne", 50);
            bag.Create(present2);
            booleanReturn = bag.Remove(present2);
            Assert.IsTrue(booleanReturn);

            Present present3 = new Present("asd", 40);
            Present present4 = new Present("dsa", 40);
            Present present5 = new Present("sad", 40);
            bag.Create(present3);
            bag.Create(present4);
            bag.Create(present5);
            bag.Remove(present5);
            var testCount = bag.GetPresents();
            Assert.AreEqual(2, testCount.Count);
        }
        [Test]
        public void Test_GetPresentWithLeastMagic_Method()
        {
            Present present3 = new Present("asd", 15);
            Present present4 = new Present("dsa", 40);
            bag.Create(present3);
            bag.Create(present4);
            var test = bag.GetPresentWithLeastMagic();
            Assert.AreEqual(present3, test);
        }
        [Test]
        public void Test_GetPresent_Method()
        {
            Present present3 = new Present("asd", 15);
            Present present4 = new Present("dsa", 40);
            bag.Create(present3);
            bag.Create(present4);
            var test = bag.GetPresent("asd");
            Assert.AreEqual(present3, test);

            var test2 = bag.GetPresent("dasdasads");
            Assert.AreEqual(null, test2);
        }
    }
}
