using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Test_If_Dummy_Loses_Health_After_Attack()
        {
            Dummy dummy = new Dummy(100, 100);
            dummy.TakeAttack(1);
            Assert.AreEqual(99, dummy.Health);
        }
        [Test]
        public void Test_If_Dummy_Throws_Exception_If_It_Is_Dead_And_Gets_Attacked()
        {
            Dummy dummy = new Dummy(0, 100);
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(1);
            });
        }
        [Test]
        public void Test_Dead_Dummy_Should_Give_Xp()
        {
            Dummy dummy = new Dummy(0, 100);
            var xp = dummy.GiveExperience();
            Assert.AreEqual(100, xp);
        }
        [Test]
        public void Test_Alive_Dummy_Should_Not_Give_Xp()
        {
            Dummy dummy = new Dummy(100, 100);
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}