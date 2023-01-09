using WebApp_MVC.Models;

namespace WebApp_MVC.Service
{
    public interface ICategoryService
    {
        void Delete(int id);
        CategoryResponse Get(int id);
        List<CategoryResponse> GetList();
        string Insert(CategoryResponse category);
        string Update(CategoryResponse category);
    }
}