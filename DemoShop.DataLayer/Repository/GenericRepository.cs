using DemoShop.DataLayer.Contract;
using DemoShop.DataLayer.Entities.common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.DataLayer.Repository
{
	public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : BaseEntities
	{
		private readonly DemoShopDbContext _context;
		private readonly DbSet<TEntity> _dbset;

        public GenericRepository(DemoShopDbContext context)
        {
            _context = context;
            this._dbset = context.Set<TEntity>();
        }

        public async Task AddEntity(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            await _dbset.AddAsync(entity);
        }

		public void DeleteEntity(TEntity entity)
		{
			_dbset.Update(entity);
		}

		public void DeleteEntity(long entityId)
		{
			TEntity entity = (entityId);
		}

		public void DeletePermanent(TEntity entity)
		{
			_dbset.Remove(entity);
		}

		public async Task DeletePermanent(long entityId)
		{
			
			TEntity entity = await GetEntityById(entityId);
			DeletePermanent(entity);
		}

		public async ValueTask DisposeAsync()
        {
            if (_context != null)
            {
                await _context.DisposeAsync();
            }
        }

		public void EditEntity(TEntity entity)
		{
			entity.LastUpdateDate = DateTime.Now;
            _dbset.Update(entity);
		}

		public async Task<TEntity> GetEntityById(long entityId)
		{
			return await _dbset.SingleOrDefaultAsync(x => x.Id == entityId);
		}
	}
}
