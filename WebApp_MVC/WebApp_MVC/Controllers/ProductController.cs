using Microsoft.AspNetCore.Mvc;
using WebApp_MVC.Models;
using WebApp_MVC.Service;

namespace WebApp_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _whostingEnvironment;
        //tiêm chích 
        public ProductController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment whostingEnvironment)
        {
            _productService = productService;
              
            _categoryService = categoryService;
            _whostingEnvironment = whostingEnvironment;
        }

        public IActionResult Index()
        {
            var model = new ProductViewModel();
            model.Categories=_categoryService.GetList();
            model.Products = _productService.GetList();
            return View(model);
        }

        public IActionResult LoadProduct(int id)
        {
            var model = new ProductViewModel();
            model.Categories = _categoryService.GetList();
            model.Products = _productService.GetListByCatId(id);

            return PartialView("listProduct", model);

        }
        public IActionResult Delete(ProductViewModel viewModel)
        {
            _productService.Delete(viewModel.ProductRequest.Id);
			return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel viewModel)
        {
            if (viewModel.ProductRequest.Avatar != null)
            {
                var fileName = Guid.NewGuid().ToString() + ".png";
                var path = Path.Combine(_whostingEnvironment.WebRootPath, "avatar", fileName);
                var stream = System.IO.File.Create(path);
                viewModel.ProductRequest.Avatar.CopyTo(stream);
                stream.Close();

                viewModel.ProductRequest.AvatarURL = Path.Combine("avatar", fileName);

            }
           _productService.Create(viewModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel viewModel)
        {
            if (viewModel.ProductRequest.Avatar != null)
            {
                var fileName = Guid.NewGuid().ToString() + ".png";
                var path = Path.Combine(_whostingEnvironment.WebRootPath, "avatar", fileName);
                var stream = System.IO.File.Create(path);
                viewModel.ProductRequest.Avatar.CopyTo(stream);
                stream.Close();

                viewModel.ProductRequest.AvatarURL = Path.Combine("avatar", fileName);

            }
            _productService.Update(viewModel);
            return RedirectToAction("Index");
        }

       
         
    }
}
