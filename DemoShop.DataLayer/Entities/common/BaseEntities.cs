using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.DataLayer.Entities.common
{
	public class BaseEntities
	{
        [Key]
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
