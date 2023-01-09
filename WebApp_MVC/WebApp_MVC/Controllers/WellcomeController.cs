using Microsoft.AspNetCore.Mvc;
using WebApp_MVC.Models;

namespace WebApp_MVC.Controllers
{
    public class WellcomeController : Controller
    {
        public IActionResult Index12()
        {
            return View();
        }
        public IActionResult W(int id,int a, int b, int c )
        {
            int t = a + b + c;
            int idd = id + 1;
            ViewData["t"]=t;
            ViewData["id"] = idd;
            return View();
        }
        public IActionResult Form(int a,int b) {
            int tong = a + b;
            ViewData["a"] = a; 
            ViewData["b"]=b; 
            ViewData["tong"]=tong;
            return View();

        }
        public IActionResult List()
        {
            LopHocViewModel model = new LopHocViewModel
            {
                ListLopHoc = new List<Data.LopHoc>
                {
                    new Data.LopHoc()
                    {
                        Id=1, TenLopHoc="CNTTK18"
                    },

                    new Data.LopHoc()
                    {
                        Id=1, TenLopHoc="CNTTK19"
                    },

                    new Data.LopHoc()
                    {
                        Id=1, TenLopHoc="CNTTK20"
                    },

                    new Data.LopHoc()
                    {
                        Id=1, TenLopHoc="CNTTK21"
                    },
                }
            };
            return View(model);
        }
    }
}
