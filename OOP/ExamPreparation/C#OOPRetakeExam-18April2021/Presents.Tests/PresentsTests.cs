namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void Test_Constructor_If_Generates_Instance_Correctly()
        {
            Bag bag = new Bag();
            List<Present> presents = bag.GetPresents().ToList();
            Assert.AreEqual(0, presents.Count);
        }
        [Test]
        public void Test_Create_If_Recieves_Null_Present_Should_Throw_ArgumentNullException()
        {
            Bag bag = new Bag();
            Present present = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(present);
            });
        }
        [Test]
        public void Test_Create_If_Recieves_A_Present_That_Already_Exists_Should_Throw_InvalidOperationException()
        {
            Bag bag = new Bag();
            Present present = new Present("Peshkata", 15);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            });
        }
        [Test]
        public void Test_Create_If_Returns_Correct_String_When_Added()
        {
            Bag bag = new Bag();
            Present present = new Present("Peshkata", 15);
            var output = bag.Create(present);
            Assert.AreEqual($"Successfully added present {present.Name}.", output);
        }
        [Test]
        public void Test_Create_If_Increases_List_Count_Correctly()
        {
            Bag bag = new Bag();
            Present present = new Present("Peshkata", 15);
            bag.Create(present);
            Present present2 = new Present("Goshkata", 15);
            bag.Create(present2);
            List<Present> presents = bag.GetPresents().ToList();
            Assert.AreEqual(2, presents.Count);
        }
        [Test]
        public void Test_If_Remove_Returns_True_When_Given_Correct_Present()
        {
            Bag bag = new Bag();
            Present present = new Present("Peshkata", 15);
            bag.Create(present);
            Assert.IsTrue(bag.Remove(present));
        }
         [Test]
        public void Test_If_Remove_Returns_False_When_Given_Incorrect_Present()
        {
            Bag bag = new Bag();
            Present present = new Present("Peshkata", 15);
            bag.Create(present);
            Present present2 = new Present("Goshkasta", 15);
            bag.Create(present2);
            Assert.IsTrue(bag.Remove(present2));
        }
         [Test]
        public void Test_If_Remove_Decreases_Count_When_Removed_Successfully()
        {
            Bag bag = new Bag();
            Present present = new Present("Peshkata", 15);
            bag.Create(present);
            Present present2 = new Present("goshkata", 15);
            bag.Create(present2);
            bag.Remove(present);
            List<Present> presents = bag.GetPresents().ToList();
            Assert.AreEqual(1, presents.Count);
        }
         [Test]
        public void Test_GetPresentWithLeastMagic_If_Returns_Correct_Present()
        {
            Bag bag = new Bag();
            Present present = new Present("Peshkata", 15);
            bag.Create(present);
            Present present2 = new Present("goshkata", 20);
            bag.Create(present2);
            Present present3= new Present("Stoikata", 4);
            bag.Create(present3);

            Present returnedPresent = bag.GetPresentWithLeastMagic();
            Assert.AreEqual(present3, returnedPresent);
        }
         [Test]
        public void Test_GetPresent_If_Returns_Correct_Present_When_Given_Correct_Name()
        {
            Bag bag = new Bag();
            Present present = new Present("Peshkata", 15);
            bag.Create(present);

            Present returnedPresent = bag.GetPresent("Peshkata");
            Assert.AreEqual(present, returnedPresent);

        }
        
    }
}
