﻿using MappingSearch.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MappingSearch.Classes.Product
{
    public class ProductSelectionHelper
    {
        private static int MAX_PRODUCTS = Constants.ViewConstants.PageCountConstants.MAX_PRODUCTS;
        internal static List<Data.Product> GetCategoryBrandModel(string category)
        {
            List<Data.Product> rawProducts = new List<Data.Product>();
            if (Constants.HelperClasses.ConstantValidator.IsValidCategory(category))
                rawProducts = MappingSearch.Data.Accessors.ProductsAccessor.GetAllBrandsAndTypesForCategory(category);

            return rawProducts;
        }

        internal static ResponseModel<List<Data.Product>> GetCategoryBrandModelWithLimit(string category, int start,string brand, string subcategory)
        {
            List<Data.Product> rawProducts = new List<Data.Product>();
            ResponseModel<List<Data.Product>> response = new ResponseModel<List<Data.Product>>();

            if (Constants.HelperClasses.ConstantValidator.IsValidCategory(category))
            {
                rawProducts = MappingSearch.Data.Accessors.ProductsAccessor.GetFilteredProducts(category,brand,subcategory);
            }
            response.PageCount = (rawProducts.Count() + MAX_PRODUCTS - 1) / MAX_PRODUCTS;
           var take = rawProducts.Count > MAX_PRODUCTS + start ? MAX_PRODUCTS : rawProducts.Count - start;
            response.Model =  rawProducts.Skip(start).Take(take).Select(x => x).ToList();
            return response;
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