using TestJ.Models;

namespace TestJ.IRepository
{
	public interface ISaleRepository
	{
		IEnumerable<Sale> Get();
		Sale Get(int id);
		void Create(Sale item);
		void Update(Sale item);
		Sale Delete(int id);
	}
}
