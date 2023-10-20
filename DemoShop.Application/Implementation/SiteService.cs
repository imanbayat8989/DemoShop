using DemoShop.Application.Interface;
using DemoShop.DataLayer.Entities.Site;
using DemoShop.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Implementation
{
    public class SiteService : ISiteService
    {
        #region Constructor

        private readonly IGenericRepository<SiteSettings> _siteSettingsRepository;

        public SiteService(IGenericRepository<SiteSettings> siteSettingsRepository)
        {
            _siteSettingsRepository = siteSettingsRepository;
        }

        #endregion

        #region Dispose

        public async ValueTask DisposeAsync()
        {
            await _siteSettingsRepository.DisposeAsync();
        }

        #endregion

        #region siteSettings

        public async Task<SiteSettings> GetDefaultSiteSettings()
        {
            return await _siteSettingsRepository.GetQuery().AsQueryable()
                .SingleOrDefaultAsync(x => x.IsDefault && !x.IsDeleted);
        }

        #endregion
    }
}
