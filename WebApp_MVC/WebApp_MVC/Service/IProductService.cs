using WebApp_MVC.Models;

namespace WebApp_MVC.Service
{
    public interface IProductService
    {
        List<ProductResponse> GetList();
        List<ProductResponse> GetListByCatId(int id);

        void Create(ProductViewModel viewModel);
        void Update(ProductViewModel viewModel);
        void Delete(int id);
    }
}