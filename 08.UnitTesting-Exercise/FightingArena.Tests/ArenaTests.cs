namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        Arena arena;
        Warrior attackingWarrior;
        Warrior defendingWarrior;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            attackingWarrior = new("Doni", 70, 150);
            defendingWarrior = new("Tasko", 60, 120);
        }

        [Test]
        public void CreatingArena_Should_CreateEmptyListOfWarriorsAndPropertyCountShouldBeCorrect()
        {
            int expectedListOfWarriorsCount = 0;

            Assert.AreEqual(expectedListOfWarriorsCount, arena.Warriors.Count);
            Assert.AreEqual(expectedListOfWarriorsCount, arena.Count);
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void EnrollMethod_Should_ThrowExceptionIfTheWarriorIsAlreadyEnrolledForTheFights()
        {
            arena.Enroll(attackingWarrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(attackingWarrior), "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void EnrollMethod_Should_AddWarriorsToTheListOfWarriorsForFighting()
        {
            arena.Enroll(attackingWarrior);
            arena.Enroll(defendingWarrior);

            int expectedEnrolledWarriorsCount = 2;

            Assert.AreEqual(expectedEnrolledWarriorsCount, arena.Warriors.Count);
        }

        [Test]
        public void FightMethod_Should_FindAttackingAndDefendingWarriorsFromTheListCorrectlyIfTheyExistAndDoAttackMethod()
        {
            attackingWarrior = new("Doni", 70, 150);
            defendingWarrior = new("Tasko", 60, 120);
            arena.Enroll(attackingWarrior);
            arena.Enroll(defendingWarrior);
            int expectedDefendingWarriorHpAfterBeingAttacked = defendingWarrior.HP - attackingWarrior.Damage;
            int expectedAttackingWarriorHpAfterBeingHitByDefendingWarrior = attackingWarrior.HP - defendingWarrior.Damage;

            arena.Fight(attackingWarrior.Name, defendingWarrior.Name);

            Assert.AreEqual(expectedDefendingWarriorHpAfterBeingAttacked, defendingWarrior.HP);
            Assert.AreEqual(expectedAttackingWarriorHpAfterBeingHitByDefendingWarrior, attackingWarrior.HP);
        }

        [Test]
        public void FightMethod_Should_ThrowExceptionIfWarriorIsNotFoundInTheListOfWarriors()
        {
            string nonExistingName = "Markus";

            //MissingDefendingWarrior
            arena.Enroll(attackingWarrior);
            Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attackingWarrior.Name, nonExistingName),
            $"There is no fighter with name {nonExistingName} enrolled for the fights!");

            //MissingAttackingWarrior
            arena = new();
            arena.Enroll(defendingWarrior);
            Assert.Throws<InvalidOperationException>(()
                => arena.Fight(nonExistingName, defendingWarrior.Name),
                $"There is no fighter with name {nonExistingName} enrolled for the fights!");

            ////MissingBothWarriors => defendingWarrior name should be in the output
            //arena = new();
            //Assert.Throws<InvalidOperationException>(()
            //    => arena.Fight(attackingWarrior.Name, defendingWarrior.Name),
            //    $"There is no fighter with name {defendingWarrior.Name} enrolled for the fights!"
            //);

        }
    }
}
