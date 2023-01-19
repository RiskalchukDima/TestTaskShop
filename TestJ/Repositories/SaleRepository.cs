using TestJ.Context;
using TestJ.IRepository;
using TestJ.Models;

namespace TestJ.Repositories
{
	public class SaleRepository: ISaleRepository
	{
		private EFMSSQLDBContext Context;
		public SaleRepository(EFMSSQLDBContext context1)
		{
			Context = context1;
		}
		public IEnumerable<Sale> Get()
		{
			return Context.Sale;
		}
		public Sale Get(int Id)
		{
			return Context.Sale.Find(Id);
		}
		public void Create(Sale item)
		{
			Context.Sale.Add(item);
			Context.SaveChanges();
		}
		public void Update(Sale updatedTodoItem)
		{
			Sale currentItem = Get(updatedTodoItem.Id);
			currentItem.Nmr = updatedTodoItem.Nmr;
			currentItem.SaleDate = updatedTodoItem.SaleDate;
			currentItem.SaleAmount = updatedTodoItem.SaleAmount;
			currentItem.ClientId = updatedTodoItem.ClientId;
			currentItem.Client = updatedTodoItem.Client;
			Context.Sale.Update(currentItem);
			Context.SaveChanges();
		}

		public Sale Delete(int Id)
		{
			Sale todoItem = Get(Id);

			if (todoItem != null)
			{
				Context.Sale.Remove(todoItem);
				Context.SaveChanges();
			}

			return todoItem;
		}
	}
}
