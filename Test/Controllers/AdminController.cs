using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using Test.Repository;

namespace Test.Controllers
{
    public class AdminController : Controller
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Category>().GetAll();
            foreach(var item in cat)
            {
                list.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryName });
            }
            return list;
        }
        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }

        [Authorize]
        public ActionResult Categories()
        {
            List<Category> categories = _unitOfWork.GetRepositoryInstance<Category>().GetAll().ToList();
            return View(categories);
        }

        [Authorize]
        public ActionResult AddCategory()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            _unitOfWork.GetRepositoryInstance<Category>().Add(category);
            return RedirectToAction("Categories");
        }

        [Authorize]
        public ActionResult UpdateCategory(int categoryId)
        {         
            return View(_unitOfWork.GetRepositoryInstance<Category>().Get(categoryId));
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            _unitOfWork.GetRepositoryInstance<Category>().Update(category);
            return RedirectToAction("Categories");
        }

        [Authorize]
        public ActionResult Products()
        {
            return View(_unitOfWork.GetRepositoryInstance<Product>().GetAll().ToList());
        }

        [Authorize]
        public ActionResult UpdateProduct(int productId)
        {
            return View(_unitOfWork.GetRepositoryInstance<Product>().Get(productId));
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            _unitOfWork.GetRepositoryInstance<Product>().Update(product);
            return RedirectToAction("Products");
        }

        [Authorize]
        public ActionResult AddProduct()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            _unitOfWork.GetRepositoryInstance<Product>().Add(product);
            return RedirectToAction("Products");
        }

        [Authorize]
        public ActionResult DeleteProduct(int productId)
        {
            return View(_unitOfWork.GetRepositoryInstance<Product>().Get(productId));
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteProduct(Product product)
        {
            _unitOfWork.GetRepositoryInstance<Product>().Delete(product);
            return RedirectToAction("Products");
        }

        [Authorize]
        public ActionResult DeleteCategory(int categoryId)
        {
            return View(_unitOfWork.GetRepositoryInstance<Product>().Get(categoryId));
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteCategory(Category category)
        {
            _unitOfWork.GetRepositoryInstance<Category>().Delete(category);
            return RedirectToAction("Categories");
        }
    }
}