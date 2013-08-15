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
        public static int AddGearProduct(NewProductModel model)
        { 
            ///rs 
            Data.Product dbProduct = ConvertNewGearToDbProduct(model, "GEAR");
            //int duplicateid = MappingSearch.Data.Accessors.ProductsAccessor.DuplicateProductExists(dbProduct);
                
            int id = MappingSearch.Data.Accessors.ProductsAccessor.AddNewGearProduct(dbProduct);
            return id;
        }

        private static Data.Product ConvertNewGearToDbProduct(NewProductModel model,string category)
        {
            Data.Product p = new Data.Product();
            
            p.Approved = false;
            p.Brand = model.Brand;
            p.Category = category;
            p.Title = FormInputHelper.StripInput(model.ProductName);
            p.Description = String.IsNullOrEmpty(model.Description) ? string.Empty : FormInputHelper.StripInput(model.Description);
            p.Image = String.Empty;
            p.SubmittedBy = System.Web.HttpContext.Current.User.Identity.Name;
            decimal x;
            Decimal.TryParse(model.Price,out x);
            p.MSRP = x;

            p.SubCategory = model.Subcategory;
            p.SiteUrl = !String.IsNullOrEmpty(model.SiteUrl) ? FormInputHelper.StripInput(model.SiteUrl): String.Empty;

            return p;
        }
        internal static List<string> AllBrands(string category)
        {
            
            return Data.Accessors.ProductsAccessor.GetAllBrands(category);
        }

        internal static List<string> AllGearSubcategories()
        {
            string[] subcats = new string[MappingSearch.Constants.DatabaseConstants.DatabaseConstants.GearSubCategoriesList.Count()];
            MappingSearch.Constants.DatabaseConstants.DatabaseConstants.GearSubCategoriesList.CopyTo(subcats);
            return subcats.ToList();
            
        }

        internal static List<string> AllMotorcycleSubcategories()
        {
            string[] subcats = new string[MappingSearch.Constants.DatabaseConstants.DatabaseConstants.MotorcycleSubCategories.Count()];
            MappingSearch.Constants.DatabaseConstants.DatabaseConstants.MotorcycleSubCategories.CopyTo(subcats);
            return subcats.ToList();
            
        }

        internal static List<string> AllEngineTypes()
        {
            string[] engines = new string[MappingSearch.Constants.DatabaseConstants.DatabaseConstants.MotorcycleEngineTypes.Count()];
            MappingSearch.Constants.DatabaseConstants.DatabaseConstants.MotorcycleEngineTypes.CopyTo(engines);
            return engines.ToList();
        }

        internal static int AddMotorcycleProduct(NewMotorcycleModel model)
        {
            Data.Product dbProduct = ConvertNewGearToDbProduct(model, "MOTORCYCLE");

            int id = MappingSearch.Data.Accessors.ProductsAccessor.AddNewGearProduct(dbProduct);

            Data.Motorcycle dbMotorcycle = ConvertNewMotorcycleToDbMotorcycle(model,id);
            MappingSearch.Data.Accessors.ProductsAccessor.AddNewMotorcycle(dbMotorcycle);

            return id;
        }

        private static Motorcycle ConvertNewMotorcycleToDbMotorcycle(NewMotorcycleModel model, int id)
        {
            Motorcycle m = new Motorcycle();

            m.Displacement = model.Displacement;
            m.EngineType = model.EngineType;
            m.Gears = model.Gears;
            m.TopSpeed = model.TopSpeed;
            m.Torque = model.Torque;
            m.ProductId = id;

            return m;
        }
    }
}