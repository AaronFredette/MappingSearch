using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MappingSearch.Models.Product;
using MappingSearch.Data;

namespace MappingSearch.Classes.Product
{
    public class ProductAddHelper
    {
        public static int AddGearProduct(NewGearModel model)
        { 
            //Clean inputs 
            Data.Product dbProduct = ConvertNewGearToDbProduct(model);
            //int duplicateid = MappingSearch.Data.Accessors.ProductsAccessor.DuplicateProductExists(dbProduct);
                
            int id = MappingSearch.Data.Accessors.ProductsAccessor.AddNewGearProduct(dbProduct);
            return id;
        }

        private static Data.Product ConvertNewGearToDbProduct(NewGearModel model)
        {
            Data.Product p = new Data.Product();
            
            p.Approved = false;
            p.Brand = model.Brand;
            p.Category = "Gear";
            p.Title = model.ProductName;
            p.Description = model.Description;
            p.Image = String.Empty;
            p.SubmittedBy = System.Web.HttpContext.Current.User.Identity.Name;
            decimal x;
            Decimal.TryParse(model.Price,out x);
            p.MSRP = x;

            p.SubCategory = model.SubCategory;
            p.SiteUrl = !String.IsNullOrEmpty(model.SiteUrl) ? model.SiteUrl : String.Empty;

            return p;
        }
        internal static List<string> AllBrands()
        {
            return Data.Accessors.ProductsAccessor.GetAllBrands();
        }
    }
}