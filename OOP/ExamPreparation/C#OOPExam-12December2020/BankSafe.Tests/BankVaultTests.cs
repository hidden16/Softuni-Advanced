using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bank;
        [SetUp]
        public void Setup()
        {
            bank = new BankVault();
        }

        [Test]
        public void Test_Constructor_If_Instances_Correctly()
        {
            Assert.AreEqual(12, bank.VaultCells.Count);
        }
        [Test]
        public void Test_AddItem_If_We_Give_Cell_That_Doesnt_Exist_Should_Throw_ArgumentException()
        {
            Item item = new Item("asd", "123");
            Assert.Throws<ArgumentException>(() =>
            {
                bank.AddItem("Q12", item);
            });
        }
        [Test]
        public void Test_AddItem_If_We_Add_To_The_Same_Cell_Should_Throw_ArgumentException()
        {
            Item item = new Item("asd", "123");
            bank.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() =>
            {
                bank.AddItem("A1", item);
            });
        }
        [Test]
        public void Test_AddItem_If_We_Try_To_Add_1_Item_To_2_Places_Should_Throw_InvalidOperationException()
        {
            Item item = new Item("asd", "123");
            bank.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() =>
            {
                bank.AddItem("B2", item);
            });
           
        }
        [Test]
        public void Test_AddItem_If_Adds_Correctly_To_Dictionary()
        {
            Item item = new Item("asd", "123");
            bank.AddItem("A1", item);
            Assert.IsTrue(bank.VaultCells["A1"].ItemId == "123");
        }
        [Test]
        public void Test_AddItem_If_Returns_String_Correctly()
        {
            Item item = new Item("asd", "123");
            var output = bank.AddItem("A1", item);
            Assert.AreEqual($"Item:123 saved successfully!", output);
        }
        [Test]
        public void Test_RemoveItem_If_Recieves_A_Cell_That_Doesnt_Exist_Should_Throw_ArgumentException()
        {
            Item item = new Item("Peshkata", "123");
            bank.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() =>
            {
                bank.RemoveItem("J9", item);
            });
        }
        [Test]
        public void Test_RemoveItem_If_Recieves_Invalid_Item_To_Remove_Should_Throw_ArgumentException()
        {
            Item item = new Item("Peshkata", "123");
            Item item2 = new Item("Goshkata", "12345");
            bank.AddItem("A1", item2);
            bank.AddItem("B1", item);
            Assert.Throws<ArgumentException>(() =>
            {
                bank.RemoveItem("A1", item);
            });
        }
        [Test]
        public void Test_RemoveItem_If_Removes_Item_Correctly_Value_Should_Become_Null()
        {
            Item item = new Item("Peshkata", "123");
            bank.AddItem("A1", item);
            bank.RemoveItem("A1", item);
            Assert.IsTrue(bank.VaultCells["A1"] == null);
        }
        [Test]
        public void Test_RemoveItem_If_Returns_Correct_String()
        {
            Item item = new Item("Peshkata", "123");
            bank.AddItem("A1", item);
            var output = bank.RemoveItem("A1", item);
            Assert.AreEqual($"Remove item:123 successfully!", output);
        }

    }
}