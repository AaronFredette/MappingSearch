using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MappingSearch.Models.ViewModels.Product;
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
                                          where String.Equals(product.Category, category) && product.Approved
                                          select product).ToList();

                return products;
            }
        }

        public static Models.ViewModels.Product.CategoryAndBrandModel GetAllFacetsForCategory(string category)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                ///Make new linq to sql class for producs 
                List<string> brands = (from product in context.Products
                                       where String.Equals(product.Category, category)
                                       select product.Brand).ToList();

                List<string> subcategories = (from product in context.Products
                                              where String.Equals(product.Category, category) && product.Approved
                                              select product.SubCategory).ToList();

                brands.Sort();
                subcategories.Sort();
                return new Models.ViewModels.Product.CategoryAndBrandModel { Subcategories = subcategories.Distinct(StringComparer.CurrentCultureIgnoreCase).ToList(), Brands = brands.Distinct(StringComparer.CurrentCultureIgnoreCase).ToList() };
            }
        }

        public static List<Product> GetFilteredProducts(string category, string brand, string subcategory)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                List<Product> products = (from product in context.Products
                                          where product.Approved && String.Equals(product.Category.ToLower(), category.ToLower())
                                          && (String.IsNullOrEmpty(brand) || String.Equals(brand.ToLower(), product.Brand.ToLower()))
                                          && (String.IsNullOrEmpty(subcategory) || string.Equals(subcategory, product.SubCategory.ToLower()))
                                          select product).OrderBy(x => x.Brand).OrderBy(x => x.Title).ToList();


                return products;
            }
        }

        public static ProductViewModel GetProductInfo(int id, string user)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                var productInfo = (from product in context.Products
                                   where product.ProductId == id
                                   select product).FirstOrDefault();
                ProductViewModel model = new ProductViewModel
                {
                    ProductTitle = productInfo.Title,
                    ProductImage = productInfo.Image,
                    ProductId = productInfo.ProductId,
                    ProductBrand = productInfo.Brand,
                    ProductDescription = productInfo.Description,
                    SubmittedBy = productInfo.SubmittedBy,
                    IsApproved = productInfo.Approved,
                    VisibleToUser = productInfo.SubmittedBy.Equals(user) || productInfo.Approved
                };

                return model;
            }
        }

        public static int AddNewGearProduct(Product dbProduct)
        {

            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                context.Products.InsertOnSubmit(dbProduct); //.InsertAllOnSubmit(dbUserModel);
                context.SubmitChanges();

                return dbProduct.ProductId;
            }
        }

        public static int DuplicateProductExists(Product dbProduct)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                Product p = (from product in context.Products
                            where IsDuplicate(product, dbProduct) && product.Approved
                            select product).FirstOrDefault();

                if (p == null)
                {
                    return -99;// no duplicat found feel free to insert
                }
                return p.ProductId; // duplicate found make suggestion to user.... allow them to ignore notification
            }
        }

        private static bool IsDuplicate(Product p, Product dbProduct)
        {
            if (p.Title.Equals(dbProduct.Title, StringComparison.OrdinalIgnoreCase) && p.Brand.Equals(dbProduct.Brand, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        public static List<string> GetAllBrands()
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                return (from product in context.Products
                             where product.Approved
                             select product.Brand).ToList();

             
            }
        }
    }
}
