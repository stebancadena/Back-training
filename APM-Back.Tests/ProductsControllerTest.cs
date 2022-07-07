using APM_Back.ActionFilters;
using APM_Back.Controllers;
using APM_Back.Models;
using APM_Back.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace APM_Back.Tests.Controllers
{
    public class ProductsControllerTest
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly ProductsController _controller;
        private readonly Mock<DataContext> _mockDataContext;

        public ProductsControllerTest()
        {
            var httpContext = new DefaultHttpContext();

            _mockProductService = new Mock<IProductService>();
            _mockDataContext = new Mock<DataContext>();
            
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


        //-------------------------------------------Action Filter-------------------------------------------
        [Fact]
        public async void ActionFilter_Returns_BadRequest()
        {
            //Arrange
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("", "error");
            var httpContext = new DefaultHttpContext();

            var actContext = new ActionContext(
                httpContext,
                routeData: new RouteData(),
                actionDescriptor: new ActionDescriptor(),
                modelState: modelState
                );

            var context = new ActionExecutingContext(
                actContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                _controller
                );

            var sut = new ValidateEntityExistsClass<Product>(_mockDataContext.Object);
            
            //Action
            sut.OnActionExecuting(context);

            //Assert
            Assert.IsType<BadRequestObjectResult>(context.Result);
        }

        [Fact]
        public async void ActionFilter_Returns_NotFound()
        {
            //Arrange
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("", "error");
            var httpContext = new DefaultHttpContext();

            var actContext = new ActionContext(
                httpContext,
                routeData: new RouteData(),
                actionDescriptor: new ActionDescriptor(),
                modelState: modelState
                );
            //TODO = Mock the dbcontext
            var context = new ActionExecutingContext(
                actContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                _controller
                );
            context.ActionArguments["id"] = new Guid();

            var sut = new ValidateEntityExistsClass<Product>(_mockDataContext.Object);

            //Action
            sut.OnActionExecuting(context);

            //Assert
            Assert.IsType<NotFoundResult>(context.Result);
        }
    }
}
