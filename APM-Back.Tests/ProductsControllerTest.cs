using APM_Back.Controllers;
using APM_Back.Data;
using APM_Back.Models;
using APM_Back.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace APM_Back.Tests.Controllers
{
    public class ProductsControllerTest
    {
        private readonly Mock<IProductService> _mockRepo;
        private readonly Mock<IUriService> _mockUri;
        private readonly Mock<PaginationFilter> _paginationFilter;
        private readonly ProductsController _controller;
        public ProductsControllerTest()
        {
            var httpContext = new DefaultHttpContext();

            _mockRepo = new Mock<IProductService>();
            _mockUri = new Mock<IUriService>();
            _paginationFilter = new Mock<PaginationFilter>();
            _controller = new ProductsController(_mockRepo.Object, _mockUri.Object);

            _controller.ControllerContext = new ControllerContext() { HttpContext = new DefaultHttpContext() };
        }

        //This was just for testing
        [Fact]
        public async void GetAll_Executions_Type()
        {
            _mockRepo.Setup(repo => repo.GetAll(_paginationFilter.Object))
                .ReturnsAsync(new PagedData(new List<Product>() { new Product(), new Product() }, 2));

            var response = await _controller.GetProducts(_paginationFilter.Object);
            Assert.IsType<OkObjectResult>(response);
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void GetAll_Executes_ReturnsExactNumberOfProducts()
        {
            _mockRepo.Setup(repo => repo.GetAll(_paginationFilter.Object))
                .ReturnsAsync(new PagedData(new List<Product>() { new Product(), new Product() } , 2));

            var response = await _controller.GetProducts(_paginationFilter.Object);

            var okResult = response as OkObjectResult;
            var config = okResult.Value as PagedResponse<IEnumerable<Product>>;
            Assert.Equal(2, config.Data.Count());
        }
    }
}
