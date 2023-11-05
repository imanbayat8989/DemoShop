using DemoShop.DataLayer.Entities.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.DataLayer.Entities.Product
{
    public class ProductSelectedCategory : BaseEntities
    {
        #region properties

        public long ProductId { get; set; }

        public long ProductCategoryId { get; set; }

        #endregion

        #region relations

        public TProducts Product { get; set; }

        public ProductCategory ProductCategory { get; set; }

        #endregion
    }
}
