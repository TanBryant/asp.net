using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_MVC.Data
{
	[Table("Category")]
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required] 
		[StringLength(50)]
        //độ dài tối đa là 50 kí tự và khong dc phep null

        public string Name { get; set; }
		public virtual List<Product>Products { get; set; }
	}
}
