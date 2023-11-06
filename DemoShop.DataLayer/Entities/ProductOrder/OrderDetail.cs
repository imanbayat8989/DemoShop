using DemoShop.DataLayer.Entities.common;
using DemoShop.DataLayer.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.DataLayer.Entities.ProductOrder
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

        public Products.Product Product { get; set; }

        public ProductColor ProductColor { get; set; }

        #endregion
    }
    
}
