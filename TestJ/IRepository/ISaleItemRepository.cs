using TestJ.Models;

namespace TestJ.IRepository
{
	public interface ISaleItemRepository
	{
		IEnumerable<SaleItem> Get();
		SaleItem Get(int id);
		void Create(SaleItem item);
		void Update(SaleItem item);
		SaleItem Delete(int id);
	}
}
