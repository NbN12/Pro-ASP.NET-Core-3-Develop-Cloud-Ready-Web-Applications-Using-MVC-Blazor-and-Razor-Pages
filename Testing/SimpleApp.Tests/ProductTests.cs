using SimpleApp.Models;
using Xunit;

namespace SimpleApp.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            //Given
            var p = new Product { Name = "Test", Price = 100M };

            //When
            p.Name = "New Name";

            //Then
            Assert.Equal("New Name", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            //Given
            var p = new Product { Name = "Test", Price = 100M };

            //When
            p.Price = 200M;

            //Then
            Assert.Equal(200M, p.Price);
        }
    }
}