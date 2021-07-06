using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreRepository _repo;

        public int PageSize = 4;

        public HomeController(IStoreRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = _repo.Products
                            .OrderBy(p => p.ProductID)
                            .Skip((productPage - 1) * PageSize)
                            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _repo.Products.Count()
                }
            });
    }
}