using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MappingSearch.Classes.Product
{
    public class ProductSelectionHelper
    {
        internal static List<Data.Product> GetCategoryBrandModel(string category)
        {
            List<Data.Product> rawProducts = new List<Data.Product>();
            if (Constants.HelperClasses.ConstantValidator.IsValidCategory(category))
                rawProducts = MappingSearch.Data.Accessors.ProductsAccessor.GetAllBrandsAndTypesForCategory(category);

            return rawProducts;
        }

        internal static List<Data.Product> GetCategoryBrandModelWithLimit(string category, int start, int end,string brand, string subcategory)
        {
            List<Data.Product> rawProducts = new List<Data.Product>();
            if (Constants.HelperClasses.ConstantValidator.IsValidCategory(category))
            {
                rawProducts = MappingSearch.Data.Accessors.ProductsAccessor.GetFilteredProducts(category,brand,subcategory);
            }
            end = rawProducts.Count > end ? end : rawProducts.Count;
            return rawProducts.Skip(start).Take(end).Select(x => x).ToList();
        }

        internal static Models.ViewModels.Product.CategoryAndBrandModel GetProductFacets(string category)
        {
            Models.ViewModels.Product.CategoryAndBrandModel facets = new Models.ViewModels.Product.CategoryAndBrandModel();
            if (Constants.HelperClasses.ConstantValidator.IsValidCategory(category))
                facets = MappingSearch.Data.Accessors.ProductsAccessor.GetAllFacetsForCategory(category);

            return facets;
        }

        internal static Models.ViewModels.Product.ProductViewModel GetProductInfo(int id)
        {
            return Data.Accessors.ProductsAccessor.GetProductInfo(id, System.Web.HttpContext.Current.User.Identity.Name);

        }

     
    }
}