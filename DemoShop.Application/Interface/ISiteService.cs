using DemoShop.DataLayer.Entities.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Interface
{
    public interface ISiteService : IAsyncDisposable
    {
        Task<SiteSettings> GetDefaultSiteSettings();
    }
}
