using DemoShop.DataLayer.Entities.common;
using DemoShop.DataLayer.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.DataLayer.Entities.Orders
{
    public class OrderDetail : BaseEntities
    {
        #region properties

        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public long? ProductColorId { get; set; }

        public int Count { get; set; }

        public int ProductPrice { get; set; }

        public int ProductColorPrice { get; set; }

        #endregion

        #region relations

        public Order Order { get; set; }

        public TProducts Productse { get; set; }

        public ProductColor ProductColor { get; set; }

        #endregion
    }
    
}
