using LapShop.Models;
using LapShop.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace LapShop.Tests
{
    public class CategoryRepositoryTests
    {
        // setting up mock data
        private readonly MainContext _Context;
        private readonly CategoryRepository _Repository;

        public CategoryRepositoryTests()
        {
            _Context = new MainContext();
            _Repository = new CategoryRepository(_Context);
        }

        [Fact]
        public async Task Create_ObjIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            Category TestCategory = null;

            // Act
            async Task Act() => await _Repository.Create(TestCategory);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task Delete_ObjIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            Category TestCategory = null;

            // Act
            async Task Act() => await _Repository.Delete(TestCategory);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task GetAll_ObjIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            List<string> NavProps = null;
            // Act
            async Task Act() => await _Repository.GetAll(NavProps);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task GetById_IdIsNegative_ThrowsArgumentNullException()
        {
            // Arrange
            int id = -1;

            // Act
            async Task Act() => await _Repository.GetById(id);

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(Act);
        }

        [Fact]
        public async Task GetById_NavPropsIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            int id = 0;
            List<string> NavProps = null;

            // Act
            async Task Act() => await _Repository.GetById(id, NavProps);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task GetBySubString_SubStringIsNull_ThrowsInvalidOperationException()
        {
            // Arrange
            string SubStr = null;

            // Act
            async Task Act() => await _Repository.GetBySubString(SubStr);

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(Act);
        }

        [Fact]
        public async Task GetBySubString_SubStringIsWhitespace_ThrowsIinvalidOperationException()
        {
            // Arrange
            string SubStr = " ";

            // Act
            async Task Act() => await _Repository.GetBySubString(SubStr);

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(Act);
        }

        [Fact]
        public async Task GetBySubstring_SubStringIsNullAndNavPropsIsNull_ThrowsInvalidOperationException()
        {
            // Arrange
            string Substr = null;
            List<string> NavProps = null;

            // Act
            async Task Act() => await _Repository.GetBySubString(Substr, NavProps);

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(Act);
        }

        [Fact]
        public async Task GetBySubstring_SubStringIsNullAndNavPropsIsValid_ThrowsInvalidOperationException()
        {
            // Arrange
            string Substr = null;
            List<string> NavProps = [""];

            // Act
            async Task Act() => await _Repository.GetBySubString(Substr, NavProps);

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(Act);
        }

        [Fact]
        public async Task GetBySubstring_SubStringIsWhiteSpaceAndNavPropsIsNull_ThrowsInvalidOperationException()
        {
            // Arrange
            string Substr = "";
            List<string> NavProps = null;

            // Act
            async Task Act() => await _Repository.GetBySubString(Substr, NavProps);

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(Act);
        }

        [Fact]
        public async Task Update_ObjIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            Category Obj = null;

            // Act
            async Task Act() => await _Repository.Update(Obj);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }
    }
}
