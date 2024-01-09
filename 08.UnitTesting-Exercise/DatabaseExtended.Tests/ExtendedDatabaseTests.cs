namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person person1;
        private Person person2;
        private Person person3;
        private Person person4;
        private Person person5;
        private Person person6;
        private Person person7;
        private Person person8;
        private Person person9;
        private Person person10;
        private Person person11;
        private Person person12;
        private Person person13;
        private Person person14;
        private Person person15;
        private Person person16;
        private Database database;
        [SetUp]
        public void SetUp()
        {
            person1 = new(420, "person1UserName");
            person2 = new(420420, "person2UserName");
            person3 = new(420420420, "person3UserName");
            person4 = new(123151, "person4UserName");
            person5 = new(42012314, "person5UserName");
            person6 = new(42042051236, "person6UserName");
            person7 = new(4204204201235, "person7UserName");
            person8 = new(1231519, "person8UserName");
            person9 = new(420765, "person9UserName");
            person10 = new(42, "person10UserName");
            person11 = new(4, "person11UserName");
            person12 = new(1, "person12UserName");
            person13 = new(65, "person13UserName");
            person14 = new(48, "person14UserName");
            person15 = new(134, "person15UserName");
            person16 = new(461, "person16UserName");
        }

        [Test]
        public void DatabaseConstructorShouldWorkCorrectly()
        {
            database = new(person1, person2, person3);
            Person[] personArr = new Person[] { person1, person2, person3 };
            personArr[0] = person1;
            personArr[1] = person2;
            personArr[2] = person3;
            Assert.IsNotNull(database);
            Assert.AreEqual(personArr.Count(), database.Count);
        }

        [Test]
        public void AddRangeMethodShouldThrowExceptionWhenAddingMoreThan16Persons()
        {
            Person[] people = new Person[] { person1, person2, person3, person1, person2, person3, person1, person2, person3, person1, person2, person3, person1, person2, person3, person1, person2, person3 };

            Assert.Throws<ArgumentException>(() => database = new(people), "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenCountWillExceed16()
        {
            Person[] people = new Person[] { person1, person2, person3, person4, person5, person6, person7, person8, person9, person10, person11, person12, person13, person14, person15, person16 };
            Person person17 = new(999, "person17UserName");
            database = new(people);
            Assert.Throws<InvalidOperationException>(() => database.Add(person17), "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenPersonWithTheSameUsernameAlreadyExists()
        {
            Person[] people = new Person[] { person1, person2, person3 };
            Person person3WithSameUsername = new(9999, "person3UserName");
            database = new(people);
            Assert.Throws<InvalidOperationException>(() => database.Add(person3WithSameUsername), "There is already user with this username!");
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenPersonWithTheSameIDAlreadyExists()
        {
            Person[] people = new Person[] { person1, person2, person3 };
            Person person3WithSameID = new(420420420, "person3CopyUserName");
            database = new(people);
            Assert.Throws<InvalidOperationException>(() => database.Add(person3WithSameID), "There is already user with this Id!");
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenArrayIsEmpty()
        {
            database = new();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void RemoveMethodShouldDecreaseArrayCount()
        {
            database = new(person1, person2, person3);
            int expectedArrCount = database.Count - 1;
            database.Remove();
            Assert.AreEqual(expectedArrCount, database.Count);
        }

        [Test]
        public void FindByUsernameMethod_Should_ThrowException_When_Username_IsNull_Or_Empty()
        {
            database = new(person1, person2, person3);
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null), "Username parameter is null!");
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(""), "Username parameter is null!");
        }

        [Test]
        public void FindByUsernameMethod_Should_ThrowException_When_Username_IsNotFound()
        {
            database = new(person1, person2, person3);
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("NotExistingUsername"), "No user is present by this username!");
        }

        [Test]
        public void FindByUsernameMethod_Should_WorkCorrectly()
        {
            database = new(person1, person2, person3);
            Person foundPerson = database.FindByUsername(person1.UserName);
            Assert.AreEqual(person1, foundPerson);
        }

        [Test]
        public void FindByIDMethod_Should_ThrowException_When_ID_IsNegativeNumber()
        {
            database = new(person1, person2, person3);
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1), "Id should be a positive number!");
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-20), "Id should be a positive number!");
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-200), "Id should be a positive number!");
        }

        [Test]
        public void FindByIDMethod_Should_ThrowException_When_Id_IsNotFound()
        {
            database = new(person1, person2, person3);
            Assert.Throws<InvalidOperationException>(() => database.FindById(666), "No user is present by this ID!");
        }

        [Test]
        public void FindByIDMethod_Should_WorkCorrectly()
        {
            database = new(person1, person2, person3);
            Person foundPerson = database.FindById(person1.Id);
            Assert.AreEqual(person1, foundPerson);
        }
    }
}