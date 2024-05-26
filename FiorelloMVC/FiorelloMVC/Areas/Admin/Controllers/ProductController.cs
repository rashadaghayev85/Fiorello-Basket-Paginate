using FiorelloMVC.Helpers;
using FiorelloMVC.Models;
using FiorelloMVC.Services.Interfaces;
using FiorelloMVC.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloMVC.Areas.Admin.Controllers
{
        [Area("admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var products = await _productService.GetAllPaginateAsync(page, 4);

            var mappedDatas = _productService.GetMappedDatas(products);
            int totalPage = await GetPageCountAsync(4);

            Paginate<ProductVM> paginateDatas = new(mappedDatas, totalPage, page);

            return View(paginateDatas);
        }

        private async Task<int> GetPageCountAsync(int take)
        {
            int productCount = await _productService.GetCountAsync();

            return (int)Math.Ceiling((decimal)productCount / take);
        }
    }
}
