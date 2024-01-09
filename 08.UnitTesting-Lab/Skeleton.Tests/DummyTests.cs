using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy aliveDummy;
        private Dummy deadDummy;
        private Axe axe;

        [SetUp]
        public void SetUp()
        {
            aliveDummy = new(100, 50);
            axe = new(10, 40);
            deadDummy = new(0, 50);
        }
        [Test]
        public void When_DummyIsAttacked_Should_LoseHealthPoints()
        {
            int initialDummyHealth = aliveDummy.Health;
            aliveDummy.TakeAttack(axe.AttackPoints);
            Assert.AreEqual(initialDummyHealth - axe.AttackPoints, aliveDummy.Health);
        }

        [Test]
        public void When_DeadDummyIsAttacked_Should_ThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => deadDummy.TakeAttack(axe.AttackPoints), "Dummy is dead.");
        }

        [Test]
        public void When_DummyIsDead_Should_GiveExperience()
        {
            Assert.AreEqual(50, deadDummy.GiveExperience());
        }

        [Test]
        public void When_DummyIsAlive_ShouldNot_GiveExperience()
        {
            Assert.Throws<InvalidOperationException>(() => aliveDummy.GiveExperience(), "Dummy is not dead.");
        }
    }
}