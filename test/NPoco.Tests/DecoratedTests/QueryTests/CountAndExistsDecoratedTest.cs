using System;
using System.Linq;
using System.Threading.Tasks;
using NPoco.Tests.Common;
using NUnit.Framework;

namespace NPoco.Tests.DecoratedTests.QueryTests
{
    [TestFixture]
    public class CountAndExistsDecoratedTest : BaseDBDecoratedTest
    {
        [Test]
        public void Count_WithNoSql_ReturnsTotalCount()
        {
            var count = Database.Count<UserDecorated>();
            Assert.AreEqual(InMemoryUsers.Count, count);
        }

        [Test]
        public void Count_WithSql_ReturnsFilteredCount()
        {
            var count = Database.Count<UserDecorated>("WHERE Age > @0", 25);
            var expected = InMemoryUsers.Count(x => x.Age > 25);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public void Count_WithSqlAndArgs_ReturnsFilteredCount()
        {
            var count = Database.Count<UserDecorated>("WHERE Age > @0 AND Age < @1", 21, 30);
            var expected = InMemoryUsers.Count(x => x.Age > 21 && x.Age < 30);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public void Count_WithSqlObject_ReturnsFilteredCount()
        {
            var sql = new Sql("WHERE Age > @0", 25);
            var count = Database.Count<UserDecorated>(sql);
            var expected = InMemoryUsers.Count(x => x.Age > 25);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public void Exists_WithNoSql_ReturnsTrueWhenDataExists()
        {
            var exists = Database.Exists<UserDecorated>();
            Assert.IsTrue(exists);
        }

        [Test]
        public void Exists_WithNoSql_ReturnsFalseWhenNoData()
        {
            Database.Delete<UserDecorated>("WHERE UserId > 0");
            var exists = Database.Exists<UserDecorated>();
            Assert.IsFalse(exists);
        }

        [Test]
        public void Exists_WithSql_ReturnsTrueWhenMatchExists()
        {
            var exists = Database.Exists<UserDecorated>("WHERE Age > @0", 25);
            Assert.IsTrue(exists);
        }

        [Test]
        public void Exists_WithSql_ReturnsFalseWhenNoMatch()
        {
            var exists = Database.Exists<UserDecorated>("WHERE Age > @0", 100);
            Assert.IsFalse(exists);
        }

        [Test]
        public void Exists_WithSqlAndArgs_ReturnsTrueWhenMatchExists()
        {
            var exists = Database.Exists<UserDecorated>("WHERE Age > @0 AND Age < @1", 21, 30);
            Assert.IsTrue(exists);
        }

        [Test]
        public void Exists_WithSqlAndArgs_ReturnsFalseWhenNoMatch()
        {
            var exists = Database.Exists<UserDecorated>("WHERE Age > @0 AND Age < @1", 100, 200);
            Assert.IsFalse(exists);
        }

        [Test]
        public void Exists_WithSqlObject_ReturnsTrueWhenMatchExists()
        {
            var sql = new Sql("WHERE Age > @0", 25);
            var exists = Database.Exists<UserDecorated>(sql);
            Assert.IsTrue(exists);
        }

        [Test]
        public void Exists_WithSqlObject_ReturnsFalseWhenNoMatch()
        {
            var sql = new Sql("WHERE Age > @0", 100);
            var exists = Database.Exists<UserDecorated>(sql);
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task CountAsync_WithNoSql_ReturnsTotalCount()
        {
            var count = await Database.CountAsync<UserDecorated>();
            Assert.AreEqual(InMemoryUsers.Count, count);
        }

        [Test]
        public async Task CountAsync_WithSql_ReturnsFilteredCount()
        {
            var count = await Database.CountAsync<UserDecorated>("WHERE Age > @0", new object[] { 25 });
            var expected = InMemoryUsers.Count(x => x.Age > 25);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public async Task CountAsync_WithSqlAndArgs_ReturnsFilteredCount()
        {
            var count = await Database.CountAsync<UserDecorated>("WHERE Age > @0 AND Age < @1", new object[] { 21, 30 });
            var expected = InMemoryUsers.Count(x => x.Age > 21 && x.Age < 30);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public async Task CountAsync_WithSqlObject_ReturnsFilteredCount()
        {
            var sql = new Sql("WHERE Age > @0", 25);
            var count = await Database.CountAsync<UserDecorated>(sql);
            var expected = InMemoryUsers.Count(x => x.Age > 25);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public async Task ExistsAsync_WithNoSql_ReturnsTrueWhenDataExists()
        {
            var exists = await Database.ExistsAsync<UserDecorated>();
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsAsync_WithSql_ReturnsTrueWhenMatchExists()
        {
            var exists = await Database.ExistsAsync<UserDecorated>("WHERE Age > @0", new object[] { 25 });
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsAsync_WithSql_ReturnsFalseWhenNoMatch()
        {
            var exists = await Database.ExistsAsync<UserDecorated>("WHERE Age > @0", new object[] { 100 });
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task ExistsAsync_WithSqlAndArgs_ReturnsTrueWhenMatchExists()
        {
            var exists = await Database.ExistsAsync<UserDecorated>("WHERE Age > @0 AND Age < @1", new object[] { 21, 30 });
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsAsync_WithSqlAndArgs_ReturnsFalseWhenNoMatch()
        {
            var exists = await Database.ExistsAsync<UserDecorated>("WHERE Age > @0 AND Age < @1", new object[] { 100, 200 });
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task ExistsAsync_WithSqlObject_ReturnsTrueWhenMatchExists()
        {
            var sql = new Sql("WHERE Age > @0", 25);
            var exists = await Database.ExistsAsync<UserDecorated>(sql);
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsAsync_WithSqlObject_ReturnsFalseWhenNoMatch()
        {
            var sql = new Sql("WHERE Age > @0", 100);
            var exists = await Database.ExistsAsync<UserDecorated>(sql);
            Assert.IsFalse(exists);
        }

        [Test]
        public void Count_NonGeneric_WithNoSql_ReturnsTotalCount()
        {
            var count = Database.Count(typeof(UserDecorated));
            Assert.AreEqual(InMemoryUsers.Count, count);
        }

        [Test]
        public void Count_NonGeneric_WithSql_ReturnsFilteredCount()
        {
            var count = Database.Count(typeof(UserDecorated), "WHERE Age > @0", 25);
            var expected = InMemoryUsers.Count(x => x.Age > 25);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public void Count_NonGeneric_WithSqlAndArgs_ReturnsFilteredCount()
        {
            var count = Database.Count(typeof(UserDecorated), "WHERE Age > @0 AND Age < @1", 21, 30);
            var expected = InMemoryUsers.Count(x => x.Age > 21 && x.Age < 30);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public void Count_NonGeneric_WithSqlObject_ReturnsFilteredCount()
        {
            var sql = new Sql("WHERE Age > @0", 25);
            var count = Database.Count(typeof(UserDecorated), sql);
            var expected = InMemoryUsers.Count(x => x.Age > 25);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public void Exists_NonGeneric_WithNoSql_ReturnsTrueWhenDataExists()
        {
            var exists = Database.Exists(typeof(UserDecorated));
            Assert.IsTrue(exists);
        }

        [Test]
        public void Exists_NonGeneric_WithNoSql_ReturnsFalseWhenNoData()
        {
            Database.Delete<UserDecorated>("WHERE UserId > 0");
            var exists = Database.Exists(typeof(UserDecorated));
            Assert.IsFalse(exists);
        }

        [Test]
        public void Exists_NonGeneric_WithSql_ReturnsTrueWhenMatchExists()
        {
            var exists = Database.Exists(typeof(UserDecorated), "WHERE Age > @0", 25);
            Assert.IsTrue(exists);
        }

        [Test]
        public void Exists_NonGeneric_WithSql_ReturnsFalseWhenNoMatch()
        {
            var exists = Database.Exists(typeof(UserDecorated), "WHERE Age > @0", 100);
            Assert.IsFalse(exists);
        }

        [Test]
        public void Exists_NonGeneric_WithSqlAndArgs_ReturnsTrueWhenMatchExists()
        {
            var exists = Database.Exists(typeof(UserDecorated), "WHERE Age > @0 AND Age < @1", 21, 30);
            Assert.IsTrue(exists);
        }

        [Test]
        public void Exists_NonGeneric_WithSqlAndArgs_ReturnsFalseWhenNoMatch()
        {
            var exists = Database.Exists(typeof(UserDecorated), "WHERE Age > @0 AND Age < @1", 100, 200);
            Assert.IsFalse(exists);
        }

        [Test]
        public void Exists_NonGeneric_WithSqlObject_ReturnsTrueWhenMatchExists()
        {
            var sql = new Sql("WHERE Age > @0", 25);
            var exists = Database.Exists(typeof(UserDecorated), sql);
            Assert.IsTrue(exists);
        }

        [Test]
        public void Exists_NonGeneric_WithSqlObject_ReturnsFalseWhenNoMatch()
        {
            var sql = new Sql("WHERE Age > @0", 100);
            var exists = Database.Exists(typeof(UserDecorated), sql);
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task CountAsync_NonGeneric_WithNoSql_ReturnsTotalCount()
        {
            var count = await Database.CountAsync(typeof(UserDecorated));
            Assert.AreEqual(InMemoryUsers.Count, count);
        }

        [Test]
        public async Task CountAsync_NonGeneric_WithSql_ReturnsFilteredCount()
        {
            var count = await Database.CountAsync(typeof(UserDecorated), "WHERE Age > @0", new object[] { 25 });
            var expected = InMemoryUsers.Count(x => x.Age > 25);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public async Task CountAsync_NonGeneric_WithSqlAndArgs_ReturnsFilteredCount()
        {
            var count = await Database.CountAsync(typeof(UserDecorated), "WHERE Age > @0 AND Age < @1", new object[] { 21, 30 });
            var expected = InMemoryUsers.Count(x => x.Age > 21 && x.Age < 30);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public async Task CountAsync_NonGeneric_WithSqlObject_ReturnsFilteredCount()
        {
            var sql = new Sql("WHERE Age > @0", 25);
            var count = await Database.CountAsync(typeof(UserDecorated), sql);
            var expected = InMemoryUsers.Count(x => x.Age > 25);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public async Task ExistsAsync_NonGeneric_WithNoSql_ReturnsTrueWhenDataExists()
        {
            var exists = await Database.ExistsAsync(typeof(UserDecorated));
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsAsync_NonGeneric_WithSql_ReturnsTrueWhenMatchExists()
        {
            var exists = await Database.ExistsAsync(typeof(UserDecorated), "WHERE Age > @0", new object[] { 25 });
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsAsync_NonGeneric_WithSql_ReturnsFalseWhenNoMatch()
        {
            var exists = await Database.ExistsAsync(typeof(UserDecorated), "WHERE Age > @0", new object[] { 100 });
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task ExistsAsync_NonGeneric_WithSqlAndArgs_ReturnsTrueWhenMatchExists()
        {
            var exists = await Database.ExistsAsync(typeof(UserDecorated), "WHERE Age > @0 AND Age < @1", new object[] { 21, 30 });
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsAsync_NonGeneric_WithSqlAndArgs_ReturnsFalseWhenNoMatch()
        {
            var exists = await Database.ExistsAsync(typeof(UserDecorated), "WHERE Age > @0 AND Age < @1", new object[] { 100, 200 });
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task ExistsAsync_NonGeneric_WithSqlObject_ReturnsTrueWhenMatchExists()
        {
            var sql = new Sql("WHERE Age > @0", 25);
            var exists = await Database.ExistsAsync(typeof(UserDecorated), sql);
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsAsync_NonGeneric_WithSqlObject_ReturnsFalseWhenNoMatch()
        {
            var sql = new Sql("WHERE Age > @0", 100);
            var exists = await Database.ExistsAsync(typeof(UserDecorated), sql);
            Assert.IsFalse(exists);
        }

        [Test]
        public void Count_WithSqlWithoutWhere_ReturnsFilteredCount()
        {
            var sql = new Sql("Age > @0", 25);
            var count = Database.Count<UserDecorated>(sql);
            var expected = InMemoryUsers.Count(x => x.Age > 25);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public void Count_WithSqlWithWhere_ReturnsFilteredCount()
        {
            var sql = new Sql("WHERE Age > @0", 25);
            var count = Database.Count<UserDecorated>(sql);
            var expected = InMemoryUsers.Count(x => x.Age > 25);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public void Exists_WithSqlWithoutWhere_ReturnsTrueWhenMatchExists()
        {
            var exists = Database.Exists<UserDecorated>("Age > @0", 25);
            Assert.IsTrue(exists);
        }

        [Test]
        public void Exists_WithSqlWithWhere_ReturnsTrueWhenMatchExists()
        {
            var exists = Database.Exists<UserDecorated>("WHERE Age > @0", 25);
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task CountAsync_WithSqlWithoutWhere_ReturnsFilteredCount()
        {
            var sql = new Sql("Age > @0", 25);
            var count = await Database.CountAsync<UserDecorated>(sql);
            var expected = InMemoryUsers.Count(x => x.Age > 25);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public async Task CountAsync_WithSqlWithWhere_ReturnsFilteredCount()
        {
            var sql = new Sql("WHERE Age > @0", 25);
            var count = await Database.CountAsync<UserDecorated>(sql);
            var expected = InMemoryUsers.Count(x => x.Age > 25);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public async Task ExistsAsync_WithSqlWithoutWhere_ReturnsTrueWhenMatchExists()
        {
            var exists = await Database.ExistsAsync<UserDecorated>("Age > @0", new object[] { 25 });
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsAsync_WithSqlWithWhere_ReturnsTrueWhenMatchExists()
        {
            var exists = await Database.ExistsAsync<UserDecorated>("WHERE Age > @0", new object[] { 25 });
            Assert.IsTrue(exists);
        }

        [Test]
        public void Count_WithExpression_ReturnsFilteredCount()
        {
            var count = Database.Count<UserDecorated>(x => x.Age > 25);
            var expected = InMemoryUsers.Count(x => x.Age > 25);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public void Count_WithExpressionAndMultipleConditions_ReturnsFilteredCount()
        {
            var count = Database.Count<UserDecorated>(x => x.Age > 21 && x.Age < 30);
            var expected = InMemoryUsers.Count(x => x.Age > 21 && x.Age < 30);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public void Any_WithExpression_ReturnsTrueWhenMatchExists()
        {
            var exists = Database.Any<UserDecorated>(x => x.Age > 25);
            Assert.IsTrue(exists);
        }

        [Test]
        public void Any_WithExpression_ReturnsFalseWhenNoMatch()
        {
            var exists = Database.Any<UserDecorated>(x => x.Age > 100);
            Assert.IsFalse(exists);
        }

        [Test]
        public void Exists_WithExpression_ReturnsTrueWhenMatchExists()
        {
            var exists = Database.Exists<UserDecorated>(x => x.Age > 25);
            Assert.IsTrue(exists);
        }

        [Test]
        public void Exists_WithExpression_ReturnsFalseWhenNoMatch()
        {
            var exists = Database.Exists<UserDecorated>(x => x.Age > 100);
            Assert.IsFalse(exists);
        }

        [Test]
        public void Single_WithExpression_ReturnsMatchingEntity()
        {
            var expectedUser = InMemoryUsers.First(x => x.UserId == 1);
            var user = Database.Single<UserDecorated>(x => x.UserId == 1);
            Assert.AreEqual(expectedUser.UserId, user.UserId);
            Assert.AreEqual(expectedUser.Name, user.Name);
        }

        [Test]
        public void FirstOrDefault_WithExpression_ReturnsMatchingEntity()
        {
            var expectedUser = InMemoryUsers.First(x => x.Age > 25);
            var user = Database.FirstOrDefault<UserDecorated>(x => x.Age > 25);
            Assert.IsNotNull(user);
            Assert.AreEqual(expectedUser.UserId, user.UserId);
        }

        [Test]
        public void FirstOrDefault_WithExpression_ReturnsNullWhenNoMatch()
        {
            var user = Database.FirstOrDefault<UserDecorated>(x => x.Age > 100);
            Assert.IsNull(user);
        }

        [Test]
        public async Task CountAsync_WithExpression_ReturnsFilteredCount()
        {
            var count = await Database.CountAsync<UserDecorated>(x => x.Age > 25);
            var expected = InMemoryUsers.Count(x => x.Age > 25);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public async Task CountAsync_WithExpressionAndMultipleConditions_ReturnsFilteredCount()
        {
            var count = await Database.CountAsync<UserDecorated>(x => x.Age > 21 && x.Age < 30);
            var expected = InMemoryUsers.Count(x => x.Age > 21 && x.Age < 30);
            Assert.AreEqual(expected, count);
        }

        [Test]
        public async Task AnyAsync_WithExpression_ReturnsTrueWhenMatchExists()
        {
            var exists = await Database.AnyAsync<UserDecorated>(x => x.Age > 25);
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task AnyAsync_WithExpression_ReturnsFalseWhenNoMatch()
        {
            var exists = await Database.AnyAsync<UserDecorated>(x => x.Age > 100);
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task ExistsAsync_WithExpression_ReturnsTrueWhenMatchExists()
        {
            var exists = await Database.ExistsAsync<UserDecorated>(x => x.Age > 25);
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsAsync_WithExpression_ReturnsFalseWhenNoMatch()
        {
            var exists = await Database.ExistsAsync<UserDecorated>(x => x.Age > 100);
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task SingleAsync_WithExpression_ReturnsMatchingEntity()
        {
            var expectedUser = InMemoryUsers.First(x => x.UserId == 1);
            var user = await Database.SingleAsync<UserDecorated>(x => x.UserId == 1);
            Assert.AreEqual(expectedUser.UserId, user.UserId);
            Assert.AreEqual(expectedUser.Name, user.Name);
        }

        [Test]
        public async Task FirstOrDefaultAsync_WithExpression_ReturnsMatchingEntity()
        {
            var expectedUser = InMemoryUsers.First(x => x.Age > 25);
            var user = await Database.FirstOrDefaultAsync<UserDecorated>(x => x.Age > 25);
            Assert.IsNotNull(user);
            Assert.AreEqual(expectedUser.UserId, user.UserId);
        }

        [Test]
        public async Task FirstOrDefaultAsync_WithExpression_ReturnsNullWhenNoMatch()
        {
            var user = await Database.FirstOrDefaultAsync<UserDecorated>(x => x.Age > 100);
            Assert.IsNull(user);
        }
    }
}