using LapShop.Data;
using LapShop.Data.Repository;
using LapShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LapShop.Tests
{
    public class CategoryRepositoryTests
    {
        // setting up mock data
        private readonly MainContext _Context;
        private readonly GenericRepository<Category> _Repository;

        public CategoryRepositoryTests()
        {
            var Options = new DbContextOptionsBuilder<MainContext>()
                .UseInMemoryDatabase(databaseName: "LapShopTestDb")
                .Options;
            _Context = new MainContext(Options);
            _Repository = new GenericRepository<Category>(_Context);
        }

        [Fact]
        public async Task AddAsync_ObjIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            Category TestCategory = null;

            // Act
            async Task Act() => await _Repository.AddAsync(TestCategory);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task Delete_ObjIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            Category TestCategory = null;

            // Act
            async Task Act() => _Repository.Delete(TestCategory);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task GetById_IdIsNegative_ThrowsArgumentNullException()
        {
            // Arrange
            int id = -1;

            // Act
            async Task Act() => await _Repository.GetByIdAsync(id);

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(Act);
        }


        [Fact]
        public async Task Update_ObjIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            Category Obj = null;

            // Act
            async Task Act() => _Repository.Update(Obj);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }
    }
}
