using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MappingSearch.Models.ViewModels.Product;
using MappingSearch.Constants.DatabaseConstants;
using MappingSearch.Models.ViewModels.Tracks;
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
                                       select product.Brand).Distinct().ToList();

                List<string> subcategories = (from product in context.Products
                                              where String.Equals(product.Category, category) && product.Approved
                                              select product.SubCategory).Distinct().ToList();

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
                    VisibleToUser = productInfo.SubmittedBy.Equals(user) || productInfo.Approved,
                    IsAccessory = String.Equals(DatabaseConstants.CategoryConstantStrings[DatabaseConstants.CategoryConstants.ACCESSORIES],productInfo.Category,StringComparison.OrdinalIgnoreCase),
                    IsGear = String.Equals(DatabaseConstants.CategoryConstantStrings[DatabaseConstants.CategoryConstants.GEAR],productInfo.Category,StringComparison.OrdinalIgnoreCase),
                    IsMotorcycle = String.Equals(DatabaseConstants.CategoryConstantStrings[DatabaseConstants.CategoryConstants.MOTORCYCLES],productInfo.Category,StringComparison.OrdinalIgnoreCase)
                };


                if (model.IsMotorcycle) 
                {
                    var motorcycleInfo = (from moto in context.Motorcycles
                                          where moto.ProductId == id
                                          select moto).FirstOrDefault();

                    if (motorcycleInfo != null)
                    {
                        model.Displacement = motorcycleInfo.Displacement != null ? motorcycleInfo.Displacement.ToString() : "0";
                        model.TopSpeed = motorcycleInfo.TopSpeed.HasValue ? motorcycleInfo.TopSpeed.Value : 0;
                        model.Torque = motorcycleInfo.Torque.HasValue ? motorcycleInfo.Torque.Value : 0;
                        model.Gears = motorcycleInfo.Gears.HasValue ? motorcycleInfo.Gears.Value : 0;
                    }

                }

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

        public static List<string> GetAllBrands(string category)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                return (from product in context.Products
                             where product.Approved && product.Category.Equals(category)
                             select product.Brand).Distinct().ToList();

             
            }
        }

        public static int AddNewMotorcycle( Motorcycle dbMotorcycle)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                context.Motorcycles.InsertOnSubmit(dbMotorcycle); //.InsertAllOnSubmit(dbUserModel);
                context.SubmitChanges();

                return dbMotorcycle.MotorcycleId;
            }
        }

        public static List<ProductViewModel> AllUnapprovedGear()
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                List<ProductViewModel> unapprovedGear = (from product in context.Products
                                                         where !product.Approved &&
                                                         product.Category.Equals(Constants.DatabaseConstants.DatabaseConstants.CategoryConstantStrings[Constants.DatabaseConstants.DatabaseConstants.CategoryConstants.GEAR])
                                                         select new ProductViewModel
                                                        {
                                                            ProductBrand = product.Brand,
                                                            ProductDescription = product.Description,
                                                            ProductImage = product.Image,
                                                            ProductTitle = product.Title,
                                                            ProductId = product.ProductId,
                                                            SubmittedBy = product.SubmittedBy,
                                                            Subcategory = product.SubCategory,
                                                            SiteUrl = product.SiteUrl,
                                                            IsGear = true
                                                        }).ToList();
            
                return unapprovedGear;
            }
        }
      

        public static List<ProductViewModel> AllUnapprovedMotorcycles()
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                List<ProductViewModel> unapprovedMotorcycles
                    = (from product in context.Products
                       join motor in context.Motorcycles on product.ProductId equals motor.ProductId
                       where !product.Approved &&
                       product.Category.Equals(Constants.DatabaseConstants.DatabaseConstants.CategoryConstantStrings[Constants.DatabaseConstants.DatabaseConstants.CategoryConstants.MOTORCYCLES])
                       select new ProductViewModel 
                       {
                        ProductBrand = product.Brand,
                        ProductDescription = product.Description,
                        ProductImage = product.Image,
                        ProductTitle = product.Title,
                        ProductId = product.ProductId,
                        IsMotorcycle = true,
                        SubmittedBy = product.SubmittedBy,
                        Subcategory = product.SubCategory,
                        Displacement = motor.Displacement.ToString(),
                        Gears = motor.Gears.Value,
                        TopSpeed = motor.TopSpeed.Value,
                        Torque = motor.Torque.Value,
                        EngineType = motor.EngineType,
                        SiteUrl = product.SiteUrl
                       }).ToList();


                return unapprovedMotorcycles;
            }
        }
    }
}
