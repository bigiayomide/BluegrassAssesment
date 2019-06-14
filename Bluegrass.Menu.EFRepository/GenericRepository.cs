using Microsoft.EntityFrameworkCore;
using Bluegrass.Menu.EFRepository.Context;
using System.Linq;
using System.Threading.Tasks;
using Bluegrass.Menu.Models;
using Bluegrass.Menu.EFRepository.Extensions;

namespace Bluegrass.Menu.EFRepository
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity>
	where TEntity : class, IEntity
	{
		private readonly BluegrassContext _dbContext;
		public GenericRepository(BluegrassContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Create(TEntity entity)
		{
			await _dbContext.Set<TEntity>().AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var entity = await GetById(id);
        entity.Active = false;
      _dbContext.Set<TEntity>().Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		public IQueryable<TEntity> GetAll()
		{
			return _dbContext.Set<TEntity>().AsNoTracking().Where(x => x.Active == true);
		}

		public async Task<TEntity> GetById(int Id, string[] includes = null)
		{
			return await _dbContext.Set<TEntity>()
			   .AsNoTracking()
				 .IncludeMultiple(includes)
				 .FirstOrDefaultAsync(e=> e.Id == Id);
		}
		public async Task Update(TEntity entity)
		{
			_dbContext.Set<TEntity>().Update(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Update(int id, TEntity entity)
		{
			_dbContext.Set<TEntity>().Update(entity);
			await _dbContext.SaveChangesAsync();
		}
	}
}
