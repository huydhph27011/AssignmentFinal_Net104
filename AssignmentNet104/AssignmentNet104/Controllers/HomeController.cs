using _1.DAL.Models;
using Assignment.IServices;
using Assignment.Models;
using Assignment.Service;
using AssignmentNet104.Models;
using AssignmentNet104.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AssignmentNet104.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMaterialService _materialService;
        ShopDbContext _dbContext;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _materialService = new MaterialService();
            _dbContext = new ShopDbContext();
        }
        [HttpPost]
        public IActionResult DangKi()
        {
            return View();
        }
        public IActionResult DangKi(Account account)
        {
            account.Id = Guid.NewGuid();
            _dbContext.accounts.Add(account);
            _dbContext.SaveChanges();
            return RedirectToAction("DangNhap");
        }
        
        public IActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangNhap(Account account)
        {
            var user = account.Username;
            var pass = account.Password;
            var checkuser = _dbContext.accounts.SingleOrDefault(x => x.Username.Equals(user) && x.Password.Equals(pass));
            if (checkuser != null)
            {
                return RedirectToAction("Index","Home");
            }
            return BadRequest();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowSanPham()
        {
            List<Material> materials = _materialService.GetAllMaterials();
            return View(materials);
        }
        public IActionResult ShowSanPham5()
        {
            List<Material> materials = _materialService.GetMaterial5s();
            return View(materials);
        }
        public IActionResult CreateSP()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSP(Material m)
        {
            if (_materialService.CreateMaterial(m))
            {
                return RedirectToAction("ShowSanPham");
            }
            return BadRequest();
        }
        public IActionResult DeleteSP(Guid id)
        {
            if (_materialService.DeleteMaterial(id))
            {
                return RedirectToAction("ShowSanPham");
            }
            return BadRequest();
        }
        public IActionResult Details(Guid id)
        {
            var materials = _materialService.GetMaterialById(id);
            return View(materials);
        }
        [HttpGet]
        public IActionResult EditSP(Guid id)
        {
            var materials = _materialService.GetMaterialById(id);
            return View(materials);
        }
        [HttpPost]
        public IActionResult EditSP(Material m)
        {
            if (m.Price <= 1)
            {
                return Content("Giá bịp");
            }
            else if (m.SoLuongTon <= 1)
            {
                return Content("Giá bịp");
            }
            else
            {
                _materialService.UpdateMaterial(m);
                return RedirectToAction("ShowSanPham");
            }
            return BadRequest();
        }
        private int isExist(Guid id)
        {
            List<Material> materials = SessionServices.GetObjFromSession(HttpContext.Session, "Material");
            for (int i = 0; i < materials.Count; i++)
            {
                if (materials[i].IdMaterial.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult AddItem(Guid id)
        {
            var material = _materialService.GetMaterialById(id);
            var materials = SessionServices.GetObjFromSession(HttpContext.Session, "Material");
            if (materials.Count == 0)
            {
                materials.Add(new Material
                {
                    IdMaterial = id,
                    Code = material.Code,
                    Name = material.Name,
                    SoLuong = 1,
                    Price = material.Price,
                });
                SessionServices.SetObjToSession(HttpContext.Session, "Material", materials);
            }
            else
            {
                if (SessionServices.CheckObjList(id, materials))
                {
                    var item = materials.FirstOrDefault(c => c.IdMaterial == id);
                    item.SoLuong++;
                    SessionServices.SetObjToSession(HttpContext.Session, "Material", materials);
                }
                else
                {
                    materials.Add(new Material
                    {
                        IdMaterial = id,
                        Code = material.Code,
                        Name = material.Name,
                        SoLuong = 1,
                        Price = material.Price,
                    }); // Thêm trực tiếp sp vào nếu List chưa chứa sp đó
                    SessionServices.SetObjToSession(HttpContext.Session, "Material", materials);
                }
            }
            return RedirectToAction("ShowCart");
        }
        public IActionResult DeleteCart(Guid id)
        {
            var materials = SessionServices.GetObjFromSession(HttpContext.Session, "Material");
            int index = isExist(id);
            materials.RemoveAt(index);
            SessionServices.SetObjToSession(HttpContext.Session, "Material", materials);
            return RedirectToAction("ShowCart");
        }
        public IActionResult ShowCart()
        {
            //Lấy dữ liệu từ Session để truyền vào View
            var materials = SessionServices.GetObjFromSession(HttpContext.Session, "Material");
            ViewBag.cart = materials;
            ViewBag.total = materials.Sum(c => c.SoLuong * c.Price);
            return View(materials);  // Truyền sang view
        }
        public IActionResult ThanhToan()
        {
            var materials = SessionServices.GetObjFromSession(HttpContext.Session, "Material");
            if (materials.Count == 0)
            {
                return RedirectToAction("ShowSanPham");
            }
            else
            {
                int mats = materials.Count + 1;
                Bill bill = new Bill();
                bill.IdBill = Guid.NewGuid();
                bill.Code = "HD" + mats++;
                bill.Status = 1;
                bill.CreatedDate = DateTime.Now;
                bill.PointsUsed = 1000;
                bill.IdCustomer = Guid.Parse("0b35855f-99ee-46ed-863f-0d760dd226a3");
                bill.IdStaff = Guid.Parse("f349efa1-c2a4-4b98-bed0-0abf04b0f826"); ;
                _dbContext.bills.Add(bill);
                _dbContext.SaveChanges();
                foreach (var x in materials)
                {
                    Material material = new Material();
                    material.IdMaterial = x.IdMaterial;
                    material.SoLuongTon = material.SoLuongTon - x.SoLuong;
                    material.Price = x.Price;
                    material.Code = x.Code;
                    material.Name = x.Name;
                    _dbContext.Materials.Update(material);
                    _dbContext.SaveChanges();
                }

                materials.Clear();
                return RedirectToAction("ShowSanPham");
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}