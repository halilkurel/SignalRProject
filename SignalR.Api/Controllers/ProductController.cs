using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BussinessLayer.Abstract;
using SignalR.DataAccessLayer.Concreate;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var value = _mapper.Map<List<ProductListDto>>(_productService.TGetAll());
            return Ok(value);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }

        [HttpGet("ProductNameMaxPrice")]
        public IActionResult ProductNameMaxPrice()
        {
            return Ok(_productService.TProductNamebyMaxPrice());
        }

        [HttpGet("ProductPriceAvgHamburger")]
        public IActionResult ProductPriceAvgHamburger()
        {
            return Ok(_productService.TProductPriceAvgHamburger());
        }

        [HttpGet("ProductNameMinPrice")]
        public IActionResult ProductNameMinPrice()
        {
            return Ok(_productService.TProductNamebyMinPrice());
        }


        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_productService.TProductPriceAvg());
        }

        [HttpGet("ProductCountbyHamburger")]
        public IActionResult ProductCountbyHamburger()
        {
            return Ok(_productService.TProductCountbyCategoryNameHamburger());
        }

        [HttpGet("ProductCountbyDrink")]
        public IActionResult ProductCountbyDrink()
        {
            return Ok(_productService.TProductCountbyCategoryNameDrink());
        }


        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            // Bu işlem Dependency'e göre Data katmanında olmalı oraya taşınması gerekli
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                Descripton = y.Descripton,
                CategoryName = y.Category.CategoryName,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,
                ProductId = y.ProductId
            });
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductCreateDto Product)
        {
            _productService.TAdd(_mapper.Map<Product>(Product));
            return Ok("Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(ProductUpdateDto Product)
        {
            _productService.TUpdate(_mapper.Map<Product>(Product));
            return Ok("Güncellendi");
        }
    }
}
