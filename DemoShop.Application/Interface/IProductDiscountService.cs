using DemoShop.DataLayer.DTO.Discount;
using DemoShop.DataLayer.DTO.ProductDiscount;
using DemoShop.DataLayer.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Interface
{
    public interface IProductDiscountService : IAsyncDisposable
    {
        #region product discount

        Task<FilterProductDiscountDTO> FilterProductDiscount(FilterProductDiscountDTO filter);

        Task<CreateDiscountResult> CreateProductDiscount(CreateProductDiscountDto discount, long sellerId);

        #endregion
    }
}
