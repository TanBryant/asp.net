namespace WebApp_MVC.Models
{
    public class ProductViewModel
    {
        public List<ProductResponse> Products { get; set; }
        //sseerver lấy xuống
        public ProductRequest ProductRequest { get; set; }
        // đây dữ liệu lên serveeer
        public List<CategoryResponse> Categories { get; set; }
		public CategoryResponse ProductResponse { get; internal set; }
	}
}
