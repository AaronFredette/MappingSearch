using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MappingSearch.Models.ViewModels.Reviews;
using MappingSearch.Models.ViewModels;

namespace MappingSearch.Data.Accessors
{
    public class ReviewsAccessor
    {

        public static ProductReviewViewModel GetAllReviewsForProdcut(int id)
        {
            using(ReviewsDataContext context = new ReviewsDataContext())
            {
                ProductReviewViewModel model = new ProductReviewViewModel();
                var list = (from review in context.Reviews
                            join user in context.Users on review.UserId equals user.UserName
                            join product in context.Products on review.ProductId equals product.ProductId
                            where review.ProductId == id
                            select new ReviewViewModel
                            {
                                User = user.UserName,
                                UserMotorcycle = user.CurrentMotorcycle,
                                Rating = review.StarRating,
                                ReviewText = review.Review1,
                                LengthOfUse = review.LengthOfUse,
                                Description = product.Description,
                                
                            }).ToList();

                model.Reveiws = list;
                var productInfo= (from product in context.Products
                                     where product.ProductId == id
                                     select product).FirstOrDefault();
                model.ProductData = new ProductViewModel
                                {
                                    ProductTitle = productInfo.Title,
                                    ProductImage = productInfo.Image,
                                    ProductId = productInfo.ProductId,
                                    ProductBrand = productInfo.Brand,
                                    ProductDescription = productInfo.Description
                                };

                return model;
            }
        }
    }
}
