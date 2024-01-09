namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        Database database;
        [SetUp]

        public void SetUp()
        {
            database = new Database(new[] { 1, 2, 3, 4, 5 });
        }



        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void CreatingDatabaseShouldWorkCorrectly(int[] data)
        {
            Assert.AreEqual(data.Count(), database.Count);
            Assert.IsNotNull(database);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void CreatingDatabaseShouldAddElementsCorrectly(int[] data)
        {
            database = new(data);
            int[] databaseCopy = database.Fetch();
            Assert.AreEqual(data, databaseCopy);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddMethodShouldThrowExceptionWhenTheArrayCountWillExceed16(int[] data)
        {
            database = new(data);
            Assert.Throws<InvalidOperationException>(() => database.Add(1), "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void AddMethodShouldWorkCorrectly(int[] data)
        {
            database = new(data);
            int expectedCount = database.Count + 1;
            database.Add(1);
            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(new int[] { })]
        public void RemoveMethodShouldThrowExceptionWhenTheArrayIsEmpty(int[] data)
        {
            database = new(data);
            Assert.Throws<InvalidOperationException>(() => database.Remove(), "The collection is empty!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void RemoveMethodShouldWorkCorrectly(int[] data)
        {
            database = new(data);
            int expectedCount = database.Count - 1;
            database.Remove();
            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void FetchMethodShouldWorkCorrectly(int[] data)
        {
            database = new(data);
            int[] databaseCopy = database.Fetch();
            Assert.AreEqual(data, databaseCopy);
        }

    }
}
