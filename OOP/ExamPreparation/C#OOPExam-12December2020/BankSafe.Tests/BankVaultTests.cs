using NUnit.Framework;
using System;

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
        public void Test_Constructor()
        {
            Assert.AreEqual(12, bank.VaultCells.Count);
        }
         [Test]
        public void Test_AddItem()
        {
            Item item = new Item("Iks", "005");
            Assert.Throws<ArgumentException>(() =>
            {
                bank.AddItem("jk2", item);
            });

            bank.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() =>
            {
                bank.AddItem("A1", item);
            });

            bank = new BankVault();
            bank.AddItem("B2", item);
            Assert.AreEqual(bank.VaultCells["B2"], item);

            bank = new BankVault();
            bank.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() =>
            {
                bank.AddItem("A2", item);
            });

            bank = new BankVault();
            var test =bank.AddItem("A1", item);
            Assert.AreEqual($"Item:005 saved successfully!", test);
        }
        [Test]
        public void Test_RemoveItem()
        {
            Item item = new Item("Iks", "005");
            Assert.Throws<ArgumentException>(() =>
            {
                bank.RemoveItem("KJ2", item);
            });

            Item item2 = new Item("Vayne", "40");
            bank.AddItem("A1", item);
            bank.AddItem("B2", item2);
            Assert.Throws<ArgumentException>(() =>
            {
                bank.RemoveItem("A1", item2);
            });

            bank.RemoveItem("A1", item);
            Assert.AreEqual(bank.VaultCells["A1"], null);

            var test = bank.RemoveItem("B2", item2);
            Assert.AreEqual($"Remove item:40 successfully!", test);
        }
        [Test]
        public void Test()
        {

        }

    }
}