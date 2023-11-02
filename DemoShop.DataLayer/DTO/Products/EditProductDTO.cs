using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.DataLayer.DTO.Products
{
    public class EditProductDTO : CreateProductDTO
    {
        public long Id { get; set; }
    }
}
