using DemoShop.DataLayer.Entities.common;
using DemoShop.DataLayer.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoShop.DataLayer.DTO.Products
{
    public class ProductFeature : BaseEntities
    {
        #region properties

        public long ProductId { get; set; }

        [Display(Name = "عنوان ویژگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string FeatureTitle { get; set; }

        [Display(Name = "مقدار ویژگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string FeatureValue { get; set; }

        #endregion

        #region relations

        public Product Product { get; set; }

        #endregion
    }
}
