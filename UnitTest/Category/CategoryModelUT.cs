using System;
using Xunit;
using Models;

namespace UnitTest
{
    public class CategoryModelUT
    {
        [Fact]
        public void CategoryNameSetValidData()
        {
            CategoryModel _catModTest = new CategoryModel();
            string name = "Toys";
            _catModTest.CatName = name;

            Assert.NotNull(_catModTest.CatName);
            Assert.Equal(_catModTest.CatName, name);
        }

        [Theory]
        [InlineData("")]
        [InlineData("1234567890123456789012345678901234567890123456789012")]
        public void CategoryNameIsValid(string p_input)
        {
            CategoryModel _catModTest = new CategoryModel();
            Assert.Throws<Exception>(() => _catModTest.CatName = p_input);
        }
    }
}
