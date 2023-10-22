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
        private readonly IGenericRepository<Slider> _siteService;

        public SiteService(IGenericRepository<SiteSettings> siteSettingsRepository, IGenericRepository<Slider> siteService)
        {
            _siteSettingsRepository = siteSettingsRepository;
            _siteService = siteService;
        }

        #endregion

        #region Dispose

        public async ValueTask DisposeAsync()
        {
            if (_siteSettingsRepository != null) await _siteSettingsRepository.DisposeAsync();
            if (_siteService != null) await _siteService.DisposeAsync(); 
            
        }

        
        #endregion

        #region siteSettings

        public async Task<SiteSettings> GetDefaultSiteSettings()
        {
            return await _siteSettingsRepository.GetQuery().AsQueryable()
                .SingleOrDefaultAsync(x => x.IsDefault && !x.IsDeleted);
        }

        #endregion

        #region Slider

        public async Task<List<Slider>> GetAllActiveSliders()
        {
            return await _siteService.GetQuery().AsQueryable()
                .Where(x => x.IsActive && !x.IsDeleted).ToListAsync();
        }


        #endregion
    }
}
