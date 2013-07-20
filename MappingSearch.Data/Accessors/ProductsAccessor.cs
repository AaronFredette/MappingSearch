using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingSearch.Data.Accessors
{
    public static class ProductsAccessor
    {
        public static List<Product> GetAllBrandsAndTypesForCategory(string category)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                ///Make new linq to sql class for producs 
                List<Product> products = (from product in context.Products
                               where String.Equals(product.Category,category)
                               select product).ToList();

                return products;
            }
        }

        public static Models.ViewModels.Product.ProductFacetModel GetAllFacetsForCategory(string category)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                ///Make new linq to sql class for producs 
                List<string> brands = (from product in context.Products
                                          where String.Equals(product.Category, category)
                                          select product.Brand).ToList();

                List<string> subcategories = (from product in context.Products
                                              where String.Equals(product.Category, category)
                                              select product.SubCategory).ToList();

                brands.Sort();
                subcategories.Sort();
                return new Models.ViewModels.Product.ProductFacetModel { Subcategories =subcategories.Distinct().ToList(), Brands = brands.Distinct().ToList()};
            }
        }

        public static List<Product> GetFilteredProducts(string category, string brand, string subcategory)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                List<Product> products = (from product in context.Products
                                          where String.Equals(product.Category.ToLower(), category.ToLower()) 
                                          && (String.IsNullOrEmpty(brand) || String.Equals(brand.ToLower(),product.Brand.ToLower()))
                                          && (String.IsNullOrEmpty(subcategory) || string.Equals(subcategory, product.SubCategory.ToLower()))
                                          select product).OrderBy(x=>x.Brand).OrderBy(x=> x.Title).ToList();


                return products;
            }
        }
    }
}
