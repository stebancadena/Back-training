using APM_Back.Controllers;
using APM_Back.Data;
using APM_Back.Models;
using APM_Back.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace APM_Back.Tests.Controllers
{
    public class ProductsControllerTest
    {
        private readonly Mock<IProductService> _mockRepo;
        private readonly ProductsController _controller;
        public ProductsControllerTest()
        {
            _mockRepo = new Mock<IProductService>();
            _controller = new ProductsController(_mockRepo.Object);
        }

        //This was just for testing
        [Fact]
        public async void GetAll_Executions_Type()
        {
            var response = await _controller.GetProducts();
            Assert.IsType<OkObjectResult>(response);
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void GetAll_Executes_ReturnsExactNumberOfProducts()
        {
            _mockRepo.Setup(repo => repo.GetAll())
                .ReturnsAsync(new List<Product>() { new Product(), new Product() });

            var response = await _controller.GetProducts();

            var okResult = response as OkObjectResult;
            var config = okResult.Value as List<Product>;
            Assert.Equal(2, config.Count);
        }
    }
}
