using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.DataLayer.DTO.Orders
{
    public class UserOpenOrderDetailItemDTO
    {
        public long ProductId { get; set; }

        public string ProductTitle { get; set; }

        public string ProductImageName { get; set; }

        public long? ProductColorId { get; set; }

        public int Count { get; set; }

        public int ProductPrice { get; set; }

        public int ProductColorPrice { get; set; }

        public string ColorName { get; set; }
        public int? DiscountPercentage { get; set; }
    }
}
