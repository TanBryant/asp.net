using WebApp_MVC.Models;

namespace WebApp_MVC.Service
{
    public class NewCategoryService : ICategoryService
    {
        private static List<CategoryResponse> rs;
        static NewCategoryService()
        {
            rs = new List<CategoryResponse>
            {
                new CategoryResponse {Id=1,Name="Samsung"},
                new CategoryResponse {Id=2,Name="Macbook"},
                new CategoryResponse {Id=3,Name="Huawei"},
                new CategoryResponse {Id=4,Name="Lenovo"},
                new CategoryResponse {Id=5,Name="Dell"},
                new CategoryResponse {Id=6,Name="MSI"},
                new CategoryResponse {Id=7,Name="Asus"},
                new CategoryResponse {Id=8,Name="Acer"},
            };
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryResponse Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryResponse> GetList()
        {

            return rs.Take(2).ToList();
        }

       

        public string Insert(CategoryResponse category)
        {
            throw new NotImplementedException();
        }

        public string Update(CategoryResponse category)
        {
            throw new NotImplementedException();
        }
    }
}
