using Microsoft.EntityFrameworkCore;
using WebApp_MVC.Data;
using WebApp_MVC.Models;

namespace WebApp_MVC.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _db;
        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<CategoryResponse> GetList()
        {

            var rs = _db.Categories.Select(e => new CategoryResponse
            {
                Id= e.Id,
                Name= e.Name
            }).ToList();
            return rs;
        }
        public CategoryResponse Get(int id)
        {
            var rs = _db.Categories.Where(e=> e.Id == id).Select(e=> new CategoryResponse
            {
                Id= e.Id,
                Name= e.Name
            }).FirstOrDefault();
            return rs;
        }
        public void Delete(int id)
        {
           var rs = _db.Categories.Where(e=>e.Id == id).FirstOrDefault();
            if (rs != null)
            {
                _db.Categories.Remove(rs);
                _db.SaveChanges();
            }
             
        }
        public string Insert(CategoryResponse category) 
        {
             var obj = new Category 
             {
                 Name= category.Name,
             };
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return string.Empty;
        }

        public string Update(CategoryResponse category) 
        { 
            var obj=  _db.Categories.Where(e=>e.Id==category.Id).FirstOrDefault();
            if(obj != null)
            {
                obj.Name= category.Name;
                _db.SaveChanges();
                return string.Empty;
            }
            else
            {
                return "Không tìm thấy đối tượng !! ";
            }
        }
    }
}
