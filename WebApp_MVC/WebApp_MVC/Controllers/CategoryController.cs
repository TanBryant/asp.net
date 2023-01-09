using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp_MVC.Models;
using WebApp_MVC.Service;

namespace WebApp_MVC.Controllers
{
    [Authorize]
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;
		 

		public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            
        }
        public IActionResult Index()
		{
			 
			//var service = new CategoryService();
			var model = new CategoryViewModel();
			model.Responses = _categoryService.GetList();
			return View(model);
		}
		[HttpGet]
        public IActionResult Delete(int id)
		{
           // var service = new CategoryService();
            var model = new CategoryViewModel();
			model.CategoryResponse = _categoryService.Get(id);
            return View(model);
		}
		[HttpPost]
        public IActionResult Delete(CategoryViewModel model)
		{
           // var service = new CategoryService();
			_categoryService.Delete(model.CategoryResponse.Id);
			var rs = _categoryService.GetList();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Insert()
		{
			return View();
		}
        [HttpPost]
        public IActionResult Insert(CategoryViewModel model)
        {
            var rs = _categoryService.Insert(model.CategoryResponse);

            if (string.IsNullOrEmpty(rs))
                return RedirectToAction("Index");
            else
            {
                ViewBag.message = rs;
                return View();
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = new CategoryViewModel();
            model.CategoryResponse = _categoryService.Get(id);
            return View(model);
        }

		[HttpPost]
        public IActionResult Update(CategoryViewModel model)
        {
			var rs = _categoryService.Update(model.CategoryResponse);
            if (string.IsNullOrEmpty(rs)) 
            {
                return RedirectToAction("Index");   
            }
            else
            {
               // model.CategoryResponse= _categoryService.Get(model.CategoryResponse.Id); 
               // ViewBag.message = rs;
                return View();
            }
            return View(model);
        }
    }
}
