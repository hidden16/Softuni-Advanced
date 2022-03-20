using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Test_If_Weapon_Loses_Durability_After_Each_Attack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(100, 100);
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe doesn't lose durability after attack!");
        }
        [Test]
        public void Test_If_Can_Attack_With_Broken_Weapon()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(100, 100);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }
    }
}