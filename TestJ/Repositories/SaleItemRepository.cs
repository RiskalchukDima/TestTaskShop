using TestJ.Context;
using TestJ.IRepository;
using TestJ.Models;

namespace TestJ.Repositories
{
	public class SaleItemRepository : ISaleItemRepository
	{
		private EFMSSQLDBContext Context;
		public SaleItemRepository(EFMSSQLDBContext context1)
		{
			Context = context1;
		}
		public IEnumerable<SaleItem> Get()
		{
			return Context.SaleItem;
		}
		public SaleItem Get(int Id)
		{
			return Context.SaleItem.Find(Id);
		}
		public void Create(SaleItem item)
		{
			Context.SaleItem.Add(item);
			Context.SaveChanges();
		}
		public void Update(SaleItem updatedTodoItem)
		{
			SaleItem currentItem = Get(updatedTodoItem.Id);
			currentItem.SaleId = updatedTodoItem.SaleId;
			currentItem.Sale = updatedTodoItem.Sale;
			currentItem.ProductId = updatedTodoItem.ProductId;
			currentItem.Product = updatedTodoItem.Product;
			currentItem.Count = updatedTodoItem.Count;
			Context.SaleItem.Update(currentItem);
			Context.SaveChanges();
		}

		public SaleItem Delete(int Id)
		{
			SaleItem todoItem = Get(Id);

			if (todoItem != null)
			{
				Context.SaleItem.Remove(todoItem);
				Context.SaveChanges();
			}

			return todoItem;
		}
	}
}
