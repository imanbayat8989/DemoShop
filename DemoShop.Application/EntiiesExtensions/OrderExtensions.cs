using DemoShop.DataLayer.DTO.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.EntiiesExtensions
{
    public static class OrderExtensions
    {
        public static string GetOrderDetailWithDiscountPrice(this UserOpenOrderDetailItemDTO detail)
        {
            if (detail.DiscountPercentage != null)
            {
                return (detail.ProductPrice * detail.DiscountPercentage.Value / 100 * detail.Count).ToString("#,0 تومان");
            }

            return "------";
        }
    }
}
