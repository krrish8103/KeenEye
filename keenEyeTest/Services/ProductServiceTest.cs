using KeenEye.Core.Interfaces;
using KeenEye.Core.Models;
using KeenEye.Services;
using KeenEye.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace keenEyeTest.Services
{
    public class ProductServiceTest
    {
        private readonly Mock<IUnitOfWork> productUOW;

        public ProductServiceTest()
        {
            productUOW = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task GetProductList_ProductListAsync()
        {
            //arrange
            var productList = GetProductsData();
            productUOW.Setup(x => x.Products.GetAll())
                .ReturnsAsync(productList);
            var productService = new ProductService(productUOW.Object);
            //act
            var productResult = await productService.GetAllProducts();
            var result = productResult as IList<ProductDetails>;
            //assert
            Assert.NotNull(result);
            Assert.Equal(GetProductsData().Count(), result?.Count());
        }

        [Fact]
        public async Task GetProductByID_ProductAsync()
        {
            //arrange
            var productList = GetProductsData();
            productUOW.Setup(x => x.Products.GetById(2))
                .ReturnsAsync(productList[1]);
            var productService = new ProductService(productUOW.Object);
            //act
            var productResult = await productService.GetProductById(2);
            var result = productResult as ProductDetails;
            //assert
            Assert.NotNull(result);
            Assert.Equal(productList[1].Id, result.Id);
        }

        [Fact]
        public async Task AddProduct_ProductAsync()
        {
            //arrange
            var productList = GetProductsData();
            productUOW.Setup(x => x.Products.Add(productList[1])).Verifiable();

            var productService = new ProductService(productUOW.Object);
            //act
            var productResult = await productService.CreateProduct(productList[1]);
            //assert
            productUOW.Verify(mock => mock.Products.Add(productList[1]), Times.Once());
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
