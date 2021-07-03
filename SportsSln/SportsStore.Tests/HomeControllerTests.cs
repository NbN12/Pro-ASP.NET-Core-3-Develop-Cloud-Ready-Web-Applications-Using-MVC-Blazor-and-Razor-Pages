using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Can_Use_Repository()
        {
            // Arrange
            var mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"}
            }).AsQueryable<Product>);

            HomeController homeController = new HomeController(mock.Object);

            // Act
            var result = (homeController.Index() as ViewResult).Model as IEnumerable<Product>;

            // Assert
            var products = result.ToArray();
            Assert.True(products.Length == 2);
            Assert.Equal("P1", products[0].Name);
            Assert.Equal("P2", products[1].Name);
        }

        [Fact]
        public void Can_Paginate()
        {
            //Given
            var mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            }).AsQueryable<Product>());

            var homeController = new HomeController(mock.Object);
            homeController.PageSize = 3;

            //When
            var result = (homeController.Index(2) as ViewResult).ViewData.Model as IEnumerable<Product>;

            //Then
            var prodArray = result.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }
    }
}
