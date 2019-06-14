using System.Linq;
using System.Threading.Tasks;

namespace Bluegrass.Menu.EFRepository
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity> GetAll();
		Task<TEntity> GetById(int id, string[] includes = null);
		Task Create(TEntity entity);
		Task Update(TEntity entity);
		Task Delete(int id);
	}
}
