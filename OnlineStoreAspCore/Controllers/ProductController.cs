using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.DTO_ViewModels;
using OnlineStore.Data.Service;
using System.Collections.Generic;

namespace OnlineStoreAspCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IMuscleLoadService  muscleLoadService;

        public ProductController(IProductService productService, IMuscleLoadService muscleLoadService)
        {
            this.productService = productService;
            this.muscleLoadService = muscleLoadService;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View("ProductIndex", muscleLoadService.GetAllMuscleLoad());
        }

        public ActionResult GetList()
        {

            List<ProductViewDTO> productList = productService.GetAllActiveProducts();
            return Json(new { data = productList });
        }

        [HttpPost]
        public ActionResult GetListCategorized(List<int> muscleLoadIds)
        {
            var productList = productService.GetActiveProductCategorized(muscleLoadIds);
            return Json(new { data = productList });
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ProductDetailsDTO productDetailsDTO = productService.GetProductDetailsById(id);
            if (productDetailsDTO == null)
            {
                return NotFound();
            }
            return View("ProductDetails", productDetailsDTO);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
