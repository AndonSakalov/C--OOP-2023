using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Dummy dummy;
        private Axe axe;

        [SetUp]
        public void SetUp()
        {
            dummy = new(100, 50);
            axe = new(10, 40);
        }

        [Test]
        public void When_AttackingDummyWithAxe_Axe_Should_LoseDurabilityPoints()
        {
            axe.Attack(dummy);
            Assert.AreEqual(axe.DurabilityPoints, 39);
        }

        [Test]
        public void When_AttackingWithBrokenAxe_Exception_ShouldBe_Thrown()
        {
            axe = new(100, 0);
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}