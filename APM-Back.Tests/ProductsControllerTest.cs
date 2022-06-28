using APM_Back.Controllers;
using APM_Back.Data;
using APM_Back.Models;
using APM_Back.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
        private readonly Mock<IProductService> _mockProductService;
        private readonly ProductsController _controller;
        private readonly Mock<PaginationFilter> _paginationFilter;
        private readonly Mock<string> _route;

        public ProductsControllerTest()
        {
            var httpContext = new DefaultHttpContext();

            _mockProductService = new Mock<IProductService>();
            
            _controller = new ProductsController(_mockProductService.Object);
            _controller.ControllerContext = new ControllerContext() { HttpContext = new DefaultHttpContext() };
        }

        //This was just for testing
        [Fact]
        public async void GetAll_Executions_Type()
        {
            //Arrange
            var filter = new PaginationFilter();
            var route = _controller.Request.Path.Value;

            var data = new List<Product>()
            {
                new Product(), new Product(), new Product()
            };

            var servResponse = new PagedResponse<IEnumerable<Product>>(data,filter.PageSize,filter.PageNumber);


            _mockProductService.Setup(serv => serv.GetAll(filter, route)).ReturnsAsync(servResponse);

            //Act
            var response = await _controller.GetProducts(filter);

            //Assert
            Assert.IsType<OkObjectResult>(response);
        }

        //-------------------------------------------Post-------------------------------------------

        [Fact]
        public async void GetAll_Executes_ReturnsExactNumberOfProducts()
        {
            //Arrange
            var filter = new PaginationFilter();
            var route = _controller.Request.Path.Value;

            var data = new List<Product>()
            {
                new Product(), new Product(), new Product()
            };

            var servResponse = new PagedResponse<IEnumerable<Product>>(data, filter.PageSize, filter.PageNumber);


            _mockProductService.Setup(serv => serv.GetAll(filter, route)).ReturnsAsync(servResponse);

            //Act
            var response = await _controller.GetProducts(filter);


            //Assert
            var okResult = response as OkObjectResult;
            var config = okResult.Value as PagedResponse<IEnumerable<Product>>;
            Assert.Equal(3, config.Data.Count());
        }

        //[Fact]
        //public async void getById_ReturnsNoFound()
        //{
        //    //Arrange
        //    _controller.ModelState.AddModelError("Model error", "Invalid model input, not a product");
        //    var product = new Product { ProductId = new Guid(), ProductName = "Steban" };

        //    _mockProductService.Setup(serv => serv.GetBy(new Guid())).ReturnsAsync( (Product) null);

        //    //Act
        //    var response = await _controller.GetProduct(new Guid());
        //    var result = response;
        //    //Assert
        //    Assert.IsType<NotFoundObjectResult>(response);
        //}

        [Fact]
        public async void AddProduct_Returns_Succesful()
        {
            //Arrange
            var product = new Product { ProductId = new Guid(), ProductName = "Steban" };
            _mockProductService.Setup(serv => serv.Create(It.IsAny<Product>())).Returns(Task.FromResult(new Product()));

            //Act
            var result = await _controller.PostProduct(product);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(201, (result as IStatusCodeActionResult).StatusCode);
        }

        //-------------------------------------------Delete-------------------------------------------
        [Fact]
        public async void DeleteProduct_Returns_Succesful()
        {
            //Arrange
            var product = new Product { ProductId = new Guid(), ProductName = "Steban" };
            _mockProductService.Setup(serv => serv.Delete(It.IsAny<Guid>())).Returns(Task.FromResult(new Product()));

            //Act
            var result = await _controller.DeleteProduct(product.ProductId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, (result as IStatusCodeActionResult).StatusCode);
        }

        [Fact]
        public async void DeleteProduct_Returns_NotFound()
        {
            //Arrange
            var productId = new Guid();
            _mockProductService.Setup(serv => serv.Delete(productId)).Throws(new Exception());

            //Act
            var result = await _controller.DeleteProduct(productId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(404, (result as IStatusCodeActionResult).StatusCode);
        }
    }
}
