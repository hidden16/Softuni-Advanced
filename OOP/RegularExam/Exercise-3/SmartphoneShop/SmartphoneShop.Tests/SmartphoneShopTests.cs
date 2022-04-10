using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {


        [Test]
        public void Test_Constructor()
        {
            Shop shop;
            Assert.Throws<ArgumentException>(() =>
            {
                shop = new Shop(-16);
            });

            shop = new Shop(16);
            Assert.AreEqual(0, shop.Count);
            Assert.AreEqual(16, shop.Capacity);
        }

        [Test]
        public void Test_Add()
        {
            Smartphone phone = new Smartphone("salamsung", 619);
            Smartphone phone2 = new Smartphone("salamsung", 440);
            Shop shop;

            shop = new Shop(5);
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone2);
            });

            shop = new Shop(1);
            shop.Add(phone2);
            phone = new Smartphone("Hello", 400);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone);
            });

            shop = new Shop(5);
            shop.Add(phone);
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void Test_Remove()
        {
            Smartphone phone = new Smartphone("salamsung", 619);
            Shop shop;

            shop = new Shop(5);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("REMOVEEEE");
            });

            Smartphone phone2 = new Smartphone("kitaifon", 15);
            shop.Add(phone);
            shop.Add(phone2);

            shop.Remove("salamsung");
            Assert.AreEqual(1, shop.Count);
        }
        [Test]
        public void Test_TestPhone()
        {
            Smartphone phone = new Smartphone("salamsung", 619);
            Smartphone phone2 = new Smartphone("kitaifon", 15);
            Shop shop;

            shop = new Shop(5);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("JAPONFON", 124);
            });

            shop.Add(phone2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("kitaifon", 50);
            });

            shop.Add(phone);
            shop.TestPhone("salamsung", 619);
            Assert.AreEqual(0, phone.CurrentBateryCharge);
            shop.TestPhone("kitaifon", 13);
            Assert.AreEqual(2, phone2.CurrentBateryCharge);
        }

        [Test]
        public void Test_ChargePhone()
        {
            Smartphone phone = new Smartphone("salamsung", 619);
            Smartphone phone2 = new Smartphone("kitaifon", 15);
            Shop shop;

            shop = new Shop(5);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("pasdlwdasd");
            });

            shop.Add(phone);
            shop.TestPhone("salamsung", 200);
            Assert.AreEqual(419, phone.CurrentBateryCharge);
            shop.ChargePhone("salamsung");
            Assert.AreEqual(619, phone.CurrentBateryCharge);
        }
    }
}