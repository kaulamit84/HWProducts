using HWProducts.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace HWProducts.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {

        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;

            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }


        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory pCat)
        {
            productCategories.Add(pCat);
        }

        public void Update(ProductCategory productCategory)
        {
            ProductCategory productToUpdate =
                productCategories.Find(p => p.Id == productCategory.Id);

            if (productToUpdate != null)
            {
                productToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }

        //Product Category Repository find
        public ProductCategory Find(string Id)
        {
            ProductCategory productCat = productCategories.Find(p => p.Id == Id);

            if (productCat != null)
            {
                return productCat;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }


        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }


        public void Delete(string Id)
        {
            ProductCategory productToDelete =
                productCategories.Find(p => p.Id == Id);

            if (productToDelete != null)
            {
                productCategories.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
