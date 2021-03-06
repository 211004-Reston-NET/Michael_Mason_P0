using System;
using Xunit;
using Data;

namespace UnitTest
{
    public class StorefrontValidation
    {
        Storefront testStorefront = new Storefront();
        [Fact]
        public void StoreNameIsValid()
        {
            var name = "Joe's Boot Emporium";
            testStorefront.StoreName = name;
            Assert.NotNull(testStorefront.StoreName);
            Assert.Equal(testStorefront.StoreName, name);
        }

        [Theory]
        [InlineData("Joe's b@@t emporium")]
        [InlineData("Joe's Boot% emporium")]
        [InlineData(null)]
        public void StoreNameThrowsExceptionOnInvalid(string input)
        {
            Assert.Throws<Exception>(() => testStorefront.StoreName = input);
        }

        [Fact]
        public void StoreAddressIsValid()
        {
            var address = "123 Test Way, Test AL, 00000-0000";
            testStorefront.StoreAddress = address;
            Assert.NotNull(testStorefront.StoreAddress);
            Assert.Equal(testStorefront.StoreAddress, address);
        }

        [Theory]
        [InlineData("@()&&!")]
        [InlineData(":}{|:?")]
        [InlineData(null)]
        public void StoreAddressThrowsExceptionOnInvalid(string input)
        {
            Assert.Throws<Exception>(() => testStorefront.StoreAddress = input);
        }
    }
}