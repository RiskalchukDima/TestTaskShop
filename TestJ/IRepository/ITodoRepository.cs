using TestJ.Models;

namespace TestJ.IRepository
{
	public interface ITodoRepository
	{
		IEnumerable<Client> Get();
		IEnumerable<Client> GetBirth(DateTime dt);
		IEnumerable<Sale> GetLastN(int n);
		IEnumerable<SaleItem> GetPopCat(int id);
		
	}
}
