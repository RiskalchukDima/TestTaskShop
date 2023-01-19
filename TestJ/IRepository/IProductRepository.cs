using TestJ.Models;

namespace TestJ.IRepository
{
	public interface IProductRepository
	{
		IEnumerable<Product> Get();
		Product Get(int id);
		void Create(Product item);
		void Update(Product item);
		Product Delete(int id);
	}
}
