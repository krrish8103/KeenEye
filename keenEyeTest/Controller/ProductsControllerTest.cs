using KeenEye.Controllers;
using KeenEye.Core.Models;
using KeenEye.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace keenEyeTest.Controller
{
    public class ProductsControllerTest
    {
        private readonly Mock<IProductService> productService;

        public ProductsControllerTest()
        {
            productService = new Mock<IProductService>();
        }

        [Fact]
        public async Task GetProductList_ProductListAsync()
        {
            //arrange
            var productList = GetProductsData();
            productService.Setup(x => x.GetAllProducts())
                .ReturnsAsync(productList);
            var productController = new ProductsController(productService.Object);
            //act
            var productResult = await productController.GetProductList();
            var result = (productResult as OkObjectResult).Value as IList<ProductDetails>;
            //assert
            Assert.NotNull(result);
            Assert.Equal(GetProductsData().Count(), result.Count());
        }

        [Fact]
        public async Task GetProductByID_ProductAsync()
        {
            //arrange
            var productList = GetProductsData();
            productService.Setup(x => x.GetProductById(2))
                .ReturnsAsync(productList[1]);
            var productController = new ProductsController(productService.Object);
            //act
            var productResult = await productController.GetProductById(2);
            var result = ((productResult as OkObjectResult).Value) as ProductDetails;
            //assert
            Assert.NotNull(result);
            Assert.Equal(productList[1].Id, result.Id);
            Assert.True(productList[1].Id == result.Id);
        }

        [Fact]
        public async Task AddProduct_ProductAsync()
        {
            //arrange
            var productList = GetProductsData();
            productService.Setup(x => x.CreateProduct(productList[2]))
                .ReturnsAsync(true);
            var productController = new ProductsController(productService.Object);
            //act
            var productResult = await productController.CreateProduct(productList[2]);
            var result = ((productResult as OkObjectResult).Value);
            //assert
            Assert.NotNull(result);
            Assert.True((bool)result);
        }

        private List<ProductDetails> GetProductsData()
        {
            List<ProductDetails> productsData = new List<ProductDetails>
            {
                new ProductDetails
                {
                    Id = 1,
                    Category = "Mobile",
                    ProductCode = "P10",
                    ProductName = "IPhone12",
                    ProductPrice = 55000,
                    MinimumQuantity = 2,
                    DiscountRate = 10,
                    ImageIdentifier = ""
                },
                 new ProductDetails
                {
                    Id = 2,
                    Category = "Mobile",
                    ProductCode = "P11",
                    ProductName = "IPhone13",
                    ProductPrice = 65000,
                    MinimumQuantity = 2,
                    DiscountRate = 10,
                    ImageIdentifier = ""
                },
                 new ProductDetails
                {
                    Id = 1,
                    Category = "Mobile",
                    ProductCode = "P12",
                    ProductName = "IPhone14",
                    ProductPrice = 75000,
                    MinimumQuantity = 2,
                    DiscountRate = 10,
                    ImageIdentifier = ""
                },
            };
            return productsData;
        }
    }
}
