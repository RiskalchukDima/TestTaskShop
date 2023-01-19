using Microsoft.EntityFrameworkCore;
using TestJ.Context;
using TestJ.IRepository;
using TestJ.Models;

namespace TestJ.Repositories
{
	public class TodoRepository : ITodoRepository
	{
		private EFMSSQLDBContext Context;
		public TodoRepository(EFMSSQLDBContext context1)
		{
			Context = context1;
		}
		public IEnumerable<Client> Get()
		{
			return Context.Clients;
		}
		public IEnumerable<Client> GetBirth(DateTime dt)
		{
			return Context.Clients.Where(p => p.BirthDate == dt);
		}
		public IEnumerable<Sale> GetLastN(int n)
		{
			return Context.Sale
				.Include(p => p.Client)
				.Where(x => x.SaleDate >= DateTime.Today.AddDays(-n) && x.SaleDate <= DateTime.Today)
				.ToList();
		}
		public IEnumerable<SaleItem> GetPopCat(int id)
		{
			return Context.SaleItem
				.Include(p => p.Product)
				.Include(b => b.Sale)
				.Include(n => n.Sale.Client)
				.Where(x => x.Sale.Client.Id == id)
				.ToList();
		}
	}
}
