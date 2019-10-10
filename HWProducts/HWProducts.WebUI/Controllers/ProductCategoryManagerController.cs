using HWProducts.Core.Model;
using HWProducts.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWProducts.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {     
        ProductCategoryRepository context;

        public ProductCategoryManagerController()
        {
            context = new ProductCategoryRepository();
        }

        // GET: Products
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }


        // CREATE: ProductCategory
        [HttpGet]
        public ActionResult Create()
        {
            ProductCategory productCat = new ProductCategory();
            return View(productCat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategory productCat)
        {
            if (!ModelState.IsValid)
            {
                return View(productCat);
            }
            else
            {
                context.Insert(productCat);
                context.Commit();
                return RedirectToAction("Index");
            }

        }


        // EDIT: ProductCategory
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            ProductCategory productCat = context.Find(Id);
            if (productCat == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCat);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategory productCat, string Id)
        {
            ProductCategory productCatToEdit = context.Find(Id);

            if (productCatToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCat);
                }
                
                productCatToEdit.Category = productCat.Category;              
                context.Commit();
                return RedirectToAction("Index");
            }
        }


        //DELETE: ProductCategory
        [HttpGet]
        public ActionResult Delete(string Id)
        {
            ProductCategory productCatToDelete = context.Find(Id);
            if (productCatToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCatToDelete);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory productToDelete = context.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

    }
}