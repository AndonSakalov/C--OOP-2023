namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {

        private Warrior warrior;
        [SetUp]
        public void SetUp()
        {
            warrior = new("BlackHand", 70, 100);
        }

        [Test]
        public void WarriorConstructor_Should_SetProperties_Correctly()
        {
            warrior = new("Andon", 90, 120);

            string expectedName = "Andon";
            int expectedDamage = 90;
            int expectedHP = 120;

            Assert.IsNotNull(warrior);
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHP, warrior.HP);
        }

        [Test]
        public void WarriorNameSetter_Should_ThrowException_WhenTheNameIsNullOrWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => warrior = new(null, 50, 100), "Name should not be empty or whitespace!");
            Assert.Throws<ArgumentException>(() => warrior = new(" ", 50, 100), "Name should not be empty or whitespace!");
            Assert.Throws<ArgumentException>(() => warrior = new("", 50, 100), "Name should not be empty or whitespace!");
        }

        [Test]
        public void WarriorDamageSetter_Should_ThrowException_WhenTheValueIsNegativeOrZero()
        {
            Assert.Throws<ArgumentException>(() => warrior = new("Doni", 0, 100), "Damage value should be positive!");
            Assert.Throws<ArgumentException>(() => warrior = new("Doni", -1, 100), "Damage value should be positive!");
            Assert.Throws<ArgumentException>(() => warrior = new("Doni", -100, 100), "Damage value should be positive!");
        }

        [Test]
        public void WarriorHPSetter_Should_ThrowException_WhenTheValueIsNegative()
        {
            Assert.Throws<ArgumentException>(() => warrior = new("Doni", 50, -1), "HP should not be negative!");
            Assert.Throws<ArgumentException>(() => warrior = new("Doni", 50, -10), "HP should not be negative!");
            Assert.Throws<ArgumentException>(() => warrior = new("Doni", 50, -1000), "HP should not be negative!");
        }

        [Test]
        public void AttackMethod_Should_ThrowException_When_AttackingWarriorHPIsLowerThanMinAttackHP()
        {
            int minAttackHP = 30;
            Warrior attackingWarrior = new("Attacker", 50, 25);
            Warrior defendingWarrior = new("Defender", 50, 100);

            Assert.Throws<InvalidOperationException>(() => attackingWarrior.Attack(defendingWarrior), "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        public void AttackMethod_Should_ThrowException_When_DefendingWarriorHPIsLowerThanMinAttackHP()
        {
            int minAttackHP = 30;
            Warrior attackingWarrior = new("Attacker", 50, 100);
            Warrior defendingWarrior = new("Defender", 50, 25);

            Assert.Throws<InvalidOperationException>(() => attackingWarrior.Attack(defendingWarrior), $"Enemy HP must be greater than {minAttackHP} in order to attack him!");
        }

        [Test]
        public void AttackMethod_Should_ThrowException_When_DefendingWarriorDamageIsMoreThanAttackingWarriorHP()
        {
            Warrior attackingWarrior = new("Attacker", 50, 50);
            Warrior defendingWarrior = new("Defender", 70, 25);

            Assert.Throws<InvalidOperationException>(() => attackingWarrior.Attack(defendingWarrior), "You are trying to attack too strong enemy");
        }

        [Test]
        public void AttackMethod_Should_DecreaseAttackingWarriorHPByDefendingWarriorDamage()
        {
            Warrior attackingWarrior = new("Attacker", 50, 120);
            Warrior defendingWarrior = new("Defender", 70, 150);

            int expectedAttackingWarriorHpAfterBeingAttacked = attackingWarrior.HP - defendingWarrior.Damage;

            attackingWarrior.Attack(defendingWarrior);
            Assert.AreEqual(expectedAttackingWarriorHpAfterBeingAttacked, attackingWarrior.HP);
        }

        [Test]
        public void AttackMethod_Should_SetDefendingWarriorHPToZeroIfAttackingWarriorDamageIsMoreThanDefendingWarriorHP()
        {
            Warrior attackingWarrior1 = new("Attacker1", 80, 120);
            Warrior attackingWarrior2 = new("Attacker2", 150, 120);
            Warrior defendingWarrior1 = new("Defender1", 70, 70);
            Warrior defendingWarrior2 = new("Defender2", 70, 70);

            int expectedDefendingWarriorHPAfterBeingAttacked = 0;

            attackingWarrior1.Attack(defendingWarrior1);
            attackingWarrior2.Attack(defendingWarrior2);
            Assert.AreEqual(expectedDefendingWarriorHPAfterBeingAttacked, defendingWarrior1.HP);
            Assert.AreEqual(expectedDefendingWarriorHPAfterBeingAttacked, defendingWarrior2.HP);
        }

        [Test]
        public void AttackMethod_Should_SetDefendingWarriorHPCorrectlyAfterBeingAttacked()
        {
            Warrior attackingWarrior = new("Attacker", 50, 120);
            Warrior defendingWarrior = new("Defender", 70, 150);

            int expectedDefendingWarriorHpAfterBeingAttacked = defendingWarrior.HP - attackingWarrior.Damage;

            attackingWarrior.Attack(defendingWarrior);
            Assert.AreEqual(expectedDefendingWarriorHpAfterBeingAttacked, defendingWarrior.HP);
        }
    }
}