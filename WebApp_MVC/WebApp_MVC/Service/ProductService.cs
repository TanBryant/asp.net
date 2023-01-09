using Microsoft.AspNetCore.Mvc;
using WebApp_MVC.Data;
using WebApp_MVC.Models;

namespace WebApp_MVC.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<ProductResponse> GetList()
        {
            var rs = _db.Products.Select(e => new ProductResponse
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Price = e.Price,
                DateCreated = e.DateCreate,
                CategoryId = e.CategoryId,
				CategoryName = e.Category.Name,
                AvatarUrl = e.AvatarUrl4,
            }).ToList();
            return rs;
        }
        [HttpPost]
        public void Create(ProductViewModel viewModel)
        {
            var product = new Product
            {
                Name = viewModel.ProductRequest.Name,
                Description = viewModel.ProductRequest.Description,
                Price = viewModel.ProductRequest.Price,
                CategoryId = viewModel.ProductRequest.CategoryId,
                DateCreate = DateTime.Now,
                AvatarUrl4 = viewModel.ProductRequest.AvatarURL,
            };
            _db.Products.Add(product);
            _db.SaveChanges();
        }
        [HttpPost]
        public void Delete(int id)
        {
            var obj = _db.Products.Where(e=>e.Id == id).FirstOrDefault();
            if (obj != null)
            {
                _db.Products.Remove(obj);
                _db.SaveChanges();
            }
        }
        [HttpPost]
        public void Update(ProductViewModel viewModel)
        {
            
        }

        public List<ProductResponse> GetListByCatId(int id)
        {
            var rs = _db.Products.Where(e => e.CategoryId == id).Select(e => new ProductResponse
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Price = e.Price,
                DateCreated = e.DateCreate,
                CategoryId = e.CategoryId,
                CategoryName = e.Category.Name,
                AvatarUrl = e.AvatarUrl4,
            }).ToList();
            return rs;
        }
    }
}
