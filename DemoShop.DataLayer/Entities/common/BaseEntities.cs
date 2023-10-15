using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.DataLayer.Entities.common
{
	public class BaseEntities<TEntity>
	{
        public TEntity Id { get; set; }
    }
}
